using System;
using System.Collections.Generic;
using System.Text;
using ESHCloud.Base.Enum;
using ESHCloud.Bulletine.ViewModels;

namespace ESHCloud.Bulletine.Services
{
    interface IBulletineService
    {
        void CreateEvent(BulletineViewModel model);
        void DeleteEvent(int id);
        IEnumerable<BulletineViewModel> GetAllEvent(ESHCloudModule module);
        BulletineViewModel GetEvent(ESHCloudModule module,int id);
        void UpdateEvent(BulletineViewModel model);
    }
}
