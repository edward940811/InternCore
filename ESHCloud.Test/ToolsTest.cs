using System;
using ESHCloud.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ESHCloud.Test
{
    [TestClass]
    public class ToolsTest
    {
        [TestMethod]
        public void ESHCloudTools_濃度換算應正確回傳()
        {
            Formula service = new Formula();
            // Arrange
            decimal ppm = 50;
            decimal molecularWeight = 20;
            // Act
            var act = service.PpmToMgm3(ppm, molecularWeight);
            // Assert
            var assert = Convert.ToDecimal(40.90);

            Assert.AreEqual<decimal>(act, assert);
        }
    }

     
}
