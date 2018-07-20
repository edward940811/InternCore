using ESHCloud.Bulletine;
using ESHCloud.Bulletine.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ESHCloud.Base.Enum;

namespace ESHCloud.Test.Bulletine
{
    [TestClass]
    public class BulletineTest
    {
        private BulletineClass _service { get; set; }

        public BulletineTest()
        {
            _service = new BulletineClass();
        }

        [TestMethod]
        public void GetAll()
        {
            IEnumerable<BulletineViewModel> List;
            List = _service.GetAll(ESHCloudModule.Legal);
            Assert.AreNotEqual(List, null);
        }

        [TestMethod]
        public void GetById()
        {
            var model = _service.GetById(ESHCloudModule.Legal,1);
            Assert.AreNotEqual(model, null);
        }

        [TestMethod]
        public void Create()
        {
            //Arrange         
            BulletineViewModel model = new BulletineViewModel
            {
                CompanyId = "FromTest",
                EventDesc = "FromTest",
                SetTop = 1,
                EventType = "FromTest",
                EventDate = DateTime.Now,
                ModuleId = (int)ESHCloudModule.Legal,
            };
            //檔案上傳中心待定
            //byte[] bytes;
            //FileStream file = new FileStream("C:/Users/wish/Documents/script.sql", FileMode.Open, FileAccess.Read);
            //bytes = new byte[file.Length];
            //file.Read(bytes, 0, (int)file.Length);
            //model.Files.Add(bytes);
            //file.Close();
            //Act
            string result = _service.Create(model);
            //Assert
            Assert.AreNotEqual(result, null);
        }

        [TestMethod]
        public void Update()
        {
            //Arrange
            BulletineViewModel model = new BulletineViewModel
            {
                Id = 3,
                CompanyId = "FromTest",
                EventDesc = "FromTest",
                SetTop = 1,
                EventType = "FromTest",
                EventDate = DateTime.Now,
                NotifyMail = false,
                NotifyEvent = false,
                NotifyType = 1,
                NofityDatetime = DateTime.Today,
                NotifyValue = 6,
                ModuleId = (int)ESHCloudModule.Legal,
            };
            //Act
            string result = _service.Update(model);
            //Assert
            Assert.AreNotEqual(result, null);
        }

        [TestMethod]
        public void Delete()
        {
            //Arrange
            int id = 3;
            //Act
            string result = _service.Delete(id);
            //Assert
            Assert.AreNotEqual(result, null);
        }
    }
}
