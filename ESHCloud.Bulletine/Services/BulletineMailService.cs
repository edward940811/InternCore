using Dapper;
using ESHCloud.Base.Repository;
using ESHCloud.Bulletine.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ESHCloud.Bulletine.Services
{
    public class BulletineMailService : BaseRepository, IBulletineMailService
    {
        public BulletineMailService() { }
        public BulletineMailViewModel GetById(int id)
        {
            BulletineMailViewModel model = new BulletineMailViewModel();
            using (var con = new SqlConnection(this.ESHCloudCoreConn))
            {
                //找是否有設立過
                int bulletineID = id;
                var getsql = $@"SELECT * FROM [dbo].[BulletineMail]
                             WHERE BulletineId = {bulletineID}";
                model = con.Query<BulletineMailViewModel>(getsql).FirstOrDefault();
            }
            return model;
        }
        public void Save(BulletineViewModel bulletinemodel)
        { 
            //設定提醒信件
            using (var con = new SqlConnection(this.ESHCloudCoreConn))
            {                  
                //找是否有設立過
                int bulletineID = bulletinemodel.Id;
                var model = GetById(bulletineID);
                //有的話更新
                if (model != null)
                {
                    var sql = $@"UPDATE [dbo].[BulletineMail]
                                SET 
                                    [MailTo] = @MailTo
                                    ,[Subject] = @Subject
                                    ,[MailBody] = @MailBody
                             WHERE Id = @Id";
                    con.Execute(sql, bulletinemodel.Mail);
                }
                //沒有的話建立 
                else
                {
                    var sql = $@"INSERT INTO [dbo].[BulletineMail]
                                   ([BulletineId]
                                   ,[MailTo]
                                   ,[Subject]
                                   ,[MailBody])
                             VALUES
                                   ({bulletineID},
                                    @MailTo,
                                    @Subject,
                                    @MailBody)";
                    con.Execute(sql, bulletinemodel.Mail);
                }
            }
        }
    }
}
