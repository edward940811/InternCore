using System;
using System.Collections.Generic;
using System.Text;
using ESHCloud.Bulletine.ViewModels;
using ESHCloud.Bulletine.Services;
using WS.Models.Enum;

namespace ESHCloud.Bulletine
{
    public class BulletineClass
    {
        private BulletineService bulletineService { get;set;}

        private BulletineMailService bulletineMailService { get; set; }
        public BulletineClass()
        {
            bulletineService = new BulletineService();
            bulletineMailService = new BulletineMailService();
        }

        /// <summary>
        /// 取得所有公佈欄事件
        /// </summary>
        /// <param name="moduleId">模組ID，請引用ESHCloud.Base元件</param>
        /// <returns></returns>
        public IEnumerable<BulletineViewModel> GetAll(ESHCloudModule moduleId)
        {
            return bulletineService.GetAllEvent(moduleId);
        }

        /// <summary>
        /// 取得公佈欄事件
        /// </summary>
        /// <param name="moduleId">模組ID，請引用ESHCloud.Base元件</param>
        /// <param name="id">事件ID</param>
        /// <returns></returns>
        public BulletineViewModel GetById(ESHCloudModule moduleId,int id)
        {
            return bulletineService.GetEvent(moduleId, id);
        }

        /// <summary>
        /// 新增公佈欄事件
        /// </summary>
        /// <returns></returns>
        public string Create(BulletineViewModel model)
        {   
            bulletineService.CreateEvent(model);
            return "success";
        }

        /// <summary>
        /// 更新公佈欄事件
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string Update(BulletineViewModel model)
        {
            bulletineService.UpdateEvent(model);
            return "success";
        }

        /// <summary>
        /// 刪除公佈欄事件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Delete(int id)
        {
            bulletineService.DeleteEvent(id);
            return "success";
        }

        /// <summary>
        /// 儲存郵件通知
        /// </summary>
        /// <returns></returns>
        public void SaveBulltineMail(BulletineViewModel model)
        {
            bulletineMailService.Save(model);
        }
    }
}
