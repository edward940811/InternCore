using System;
using System.Collections.Generic;
using System.Text;

namespace ESHCloud.Tools.Model
{
    public class WetBulbGlobeTemperatureVM
    {
        public decimal NaturalBall { get; set; }
        public decimal BlackBall { get; set; }
        public decimal DryBall { get; set; }
        public bool Sunlight { get; set; }
        public decimal WetBulbGlobeTemperature { get; set; }
    }
}
