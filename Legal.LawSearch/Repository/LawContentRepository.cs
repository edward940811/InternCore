using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Legal.LawSearch.Conditions;
using Legal.LawSearch.ViewModels;
using Legal.Repository;

namespace Legal.LawSearch.Repository
{

    internal class LawContentRepository : BaseRepository
    {
        public IEnumerable<LawContentVM> GetLawContents(LawSearchCondition condition, string companyId)
        {
            var dynamicParams = new DynamicParameters();
            string keyWordSection = GeneratorKeywordSearchByAnd(condition.Keyword, dynamicParams);
            // dbo.ContainsOne([LCHtml],'水污') = 1
            var sql = $@"
                        SELECT  [LawNo],
                                [LCNo],
                                [LCArticle],
                                [LCHtml],
                                [ModifyType],[OrderIndex]        
                        INTO #TempLawContentLastest
                        FROM dbo.LawContentLastest
                        WHERE  
                        ({keyWordSection} ) 
                        AND (@Abolished IS NULL OR [ModifyType] <> @Abolished)

                        SELECT   T3.[MType],
                                 T3.[LawName],
                                 T3.[LawUrl],
                                 T3.[PDate],
                                 T3.[MDate],
		                         T3.[ModifyType],
		                         T3.BType,
	                             T3.LawNo
                        INTO #TempLawInfoLastest
                        FROM dbo.LawInfoLastest T3
                        WHERE  (@Abolished IS NULL OR T3.[ModifyType] <> @Abolished) 
						AND (@BType IS NULL OR T3.[BType] = @BType) 
                        AND (@MType IS NULL OR T3.[MType] = @MType) 

                        ;WITH TempResult AS(
                        SELECT T1.[LawNo],
                               T1.[LCNo],
                               T1.[LCArticle],
                               T1.[LCHtml],
                               T1.[ModifyType],                              
                               T2.[Name] AS BType,
                               T3.[MType],
                               T3.[LawName],
                               T3.[LawUrl],
                               T3.[PDate],
                               T3.[MDate],
                               T1.[OrderIndex]
                        FROM #TempLawContentLastest AS T1
                        JOIN #TempLawInfoLastest AS T3 ON T3.LawNo = T1.LawNo
                        JOIN [dbo].[fn_GetBType](@CompanyId) T2 ON T2.[Key] = T3.[BType]
                          WHERE 1 = 1 
                          AND ((@StartDate IS NULL OR @EndDate IS NULL) OR (([PDate] >= @StartDate AND [PDate] <= @EndDate) OR ([MDate] >= @StartDate AND [MDate] <= @EndDate))) 

                        UNION ALL

                        SELECT T1.[LawNo],
                            T2.[LCNo],
                            T2.[LCArticle],
                            T2.[LCHtml],
                            T2.[ModifyType],
                            T3.[Name] AS BType,
                            T1.[MType],
                            T1.[LawName],
                            T1.[LawUrl],
                            T1.[PDate],
                            T1.[MDate],
                            T2.[OrderIndex]
                        FROM [dbo].[Custom_Law_Info_Lastest] T1
                        INNER JOIN [dbo].[Custom_Law_Content_Lastest] T2 ON T1.[CustomLawInfoId] = T2.[CustomLawInfoId]  AND T1.[CompanyId] = @CompanyId
                        JOIN [dbo].[fn_GetBType](@CompanyId) T3 ON T3.[Key] = T1.[BType]
                        WHERE
                            ( {keyWordSection})
                            AND (@BType IS NULL OR T1.[BType] = @BType) 
                            AND (@MType IS NULL OR T1.[MType] = @MType) 
                            AND ((@StartDate IS NULL OR @EndDate IS NULL) OR ((T1.[PDate] >= @StartDate AND T1.[PDate] <= @EndDate) OR (T1.[MDate] >= @StartDate AND T1.[MDate] <= @EndDate)))
                            AND ((@StartDate IS NULL OR @EndDate IS NULL) OR T2.[ModifyType] <> 0)
                            AND (@Abolished IS NULL OR T2.[ModifyType] <> @Abolished)
                            AND (@Abolished IS NULL OR T1.[ModifyType] <> @Abolished)
";

            dynamicParams.Add("@BType", string.IsNullOrWhiteSpace(condition.BType) ? null : condition.BType);
            dynamicParams.Add("@MType", string.IsNullOrWhiteSpace(condition.MType) ? null : condition.MType);
            dynamicParams.Add("@StartDate", condition.StartDate);
            dynamicParams.Add("@EndDate", condition.EndDate);

            sql += @"), TotalRecords AS (
                        SELECT COUNT(*) AS TotalRecords FROM TempResult
                    )
                    SELECT *
                    FROM TempResult, TotalRecords ";

            sql += "ORDER BY " + condition.SortColumn.GenerateOrder(typeof(LawContentVM), "LawNo,OrderIndex ASC", condition.SortOrder);
            sql += @"OFFSET (@PageIndex-1) * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY ";
            sql += @"
                    DROP TABLE #TempLawContentLastest
                    DROP TABLE #TempLawInfoLastest
            ";
            dynamicParams.Add("@CompanyId", companyId);
            dynamicParams.Add("@PageIndex", condition.PageIndex);
            dynamicParams.Add("@PageSize", condition.PageSize);
            dynamicParams.Add("@Abolished", condition.AbolishedLaw ? null : "3");

            using (var con = new SqlConnection(this.LegalConn))
            {
                return con.Query<LawContentVM>(sql, dynamicParams);
            }
        }


        private string GeneratorKeywordSearchByAnd(string keyword, DynamicParameters parameters)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return " 1=1";
            }
            //dbo.ContainsOne([LCHtml],@LikeKeyword)= 1
            if (keyword.Contains(" "))
            {
                string[] value = keyword.Split(new string[] { " " }, StringSplitOptions.None);
                string condition = "( ";
                for (int i = 0; i < value.Length; i++)
                {
                    var conditionName = "GeneratorKeyword" + i;
                    parameters.Add(conditionName, value[i]);
                    condition += " dbo.ContainsOne([LCHtml],@" + conditionName + ")=1 AND ";
                }
                condition += " 1=1 ) ";
                return condition;
            }
            else
            {
                parameters.Add("GeneratorKeyword", keyword);
                return " dbo.ContainsOne([LCHtml],@GeneratorKeyword)=1 ";
            }
        }
    }
}


