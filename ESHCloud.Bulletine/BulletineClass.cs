using System;
using System.Collections.Generic;
using System.Text;
using ESHCloud.Bulletine.ViewModels;
using ESHCloud.Bulletine.Services;
using ESHCloud.Base.Enum;

namespace ESHCloud.Bulletine
{
    public class BulletineClass
    {
        private BulletineService _service { get;set;}
        public BulletineClass()
        {
            _service = new BulletineService();
        }

        /// <summary>
        /// 取得所有公佈欄事件
        /// </summary>
        /// <param name="moduleId">模組ID，請引用ESHCloud.Base元件</param>
        /// <returns></returns>
        public IEnumerable<BulletineViewModel> GetAll(ESHCloudModule moduleId)
        {
            return _service.GetAllEvent(moduleId);
        }

        /// <summary>
        /// 取得公佈欄事件
        /// </summary>
        /// <param name="moduleId">模組ID，請引用ESHCloud.Base元件</param>
        /// <param name="id">事件ID</param>
        /// <returns></returns>
        public BulletineViewModel GetById(ESHCloudModule moduleId,int id)
        {
            return _service.GetEvent(moduleId, id);
        }

        /// <summary>
        /// 新增公佈欄事件
        /// </summary>
        /// <returns></returns>
        public string Create(BulletineViewModel model)
        {   
            _service.CreateEvent(model);
            return "success";
        }

        /// <summary>
        /// 更新公佈欄事件
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string Update(BulletineViewModel model)
        {
            _service.UpdateEvent(model);
            return "success";
        }

        /// <summary>
        /// 刪除公佈欄事件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Delete(int id)
        {
            _service.DeleteEvent(id);
            return "success";
        }
    }
}
