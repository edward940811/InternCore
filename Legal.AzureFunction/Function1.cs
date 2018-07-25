using System;
using System.Configuration;
using Legal.GazetteCrawler;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;

namespace Legal.AzureFunction
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([TimerTrigger("*/1 * * * * *")]TimerInfo myTimer, TraceWriter log, ExecutionContext context)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(context.FunctionAppDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            Crawler service = new Crawler();
            string url = "https://gazette.nat.gov.tw/egFront/openData03.do";
            service.PageCrawl(url);
        }
    }
}
