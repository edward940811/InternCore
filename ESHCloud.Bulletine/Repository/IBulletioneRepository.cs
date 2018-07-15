using System.Collections.Generic;
using ESHCloud.Base.Enum;
using ESHCloud.Bulletine.ViewModels;

namespace ESHCloud.Bulletine.Repository
{
    public interface IBulletioneRepository
    {
        void CreateEvent(BulletineViewModel model);
        void DeleteEvent(int id);
        IEnumerable<BulletineViewModel> GetAllEvent(ESHCloudModule module);
        BulletineViewModel GetEvent(ESHCloudModule module, int id);
        void UpdateEvent(BulletineViewModel model);
    }
}