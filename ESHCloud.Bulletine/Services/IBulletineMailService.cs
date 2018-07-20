using ESHCloud.Bulletine.ViewModels;

namespace ESHCloud.Bulletine.Services
{
    public interface IBulletineMailService
    {
        void Save(BulletineMailViewModel bulletinemodel);
    }
}