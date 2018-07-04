using System.Collections.Generic;
using ESHCloud.Bulletine.ViewModels;

namespace ESHCloud.Bulletine.Repository
{
    public interface IBulletioneRepository
    {
        void CreateEvent();
        void DeleteEvent(int id);
        IEnumerable<BulletineViewModel> GetAllEvent();
        BulletineViewModel GetEvent(int id);
        void UpdateEvent(BulletineViewModel model);
    }
}