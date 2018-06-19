using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Legal.LawFile;
using Legal.Entity;
using Legal.LawFile.Service;

namespace Legal.LawFile.Test
{
    [TestClass]
    public class UnitTest1
    {
        LawFile service = new LawFile();
        [TestMethod]
        public void LegalLawFile_附檔搜尋應正確回傳()
        {
            LawSearchCondition condition = new LawSearchCondition();
            condition.AbolishedLaw = false;
            condition.Keyword = "火災";
            condition.PageIndex = 1;
            condition.PageSize = 30;
            condition.SortOrder = "asc";
            LawFileService lawFileService = new LawFileService("jimmy", 1637);
            // Act
            var result = service.GetLawFiles(condition, lawFileService);
            var totalRecords = result.Count == 0 ? 0 : result[0].TotalRecords;
            // Assert 
            Assert.AreNotEqual(0, totalRecords);

        }
    }
}
