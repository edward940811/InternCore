using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using Dapper;
using Legal.Entity;
using Legal.LawFile.ViewModel;
using Legal.Models;

namespace Legal.LawFile.Models
{
    public static class StringExtension
    {
        public static bool InProperties(this string value, Type obj)
        {
            if (value == null) { return false; }
            foreach (var prop in obj.GetProperties())
            {
                if (value.ToUpper().Equals(prop.Name.ToUpper()))
                {
                    return true;
                }
            }

            return false;
        }
    }
    public class LawFileRepository : BaseRepository
    {
        public IEnumerable<LawFileVM> GetLawFiles(LawSearchCondition condition, string companyId)
        {
            var dynamicParams = new DynamicParameters();
            var lawSql = @"
                        SELECT T1.[LawNo],
                               T3.[Name] AS BType,
                               T1.[MType],
                               T1.[LawName],
                               T1.[LawUrl],
                               T1.[PDate],
                               T1.[MDate],
                               T1.[ModifyType],
                               T2.[LFNo],
                               T2.[LFName],
                               T2.[LFUrl]
                        FROM [dbo].[LawInfoLastest] T1
                        JOIN [dbo].[LawFileLastest] T2 ON T1.[LawNo] = T2.[LawNo]
                        JOIN [dbo].[fn_GetBType](@CompanyId) T3 ON T3.[Key] = T1.[BType]
                        WHERE 1=1 
                        AND (@LawNos IS NULL OR T2.LawNo IN (SELECT value FROM [dbo].[fn_Split](@LawNos, ','))) 
                        AND (@Abolished IS NULL OR T1.[ModifyType] <> @Abolished) 
";

            var custSql = @" SELECT T1.[LawNo],
                                T3.[Name] AS BType,
                                T1.[MType],
                                T1.[LawName],
                                T1.[LawUrl],
                                T1.[PDate],
                                T1.[MDate],
                                T1.[ModifyType],
                                T2.LFNo,
                                T2.[LFName],
                                '-' as LFUrl
                        FROM [dbo].[Custom_Law_Info_Lastest] T1
                        JOIN [dbo].[Custom_Law_File_Lastest] T2 
						ON T1.[CustomLawInfoId] = T2.[CustomLawInfoId] AND T1.CompanyId=@CompanyId
                        JOIN [dbo].[fn_GetBType](@CompanyId) T3 ON T3.[Key] = T1.[BType]
                        WHERE 1=1 
                        AND (@LawNos IS NULL OR T2.LawNo IN (SELECT value FROM [dbo].[fn_Split](@LawNos, ','))) 
                        AND (@Abolished IS NULL OR T1.[ModifyType] <> @Abolished)  
                         ";

            dynamicParams.Add("@CompanyId", companyId);
            dynamicParams.Add("@LawNos", !condition.LawNos.Any() ? null : string.Join(",", condition.LawNos));
            dynamicParams.Add("@Abolished", condition.AbolishedLaw ? null : "3");

            if (!string.IsNullOrWhiteSpace(condition.BType))
            {
                lawSql += "AND T1.[BType] = @BType ";
                custSql += "AND T1.[BType] = @BType ";
                dynamicParams.Add("@BType", condition.BType);

                if (!string.IsNullOrWhiteSpace(condition.MType))
                {
                    lawSql += "AND T1.[MType] = @MType ";
                    custSql += "AND T1.[MType] = @MType ";
                    dynamicParams.Add("@MType", condition.MType);
                }
            }

            if (!string.IsNullOrWhiteSpace(condition.Keyword))
            {

                lawSql += GeneratorKeywordSearchByAnd(condition.Keyword, dynamicParams);
                custSql += GeneratorKeywordForCustomerLawFile(condition.Keyword, dynamicParams);
            }

            if (condition.StartDate != condition.EndDate)
            {
                lawSql += "AND (T1.[PDate] Between @StartDate AND @EndDate OR T1.[MDate] Between @StartDate AND @EndDate) ";
                custSql += "AND (T1.[PDate] Between @StartDate AND @EndDate OR T1.[MDate] Between @StartDate AND @EndDate) ";
                dynamicParams.Add("@StartDate", condition.StartDate);
                dynamicParams.Add("@EndDate", condition.EndDate);
            }

            ////設定排序預設欄位
            var defeultOrder = "LawNo,LFNo ASC ";

            if (condition.SortColumn.InProperties(typeof(LawFileVM)))
            {
                if (!new[] { "ASC", "DESC" }.Any(c => c.Contains(condition.SortOrder.ToUpper())))
                {
                    condition.SortOrder = "ASC";
                }

                defeultOrder = condition.SortColumn + " " + condition.SortOrder + " ";
            }

            var sql = $@"WITH TempResult AS(
                        {lawSql}
                        UNION ALL
                        {custSql} ";

            sql += @"), TotalRecords AS (
                        SELECT COUNT(*) AS TotalRecords FROM TempResult
                    )
                    SELECT *
                    FROM TempResult, TotalRecords ";

