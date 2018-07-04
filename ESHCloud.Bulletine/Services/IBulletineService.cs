using System;
using System.Collections.Generic;
using System.Text;

namespace ESHCloud.Bulletine.Services
{
    interface IBulletineService
    {
        void CreateEvent();
        void DeleteEvent(int id);
        IEnumerable<BulletineViewModel> GetAllEvent();
        BulletineViewModel GetEvent(int id);
        void UpdateEvent(BulletineViewModel model);
    }
}
