using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using HtmlAgilityPack;
using Legal.GazetteCrawler.Service;
using Legal.GazetteCrawler;
using Dapper;

namespace Legal.GazetteCrawler
{
    public class Crawler
    {

        ///<summary>
        ///爬取檔案url
        ///</summary>
        /// <param name="url">輸入存放檔案的網址 https://gazette.nat.gov.tw/egFront/openData03.do </param>
        /// <returns></returns>
        public List<Gazette> PageCrawl(string url)
        {
            GazetteService _service = new GazetteService();
            List<Gazette> result = new List<Gazette>();
            WebClient client = new WebClient();
            MemoryStream initialPageMs = new MemoryStream(client.DownloadData(url));
            HtmlDocument initdoc = new HtmlDocument();
            initdoc.Load(initialPageMs, Encoding.UTF8);
            //爬取所有連結
            HtmlNodeCollection hrefCollection = initdoc.DocumentNode.SelectNodes("/html/body/div[2]/div/div/article/div/div[2]/div/ul/li/a");
            List<string> hrefs = new List<string>();
            foreach (HtmlNode node in hrefCollection)
            {
                //node.Attributes[0] = href
                hrefs.Add("https://gazette.nat.gov.tw/egFront/" + HttpUtility.HtmlDecode(node.Attributes[0].Value));
            }
            //呼叫爬壓縮檔的function
            foreach (string link in hrefs)
            {
                //result.Add(FileCrawl(link));
                _service.Create(FileCrawl(link));
            }
            return result;
        }

        //爬取檔案資料
        private Gazette FileCrawl(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            var httpResponse = (HttpWebResponse)request.GetResponse();

            using (MemoryStream ms = new MemoryStream())
            {
                httpResponse.GetResponseStream().CopyTo(ms);
                return Decompress(ms);
            }
        }
        //解析XML
        private Gazette Decompress(MemoryStream filebyte)
        {
            ZipArchive archive = new ZipArchive(filebyte);
            Gazette DeserializeList;
            //取得xml檔案       
            int xmlindex = 0;
            for (int i = 0; i < archive.Entries.Count; i++)
            {
                if (archive.Entries[i].FullName.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                {
                    xmlindex = i;
                }
            }
            ZipArchiveEntry entry = archive.Entries[xmlindex];
            using (XmlReader reader = XmlReader.Create(entry.Open()))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Gazette), new XmlRootAttribute("Gazette"));
                DeserializeList = (Gazette)serializer.Deserialize(reader);
            }
            return DeserializeList;
        }
    }
}
