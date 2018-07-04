using System;
using System.Collections.Generic;
using System.Text;
using ESHCloud.Bulletine.ViewModels;

namespace ESHCloud.Bulletine.Services
{
    interface IBulletineService
    {
        void CreateEvent(BulletineViewModel model);
        void DeleteEvent(int id);
        IEnumerable<BulletineViewModel> GetAllEvent();
        BulletineViewModel GetEvent(int id);
        void UpdateEvent(BulletineViewModel model);
    }
}
