using System;
using System.Collections.Generic;
using System.Text;

namespace Chem.ChemInfoCrawler.Model
{
    public class ChemInfo
    {
        public ChemInfo() { }
        public string SearchField { get; set; }
        public string Results { get; set; }
        public string Information { get; set; }
        public string Notes { get; set; }
    }
}
