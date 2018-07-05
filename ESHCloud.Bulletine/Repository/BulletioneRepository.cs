using ESHCloud.Base.Repository;
using ESHCloud.Bulletine.ViewModels;
using System;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using System.Linq;
using System.Configuration;

namespace ESHCloud.Bulletine.Repository
{
    public class BulletioneRepository : BaseRepository, IBulletioneRepository
    {
        public IEnumerable<BulletineViewModel> GetAllEvent()
        {
            using (var con = new SqlConnection(this.ESHCloudsCoreConnectionString))
            {
                List<BulletineViewModel> Bulletines = new List<BulletineViewModel>();
                var sql = "Select * From [esh_core].[dbo].[Bulletine]";
                var dynamicParams = new DynamicParameters();
                Bulletines = con.Query<BulletineViewModel>(sql, dynamicParams).ToList();
                return Bulletines;
            }
        }
        public BulletineViewModel GetEvent(int id)
        {
            using (var con = new SqlConnection(this.ESHCloudsCoreConnectionString))
            {
            }
            return new BulletineViewModel();
        }

        public void CreateEvent(BulletineViewModel model)
        {
            using (var con = new SqlConnection(this.ESHCloudsCoreConnectionString))
            {
                var sql = $@"INSERT INTO [dbo].[Bulletine]           
                                ([CompanyId]
                                ,[Name]
                                ,[Description]
                                ,[FileName]
                                ,[setTop]
                                ,[Type]
                                ,[Date]
                                ,[Module])
                            VALUES
                                (@CompanyId,
                                @Name,
                                @Description,
                                @FileName,
                                @Top,
                                @Type,
                                @Date,
                                @Module)";
                con.Execute(sql, new {
                    CompanyId = model.CompanyId,
                    Name = model.Name,
                    Description = model.Description,
                    Type = model.Type,
                    Top = model.Top,
                    Module = model.Module,
                    Filename = model.FileName,
                    Notify = false,
                    Date = model.Date,
                    Status = 1
                });
            }
        }

        public void UpdateEvent(BulletineViewModel model)
        {
            using (var con = new SqlConnection(this.ESHCloudsCoreConnectionString))
            {
                var sql = $@"UPDATE [dbo].[Bulletine]
                            SET 
                                [CompanyId] = @CompanyId
                                ,[Name] = @Name
                                ,[Description] = @Description
                                ,[FileName] = @FileName
                                ,[setTop] = @Top
                                ,[Type] = @Type
                                ,[Date] = @Date
                                ,[Module] = @Module
                            WHERE Id = @Id";
                con.Execute(sql, new
                {
                    Id = model.Id,
                    CompanyId = model.CompanyId,
                    Name = model.Name,
                    Description = model.Description,
                    Type = model.Type,
                    Top = model.Top,
                    Module = model.Module,
                    Filename = model.FileName,
                    Date = model.Date
                });
            }
        }

        public void DeleteEvent(int id)
        {
            using (var con = new SqlConnection(this.ESHCloudsCoreConnectionString))
            {
                var sql = $@"UPDATE [dbo].[Bulletine]
                            SET
                                [Status] = @Status
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
