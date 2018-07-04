using ESHCloud.Bulletine.Repository;
using ESHCloud.Bulletine.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
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

        public IEnumerable<BulletineViewModel> GetAllEvent()
        {
            return new BulletioneRepository().GetAllEvent();
        }

        public BulletineViewModel GetEvent(int id)
        {
            return new BulletioneRepository().GetEvent(id);
        }

        public void UpdateEvent(BulletineViewModel model)
        {
            new BulletioneRepository().UpdateEvent(model);
        }
    }

}
