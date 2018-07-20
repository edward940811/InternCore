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
            BulletineViewModel testmodel = new BulletineViewModel();
            testmodel.Id = 5;
            testmodel.Mail = new BulletineMailViewModel();
            testmodel.Mail.Id = 3;
            testmodel.Mail.BulletineId = 5;
            testmodel.Mail.MailBody = "i am mailbody";
            testmodel.Mail.MailTo = "edward@wishingsoft.com";
            testmodel.Mail.Subject = "testsubject2";
            //Act
            _service.SaveBulltineMail(testmodel);
            //Assert
            BulletineMailViewModel comparemodel = _mailservice.GetById(testmodel.Mail.BulletineId);
            Assert.AreEqual(comparemodel.MailBody,testmodel.Mail.MailBody);
        }
    }
}
