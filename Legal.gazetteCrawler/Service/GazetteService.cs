using Dapper;
using ESHCloud.Base.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Legal.GazetteCrawler.Service
{

    public class GazetteService : BaseRepository
    {
        public GazetteService()
        {

        }
        public List<string> GetAll()
        {
            using (var con = new SqlConnection(this.ESHCloudCoreConn))
            {
                var sql = $@"SELECT [CrawledDate]
                             FROM [dbo].[GazetteCrawled]";
                List<string> model = con.Query<string>(sql).ToList();
                return model;
            }
        }
        public void Create(Gazette gazette)
        {
            using (var con = new SqlConnection(this.ESHCloudCoreConn))
            {
                var sql = $@"INSERT INTO [dbo].[Gazette]
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
                foreach (GazetteRecord record in gazette.Record)
                {
                    con.Execute(sql, record);
                }
            }
        }
        public void CrawledCreate(string crawled)
        {
            using (var con = new SqlConnection(this.ESHCloudCoreConn))
            {
                var sql = $@"INSERT INTO [dbo].[GazetteCrawled]
                               ([CrawledDate])
                         VALUES
                               (@CrawledDate)";
                con.Execute(sql, new { @CrawledDate = crawled });
            }
        }

    }
}
