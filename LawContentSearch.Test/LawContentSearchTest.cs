using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Legal.LawContentSearch;
using Legal.LawSearch.Entity;
using Legal.LawSearch.Service;

namespace Legal.LawContentSearch.Test
{

    [TestClass]
    public class UnitTest1
    {
        LawContentSearch service = new LawContentSearch();
        [TestMethod]
        public void TestMethod1()
        {           
            LawSearchCondition condition = new LawSearchCondition();
            condition.AbolishedLaw = false;
            condition.Keyword = "u";
            condition.PageIndex = 1;
            condition.PageSize = 30;
            condition.SortOrder = "asc";
            LawContentService lawInfoService = new LawContentService("jimmy", 1637);
            // Act
            var result = service.GetLawContents(condition, lawInfoService);
            var totalRecords = result.Count == 0 ? 0 : result[0].TotalRecords;
            // Assert 
            Assert.AreNotEqual(0, totalRecords);
        }
    }
}
