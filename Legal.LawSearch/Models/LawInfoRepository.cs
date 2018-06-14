using System;
using System.Collections.Generic;
using Dapper;
using LawKing.Entity;
using LawKing.Entity.ViewModels;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;

namespace LawKing.DAL
{
    public static class StringExtension
    {
        public static string GenerateSqlContainsKeyword(this string value)
        {
            var keywords = Regex.Replace(value.Trim(), " +", " ").Split(' ');
            // HACK: 需要解決多個關鍵字如何重組
            return string.Format(@"""{0}*""", string.Join(@""" AND """, keywords));
        }
        public static string GenerateOrder(this string value, Type obj, string defeultOrder, string sortOrder)
        {
            if (value == null) { return defeultOrder + " "; }

            foreach (var prop in obj.GetProperties())
            {
                if (value.ToUpper().Equals(prop.Name.ToUpper()))
                {
                    if (!new[] { "ASC", "DESC" }.Any(c => c.Contains(sortOrder.ToUpper())))
                    {
                        sortOrder = "ASC";
                    }

                    return value + " " + sortOrder + " ";
                }
            }

            return defeultOrder + " ";
        }
    }
    public class LawInfoRepository : BaseRepository
    {

        public IEnumerable<LawInfoVM> GetLawInfos(LawSearchCondition condition, string companyId, int userId, bool containCustLaw)
        {
            var dynamicParams = new DynamicParameters();
            string keyWordSection = GeneratorKeywordSearchByAnd(condition.Keyword, dynamicParams);
            var sql = $@"WITH TempResult AS(
                       SELECT  0 as CustomLawInfoId ,
			                    T1.[LawNo],
                                T4.[Name] AS BType,
                                [MType],
                                [SType],
                                [LawName],
                                [LawUrl],
                                [PDate],
                                [MDate],
                                [ModifyType],
			                    '' as Memo,
			                    T1.DBVersion,
                                [ShareLawInfoId],
                                [FavoriteLawInfoId],
			                    0 as CustomLawContentCount,
			                    '' as ModifyUserName
                        FROM [dbo].[LawInfoLastest] T1
                        LEFT JOIN [dbo].[fn_GetShareLawInfo](@CompanyId) T2 ON T1.[LawNo] = T2.[LawNo]
                        LEFT JOIN [dbo].[fn_GetFavoriteLawInfo](@CompanyId,@UserId) T3 ON T1.[LawNo] = T3.[LawNo]
                        JOIN [dbo].[fn_GetBType](@CompanyId) T4 ON T4.[Key] = T1.BType
                        WHERE (@BType IS NULL OR T1.[BType] = @BType) 
                          AND (@MType IS NULL OR [MType] = @MType) 
                          AND (@Keyword ='""""' OR {keyWordSection}) 
                          AND ((@StartDate IS NULL OR @EndDate IS NULL) OR (([PDate] >= @StartDate AND [PDate] <= @EndDate) OR ([MDate] >= @StartDate AND [MDate] <= @EndDate))) 
                          AND (@Abolished IS NULL OR T1.[ModifyType] <> @Abolished)

                            UNION ALL

                            SELECT [CustomLawInfoId],
			                        T1.[LawNo],
			                        [BType],
			                        [MType],
			                        [SType],
			                        [LawName],
			                        [LawUrl],
			                        [PDate],
			                        [MDate],
			                        [ModifyType],
			                        T1.[Memo],
			                        [DBVersion],
			                        [ShareLawInfoId],
			                        [FavoriteLawInfoId],
			                        (SELECT COUNT([CustomLawInfoId])
			                        FROM [dbo].[Custom_Law_Content_Lastest]
			                        WHERE [CustomLawInfoId] = T1.[CustomLawInfoId]) AS CustomLawContentCount,
				                        (CASE
					                        WHEN T2.[DisplayName] IS NULL THEN T2.[AccountNo]
					                        ELSE T2.[DisplayName]
				                        END) AS ModifyUserName
	                        FROM [dbo].[Custom_Law_Info_Lastest] T1
	                        LEFT JOIN [dbo].[syn_User] T2 ON T2.[UserId] = T1.[ModifyUserId]
	                        LEFT JOIN [dbo].[fn_GetShareLawInfo](@CompanyId) T4 ON T1.[LawNo] = T4.[LawNo]
	                        LEFT JOIN [dbo].[fn_GetFavoriteLawInfo](@CompanyId,@UserId) T3 ON T1.[LawNo] = T3.[LawNo]
	                        WHERE T1.[CompanyId] = @CompanyId AND
                                (@BType IS NULL OR T1.[BType] = @BType) 
                                    AND (@MType IS NULL OR [MType] = @MType) 
                                    AND (@Keyword ='""""' OR {keyWordSection}) 
                                    AND ((@StartDate IS NULL OR @EndDate IS NULL) OR (([PDate] >= @StartDate AND [PDate] <= @EndDate) OR ([MDate] >= @StartDate AND [MDate] <= @EndDate))) 
                                    AND (@Abolished IS NULL OR T1.[ModifyType] <> @Abolished)

                    ), ";

            sql += @" TotalRecords AS (
                        SELECT COUNT(*) AS TotalRecords FROM TempResult
                    )";

            // 搜尋結果
            sql += " SELECT * FROM TempResult, TotalRecords ";
            sql += "ORDER BY " + condition.SortColumn.GenerateOrder(typeof(LawInfoVM), "LawNo ASC", condition.SortOrder);
            sql += @"OFFSET (@PageIndex-1)*@PageSize ROWS FETCH NEXT @PageSize ROWS ONLY ";

            dynamicParams.Add("@CompanyId", companyId);
            dynamicParams.Add("@UserId", userId);
            dynamicParams.Add("@BType", string.IsNullOrWhiteSpace(condition.BType) ? null : condition.BType);
            dynamicParams.Add("@MType", string.IsNullOrWhiteSpace(condition.MType) ? null : condition.MType);
            dynamicParams.Add("@Keyword", string.IsNullOrEmpty(condition.Keyword) ? @"""""" : condition.Keyword.GenerateSqlContainsKeyword());
            dynamicParams.Add("@StartDate", condition.StartDate);
            dynamicParams.Add("@EndDate", condition.EndDate);
            dynamicParams.Add("@PageIndex", condition.PageIndex);
            dynamicParams.Add("@PageSize", condition.PageSize);
            dynamicParams.Add("@Abolished", condition.AbolishedLaw ? null : "3");

            using (var con = new SqlConnection(this.LegalConnectionString))
            {
                return con.Query<LawInfoVM>(sql, dynamicParams);
            }
        }
        private string GeneratorKeywordSearchByAnd(string keyword, DynamicParameters parameters)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return " 1=1 ";
            }
            if (keyword.Contains(" "))
            {
                string[] value = keyword.Split(new string[] { " " }, StringSplitOptions.None);
                string condition = "( ";
                for (int i = 0; i < value.Length; i++)
                {
                    var conditionName = "GeneratorKeyword" + i;
                    parameters.Add(conditionName, value[i]);
                    condition += " dbo.ContainsOne(T1.[LawName],@" + conditionName + ")=1 AND ";
                }
                condition += " 1=1 ) ";
                return condition;
            }
            else
            {
                parameters.Add("GeneratorKeyword", keyword);
                return " dbo.ContainsOne(T1.[LawName],@GeneratorKeyword)=1 ";
            }
        }
        

    }
}
