using System;
using System.Collections.Generic;
using System.Text;
using ESHCloud.Bulletine.ViewModels;
using ESHCloud.Bulletine.Services;

namespace ESHCloud.Bulletine
{
    public class BulletineClass
    {
        private BulletineService _service { get;set;}
        public BulletineClass()
        {
            _service = new BulletineService();
        }

        public IEnumerable<BulletineViewModel> GetAll()
        {
            return _service.GetAllEvent();
        }
        public string Create(BulletineViewModel model)
        {   
            _service.CreateEvent(model);
            return "success";
        }
        public string Update(BulletineViewModel model)
        {
            _service.UpdateEvent(model);
            return "success";
        }
        public string Delete(int id)
        {
            _service.DeleteEvent(id);
            return "success";
        }
    }
}
