using ESHCloud.Bulletine.Repository;
using ESHCloud.Bulletine.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using ESHCloud.Base.Enum;

namespace ESHCloud.Bulletine.Services
{
    public class BulletineService : IBulletineService
    {
        public BulletineService()
        {

        }
        public void CreateEvent(BulletineViewModel model)
        {
            new BulletioneRepository().CreateEvent(model);
        }

        public void DeleteEvent(int id)
        {
            new BulletioneRepository().DeleteEvent(id);
        }

        public IEnumerable<BulletineViewModel> GetAllEvent(ESHCloudModule module)
        {
            return new BulletioneRepository().GetAllEvent(module);
        }

        public BulletineViewModel GetEvent(ESHCloudModule module, int id)
        {
            return new BulletioneRepository().GetEvent(module, id);
        }

        public void UpdateEvent(BulletineViewModel model)
        {
            new BulletioneRepository().UpdateEvent(model);
        }
    }

}
