using ESHCloud.Bulletine.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using WS.Models.Enum;
using ESHCloud.Base.Repository;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace ESHCloud.Bulletine.Services
{
    public class BulletineService : BaseRepository, IBulletineService
    {
        public BulletineService()
        {

        }
        public IEnumerable<BulletineViewModel> GetAllEvent(ESHCloudModule module)
        {
            using (var con = new SqlConnection(this.ESHCloudCoreConn))
            {
                List<BulletineViewModel> Bulletines = new List<BulletineViewModel>();
                var sql = $@"Select * From [esh_core].[dbo].[Bulletine]
                                WHERE Status = 1 AND ModuleId = @ModuleId
                                ORDER BY setTop DESC, Id ASC;";
                Bulletines = con.Query<BulletineViewModel>(sql, new { @ModuleId = (int)module }).ToList();

                
                

                return Bulletines;
            }
        }
        public BulletineViewModel GetEvent(ESHCloudModule module, int id)
        {
            using (var con = new SqlConnection(this.ESHCloudCoreConn))
            {
                var sql = $@"Select * From [esh_core].[dbo].[Bulletine]
                                WHERE Status = 1 AND Id = @Id AND ModuleId = @ModuleId
                                ORDER BY setTop DESC, Id ASC;";

                // TDOO:取得mail提醒的資訊
                var model = con.Query<BulletineViewModel>(sql, new { @Id = id, @ModuleId = (int)module }).FirstOrDefault();
                if(model != null)
                {
                    model.Mail = null;
                }
                return model;
            }
        }
        public void CreateEvent(BulletineViewModel model)
        {
            using (var con = new SqlConnection(this.ESHCloudCoreConn))
            {
                var sql = $@"INSERT INTO [dbo].[Bulletine]           
                                ([CompanyId]
                                ,[EventName]
                                ,[EventDesc]
                                ,[FileName]
                                ,[SetTop]
                                ,[EventType]
                                ,[EventDate]
                                ,[ModuleId])
                            VALUES
                                (@CompanyId,
                                @EventName,
                                @EventDesc,
                                @FileName,
                                @SetTop,
                                @EventType,
                                @EventDate,
                                @ModuleId)";
                con.Execute(sql, model);
            }
        }
        public void UpdateEvent(BulletineViewModel model)
        {
            using (var con = new SqlConnection(this.ESHCloudCoreConn))
            {
                var sql = $@"UPDATE [dbo].[Bulletine]
                             SET 
                                [CompanyId] = @CompanyId
                                ,[EventName] = @EventName
                                ,[EventDesc] = @EventDesc
                                ,[FileName] = @FileName
                                ,[SetTop] = @SetTop
                                ,[EventType] = @EventType
                                ,[EventDate] = @EventDate
                                ,[ModuleId] = @ModuleId
                                ,[NotifyType] = @NotifyType
                                ,[NotifyMail] = @NotifyMail
                            WHERE Id = @Id";
                con.Execute(sql, model);
            }
        }
        public void DeleteEvent(int id)
        {
            using (var con = new SqlConnection(this.ESHCloudCoreConn))
            {
                var sql = $@"UPDATE [dbo].[Bulletine]
                            SET [Status] = @Status
                            WHERE Id = @Id";
                con.Execute(sql, new
                {
                    Id = id,
                    Status = 0
                });
            }
        }
    }

}
