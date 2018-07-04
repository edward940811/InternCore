using ESHCloud.Base.Repository;
using ESHCloud.Bulletine.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ESHCloud.Bulletine.Repository
{
    public class BulletioneRepository : BaseRepository, IBulletioneRepository
    {
        public IEnumerable<BulletineViewModel> GetAllEvent()
        {
            return new List<BulletineViewModel>();
        }
        public BulletineViewModel GetEvent(int id)
        {
            using (var con = new SqlConnection(this.ESHCloudsCoreConnectionString))
            {
            }
            return new BulletineViewModel();
        }

        public void CreateEvent()
        {

        }

        public void UpdateEvent(BulletineViewModel model)
        {

        }

        public void DeleteEvent(int id)
        {
            
        }
    }
}
