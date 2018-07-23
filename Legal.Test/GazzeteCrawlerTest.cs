using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Legal.GazetteCrawler;

namespace Legal.Test
{
    [TestClass]
    public class GazzeteCrawlerTest
    {
        private Crawler service { get; set; }
        public GazzeteCrawlerTest()
        {
            service = new Crawler();
        }
        [TestMethod]
        public void 查看解壓縮內容()
        {
            string url = "https://gazette.nat.gov.tw/egFront/openData03.do";
            service.PageCrawl(url);
        }
    }
}
