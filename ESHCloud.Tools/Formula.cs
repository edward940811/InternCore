using ESHCloud.Tools.Enum;
using ESHCloud.Tools.Library;
using ESHCloud.Tools.Model;
using System;

namespace ESHCloud.Tools
{
    public class Formula
    {
        public int SeverityRate(int damageDays, int hours)
        {
            if (hours == 0) { return 0; }
            return Convert.ToInt32(Math.Floor((decimal)(damageDays * Math.Pow(10, 6) / hours)));
        }

        public decimal FrequencyRate(int damagePeople, int hours)
        {
            if (hours == 0) { return 0; }
            var result = (decimal)(damagePeople * Math.Pow(10, 6) / hours);

            return Math.Floor(result * 100) / 100;
        }

        public decimal SRAndFRIndex(int sr, decimal fr)
        {

            var result = Math.Sqrt(((double)(sr * fr) / 1000));

            return Math.Floor((decimal)result * 100) / 100;
        }

        public decimal WetBulbGlobeTemperature(decimal naturalBall, decimal blackBall, decimal dryBall, bool sunlight)
        {
            if (sunlight)
            {
                return ((decimal)0.7 * naturalBall) + ((decimal)0.2 * blackBall) + ((decimal)0.1 * dryBall);
            }
            return ((decimal)0.7 * naturalBall) + ((decimal)0.3 * blackBall);
        }

        /// <summary>
        /// 濃度換算
        /// (1) mg/m3 = (ppm×氣狀有害物之分子量(g/gmole) ÷24.45
        /// (2) ppm = mg/m3×24.45÷氣狀有害物之分子量(g/gmole)
        /// </summary>
        /// <param name="ppm">ppm</param>
        /// <param name="molecularWeight">氣狀有害物之分子量</param>
        /// <returns></returns>
        public decimal PpmToMgm3(decimal ppm, decimal molecularWeight)
        {
            return Math.Round(ppm * molecularWeight / (decimal)24.45, 2, MidpointRounding.AwayFromZero);
        }

        public decimal Mgm3ToPpm(decimal mgm3, decimal molecularWeight)
        {
            return Math.Round(mgm3 * (decimal)24.45 / molecularWeight, 2, MidpointRounding.AwayFromZero);
        }

        public Pressure PressureConvert(decimal value, PressureEnum pressureEnum)
        {
            IPressureConvert pressureConvert = PressureFactory.CreatePressureConvert(pressureEnum);

            return pressureConvert.Convert(value);
        }
    }
}
