using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESHCloud.Bulletine;
using ESHCloud.Bulletine.Services;
using ESHCloud.Bulletine.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ESHCloud.Test
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
                CompanyId = "jimmy",
                Description = "jimmy gone",
                Top = true,
                Type = "type1",
                Date = DateTime.Now,
                Module = "Chem",
            };
            //Act
            string result = _service.Create(model);
            //Assert
            Assert.AreNotEqual(result,null);
        }
        [TestMethod]
        public void Update()
        {
            //Arrange
            BulletineViewModel model = new BulletineViewModel
            {
                CompanyId = "jaja",
                Description = "jimmy stay",
                Top = true,
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
            int id = 2;
            //Act
            string result = _service.Delete(id);
            //Assert
            Assert.AreNotEqual(result, null);
        }
    }
}
