using ESHCloud.Bulletine;
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

        public BulletineMailTest()
        {
            _service = new BulletineClass();
        }

        [TestMethod]
        public void Save()
        {
            _service.SaveBulltineMail(new BulletineMailViewModel());
        }
    }
}
