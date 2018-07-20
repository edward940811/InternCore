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
            string url = "https://gazette.nat.gov.tw/egFront/fileView.do?fileType=zipPath&fileName=50d6d4d2975f98d9cd8e80aef16f4f7f&attached&log=openData03&zipfile=107-07-02.zip";
            service.FileCrawl(url);
        }
    }
}