            sql += "ORDER BY " + defeultOrder;

            if (condition.PageSize != null && condition.PageIndex != null)
            {
                sql += @"OFFSET (@PageIndex-1)*@PageSize ROWS
                         FETCH NEXT @PageSize ROWS ONLY ";
                dynamicParams.Add("@PageIndex", condition.PageIndex);
                dynamicParams.Add("@PageSize", condition.PageSize);
            }

            using (var con = new SqlConnection(this.LegalConnectionString))
            {
                return con.Query<LawFileVM>(sql, dynamicParams);
            }
        }
        private string GeneratorKeywordForCustomerLawFile(string keyword, DynamicParameters parameters)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return "";
            }
            //lawSql += "AND (CONTAINS ([LFName],@Keyword) ";
            //lawSql += "OR CONTAINS ([LawName],@Keyword)  ";
            //lawSql += "OR CONTAINS ([LFContent],@Keyword)) ";
            if (keyword.Contains(" "))
            {
                string[] value = keyword.Split(new string[] { " " }, StringSplitOptions.None);
                string condition = "AND ( ";
                for (int i = 0; i < value.Length; i++)
                {
                    if (!string.IsNullOrEmpty(value[i]))
                    {
                        var conditionName = "GeneratorKeyword" + i;
                        parameters.Add(conditionName, value[i]);
                        condition += $@"
                        (dbo.ContainsOne([LFName],@{conditionName})=1 
                        OR dbo.ContainsOne([LawName],@{conditionName})=1  
                        )
                         AND ";
                    }
                }
                condition += " 1=1 ) ";
                return condition;
            }
            else
            {
                parameters.Add("GeneratorKeyword", keyword);
                return @" AND (dbo.ContainsOne([LFName],@GeneratorKeyword)=1 
                OR dbo.ContainsOne([LawName],@GeneratorKeyword)= 1
                )";
            }
        }
        private string GeneratorKeywordSearchByAnd(string keyword, DynamicParameters parameters)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return "";
            }
            //lawSql += "AND (CONTAINS ([LFName],@Keyword) ";
            //lawSql += "OR CONTAINS ([LawName],@Keyword)  ";
            //lawSql += "OR CONTAINS ([LFContent],@Keyword)) ";
            if (keyword.Contains(" "))
            {
                string[] value = keyword.Split(new string[] { " " }, StringSplitOptions.None);
                string condition = "AND ( ";
                for (int i = 0; i < value.Length; i++)
                {
                    if (!string.IsNullOrEmpty(value[i]))
                    {
                        var conditionName = "GeneratorKeyword" + i;
                        parameters.Add(conditionName, value[i]);
                        condition += $@"
                        (dbo.ContainsOne([LFName],@{conditionName})=1 
                        OR dbo.ContainsOne([LawName],@{conditionName})=1  
                        OR dbo.ContainsOne([LFContent],@{conditionName})=1)
                         AND ";
                    }
                }
                condition += " 1=1 ) ";
                return condition;
            }
            else
            {
                parameters.Add("GeneratorKeyword", keyword);
                return @" AND (dbo.ContainsOne([LFName],@GeneratorKeyword)=1 
                OR dbo.ContainsOne([LawName],@GeneratorKeyword)= 1
                OR dbo.ContainsOne([LFContent],@GeneratorKeyword)= 1)";
            }
        }
    }
}
