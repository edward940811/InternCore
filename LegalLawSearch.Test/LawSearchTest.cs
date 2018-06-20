using System;
using Legal.LawSearch;
using Legal.LawSearch.Conditions;
using Legal.LawSearch.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LegalLawSearch.Test
{
    [TestClass]
    public class LawSearchTest
    {
        LawSearch service = new LawSearch("jimmy", 1637);

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
            // Assert      
            Assert.AreNotEqual(0, totalRecords);
        }
    }
}
