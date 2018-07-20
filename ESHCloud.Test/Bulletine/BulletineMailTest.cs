using ESHCloud.Bulletine;
using ESHCloud.Bulletine.Services;
using ESHCloud.Bulletine.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESHCloud.Test.Bulletine
{
    [TestClass]
    public class BulletineMailTest
    {
        private BulletineClass _service { get; set; }
        private BulletineMailService _mailservice { get; set; }


        public BulletineMailTest()
        {
            _service = new BulletineClass();
            _mailservice = new BulletineMailService();
        }

        [TestMethod]
        public void Save()
        {
            //Arrange
            BulletineMailViewModel model = new BulletineMailViewModel();
            model.Id = 5;
            model = new BulletineMailViewModel();
            model.Id = 3;
            model.BulletineId = 5;
            model.MailBody = "i am mailbody";
            model.MailTo = "edward@wishingsoft.com";
            model.Subject = "testsubject2";
            //Act
            _service.SaveBulltineMail(model);
            //Assert
            BulletineMailViewModel comparemodel = _mailservice.GetById(model.BulletineId);
            Assert.AreEqual(comparemodel.MailBody,model.MailBody);
        }
    }
}
