using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chem.ChemInfoCrawler;
using Chem.ChemInfoCrawler.Model;
using Microsoft.Extensions.Configuration;


namespace Chem.ChemInfoCrawlerTest
{
    [TestClass]
    public class ChemCrawlerTest
    {
        private ChemCrawler _service { get; set; }

        public ChemCrawlerTest()
        {
            _service = new ChemCrawler();
        }

        [TestMethod]
        [DataRow("��")]
        [DataRow("���")]
        public void �����T�d�ߨ�(string keyword)
        {
            //Act
            ChemInfo result = _service.GetChemInfo(keyword);
            //Assert
            Assert.AreEqual(result.SearchField.Contains(keyword), true);
        }
    }
}
