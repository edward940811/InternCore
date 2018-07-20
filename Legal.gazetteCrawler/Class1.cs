using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using Legal.GazetteCrawler;

namespace Legal.GazetteCrawler
{
    public class Crawler
    {
        //爬取檔案url
        public List<Gazette> PageCrawl(string url)
        {

        }
        //爬取檔案資料
        public Gazette FileCrawl(string url)
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
        public Gazette Decompress(MemoryStream filebyte)
        {
            ZipArchive archive = new ZipArchive(filebyte);
            Gazette DeserializeList;
            //取得第一個檔案
            ZipArchiveEntry entry = archive.Entries[0];
            using (Stream xmlstream = entry.Open())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Gazette), new XmlRootAttribute("Gazette"));
                DeserializeList = serializer.Deserialize(xmlstream) as Gazette;             
            }
            return DeserializeList;
        }
    }
}
