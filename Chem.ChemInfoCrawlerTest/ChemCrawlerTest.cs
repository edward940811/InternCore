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
        public void 有正確查詢到()
        {
            //Arrange
            string keyword = "氫";
            //Act
            ChemInfo result = _service.GetChemInfo("https://csnn.osha.gov.tw/content/home/Substance_Query_Q.aspx",keyword);
            //Assert
            Assert.AreEqual(result.SearchField.Contains(keyword),true);
        }
    }
}
