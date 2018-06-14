using System;
using LawKing.Entity;
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
            // Act
            var result = service.GetLawInfos(condition);
            var totalRecords = result.Count == 0 ? 0 : result[0].TotalRecords;
            //var act = service.PpmToMgm3(ppm, molecularWeight);
            // Assert
            var assert = 256;
            Assert.AreEqual(totalRecords, assert);
        }
    }
}
