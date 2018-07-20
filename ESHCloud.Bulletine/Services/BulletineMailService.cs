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
        public BulletineMailViewModel GetById(int bulletineID)
        {
            BulletineMailViewModel model = new BulletineMailViewModel();
            using (var con = new SqlConnection(this.ESHCloudCoreConn))
            {
                var getsql = $@"SELECT * FROM [dbo].[BulletineMail]
                             WHERE BulletineId = @BulletineId";
                model = con.Query<BulletineMailViewModel>(getsql, new { @BulletineId = bulletineID })
                    .FirstOrDefault();
            }
            return model;
        }
        public void Save(BulletineMailViewModel bulletinemodel)
        {
            //設定提醒信件
            using (var con = new SqlConnection(this.ESHCloudCoreConn))
            {
                // 找是否有設立過
                var model = GetById(bulletinemodel.Id);

                // 有的話更新
                if (model != null)
                {
                    var sql = $@"UPDATE [dbo].[BulletineMail]
                                SET 
                                    [MailTo] = @MailTo
                                    ,[Subject] = @Subject
                                    ,[MailBody] = @MailBody
                             WHERE Id = @Id";
                    con.Execute(sql, bulletinemodel);
                }
                else
                {
                    var sql = $@"INSERT INTO [dbo].[BulletineMail]
                                   ([BulletineId]
                                   ,[MailTo]
                                   ,[Subject]
                                   ,[MailBody])
                             VALUES
                                   (@BulletineId,
                                    @MailTo,
                                    @Subject,
                                    @MailBody)";
                    con.Execute(sql, new { bulletinemodel });
                }
            }
        }
    }
}
