using Dapper;
using ESHCloud.Base.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Legal.GazetteCrawler.Service
{

    public class GazetteService : BaseRepository
    {
        public GazetteService()
        {

        }
        public void Create(Gazette gazette)
        {
            using (var con = new SqlConnection(this.ESHCloudCoreConn))
            {
                var sql = $@"INSERT INTO [dbo].[xml]
                                       (
                                       [metaIdField]
                                       ,[doc_Style_LNameField]
                                       ,[doc_Style_SNameField]
                                       ,[chapterField]
                                       ,[pubGovField]
                                       ,[pubGovNameField]
                                       ,[undertakeGovField]
                                       ,[officer_nameField]
                                       ,[date_CreatedField]
                                       ,[gazetteIdField]
                                       ,[date_PublishedField]
                                       ,[comment_DeadlineField]
                                       ,[comment_DaysField]
                                       ,[titleField]
                                       ,[titleEnglishField]
                                       ,[themeSubjectField]
                                       ,[keywordField]
                                       
                                       ,[explainField]
                                       ,[categoryField]
                                       ,[cakeField]
                                       ,[serviceField]
                                       ,[gazetteHTMLField]
                                       ,[hTMLContentField])
                                 VALUES
                                       (@MetaId
                                       ,@Doc_Style_LName
                                       ,@Doc_Style_SName
                                       ,@Chapter
                                       ,@PubGov
                                       ,@PubGovName
                                       ,@UndertakeGov
                                       ,@Officer_name
                                       ,@Date_Created
                                       ,@GazetteId
                                       ,@Date_Published
                                       ,@Comment_Deadline
                                       ,@Comment_Days
                                       ,@Title
                                       ,@TitleEnglish
                                       ,@ThemeSubject
                                       ,@Keyword
                                       
                                       ,@Explain
                                       ,@Category
                                       ,@Cake
                                       ,@Service
                                       ,@GazetteHTML
                                       ,@HTMLContent)";
                //con.Execute(sql, gazette.Record[0]);
                foreach (GazetteRecord record in gazette.Record)
                {
                    con.Execute(sql, record);
                }
            }
        }

    }
}
