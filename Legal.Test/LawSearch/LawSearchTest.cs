using Legal.LawSearch.Conditions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Legal.Test.LawSearch
{
    [TestClass]
    public class LawSearchTest : Startup
    {
        private Legal.LawSearch.LawSearch service { get; set; }

        public LawSearchTest()
        {
            service = new Legal.LawSearch.LawSearch("jimmy", 1637);
        }

        [TestMethod]
        public void LegalLawSearch_法規搜尋應正確回傳()
        {
            // Arrange
            LawSearchCondition condition = new LawSearchCondition
            {
                Keyword = "堆高機",
                PageIndex = 1,
                PageSize = 30,
                AbolishedLaw = false,
                SortOrder = "asc"
            };

            // Act
            var result = service.GetLawInfos(condition);

            var totalRecords = result.Count == 0 ? 0 : result[0].TotalRecords;
            // Assert      
            Assert.AreNotEqual(0, totalRecords);
        }


        [TestMethod]
        public void LegalLawSearch_法條搜尋應正確回傳()
        {
            LawSearchCondition condition = new LawSearchCondition
            {
                AbolishedLaw = false,
                Keyword = "堆高機",
                PageIndex = 1,
                PageSize = 30,
                SortOrder = "asc"
            };

            // Act
            var result = service.GetLawContents(condition);
            var totalRecords = result.Count == 0 ? 0 : result[0].TotalRecords;
            // Assert 
            Assert.AreNotEqual(0, totalRecords);
        }

        [TestMethod]
        public void LegalLawFile_附檔搜尋應正確回傳()
        {
            LawSearchCondition condition = new LawSearchCondition
            {
                AbolishedLaw = false,
                Keyword = "火災",
                PageIndex = 1,
                PageSize = 30,
                SortOrder = "asc"
            };

            // Act
            var result = service.GetLawFiles(condition);
            var totalRecords = result.Count == 0 ? 0 : result[0].TotalRecords;
            // Assert 
            Assert.AreNotEqual(0, totalRecords);

        }
    }
}
