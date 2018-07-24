using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Legal.GazetteCrawler;

namespace CrawlerFunction
{
    public static class Crawlerfunc
    {

        [FunctionName("Crawlerfunc")]
        public static void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
            Crawler service = new Crawler();
            string url = "https://gazette.nat.gov.tw/egFront/openData03.do";
            service.PageCrawl(url);
        }
}
}
