using System;
using LawKing.Entity;
using LawKing.Service;
using Legal.LawSearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LegalLawSearch.Test
{
    [TestClass]
    public class UnitTest1
    {
        LawSearch service = new LawSearch();
        [TestMethod]
        public void LegalLawSearch_法規搜尋應正確回傳()
        {
            //Formula service = new Formula();
            // Arrange
            LawSearchCondition condition = new LawSearchCondition();
            condition.Keyword = "一";
            condition.PageIndex = 1;
            condition.PageSize = 30;
            condition.AbolishedLaw = false;
            condition.SortOrder = "asc";
            LawInfoService lawInfoService = new LawInfoService("jimmy", 1637);
            // Act
            var result = service.GetLawInfos(condition,lawInfoService);
            var totalRecords = result.Count == 0 ? 0 : result[0].TotalRecords;
            // Assert      
            Assert.AreNotEqual(0, totalRecords);
        }
    }
}
