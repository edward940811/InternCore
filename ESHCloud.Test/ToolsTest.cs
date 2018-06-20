using ESHCloud.Tools;
using ESHCloud.Tools.Enum;
using ESHCloud.Tools.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ESHCloud.Test
{
    [TestClass]
    public class ToolsTest
    {
        private Formula service { get; set; }

        public ToolsTest()
        {
            service = new Formula();
        }

        [TestMethod]
        public void ESHCloudTools_失能傷害頻率計算應正確回傳()
        {
            var damagePpl = 100;
            var totalTime = 123;
            var act = service.FrequencyRate(damagePpl, totalTime);
            var assert = Convert.ToDecimal(813008.13);
            Assert.AreEqual(act, assert);
        }

        [TestMethod]
        public void ESHCloudTools_失能傷害嚴重率計算應正確回傳()
        {
            var damageDays = 7;
            var hours = 80;
            var act = service.SeverityRate(damageDays, hours);
            var assert = 87500;
            Assert.AreEqual(act, assert);
        }

        [TestMethod]
        public void ESHCloudTools_乾溼球換算應正確回傳()
        {
            WetBulbGlobeTemperatureVM newBulb = new WetBulbGlobeTemperatureVM();
            newBulb.NaturalBall = 100;
            newBulb.BlackBall = 60;
            newBulb.DryBall = 70;
            newBulb.Sunlight = true;

            var act = service.WetBulbGlobeTemperature(newBulb.NaturalBall, newBulb.BlackBall, newBulb.DryBall, newBulb.Sunlight);

            var assert = Convert.ToDecimal(89.0);
            Assert.AreEqual(act, assert);
        }

        [TestMethod]
        public void ESHCloudTools_綜合傷害指數應正確回傳()
        {
            var sr = 70;
            var fr = 80;
            var act = service.SRAndFRIndex(sr, fr);
            var assert = Convert.ToDecimal(2.36);
            Assert.AreEqual(act, assert);
        }

        [TestMethod]
        public void ESHCloudTools_濃度換算應正確回傳()
        {
            // Arrange
            decimal ppm = 50;
            decimal molecularWeight = 20;
            // Act
            var act = service.PpmToMgm3(ppm, molecularWeight);
            // Assert
            var assert = Convert.ToDecimal(40.90);

            Assert.AreEqual(act, assert);
        }

        [TestMethod]
        public void ESHCloudTools_壓力換算應正確回傳()
        {
            // Arrange
            PressureEnum pressureEnumAtm = PressureEnum.atm;
            decimal value = 50;
            // Act
            var act = service.PressureConvert(value, pressureEnumAtm);
            // Assert
            var assertatm = Convert.ToDecimal(50);
            var assertpsi = Convert.ToDecimal(735);
            var assertmmHg = Convert.ToDecimal(38000);
            var assertH20 = Convert.ToDecimal(20350);
            Assert.AreEqual(act.Atm, assertatm);
            Assert.AreEqual(act.Psi, assertpsi);
            Assert.AreEqual(act.MmHg, assertmmHg);
            Assert.AreEqual(act.InH2O, assertH20);
        }
    }
}