<<<<<<< HEAD:ESHCloud.Test/BulletineTest.cs
﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESHCloud.Bulletine;
using ESHCloud.Bulletine.Services;
=======
﻿using ESHCloud.Bulletine;
>>>>>>> 51d048e02b92a113ea692687e744fd2a95e74d2a:ESHCloud.Test/Bulletine/BulletineTest.cs
using ESHCloud.Bulletine.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

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
            List = _service.GetAll();
            Assert.AreNotEqual(List, null);
        }
        [TestMethod]
        public void Create()
        {
            //Arrange         
            BulletineViewModel model = new BulletineViewModel
            {
                CompanyId = "jimmy3",
                Description = "jimmy gone",
                setTop = true,
                Type = "type1",
                Date = DateTime.Now,
                Module = "Chem",
            };
            //檔案上傳中心待定
            byte[] bytes;
            FileStream file = new FileStream("C:/Users/wish/Documents/script.sql", FileMode.Open, FileAccess.Read);
            bytes = new byte[file.Length];
            file.Read(bytes, 0, (int)file.Length);
            model.Files.Add(bytes);
            file.Close();
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
                CompanyId = "jaja",
                Description = "sfffay",
                setTop = true,
                Type = "type1",
                Date = DateTime.Now,
                Module = "Chem",
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
