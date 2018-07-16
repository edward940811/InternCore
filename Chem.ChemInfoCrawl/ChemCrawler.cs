using HtmlAgilityPack;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Drawing.Imaging;
using Newtonsoft.Json.Linq;
using System.Collections.Specialized;
using ConfigLibrary;
using Microsoft.Extensions.Configuration;
using Chem.ChemInfoCrawler.Model;

namespace Chem.ChemInfoCrawler
{
    public class ChemCrawler
    {
        string sessionID = KeyConnectionFactory.sessionID;
        string viosionAPI = KeyConnectionFactory.visionAPI;

        //解圖片驗證碼
        public string GetCAPTCHA(Bitmap bmp)
        {
            //Google Vision API 在local端傳圖片必須轉base64 encoding         
            string base64;
            string Code = "";
       

            using (MemoryStream ms = new MemoryStream())
            {
                ImageFormat format = ImageFormat.Png;
                bmp.Save(ms, format);
                base64 = Convert.ToBase64String(ms.ToArray());
            }

            //request Google Vision API
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(viosionAPI);
            request.Method = "POST";
            request.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = $@"{{
                                  ""requests"":[
                                    {{
                                        ""image"":{{
                                            ""content"": ""{base64}""
                                        }},
                                      ""features"":[
                                        {{
                                          ""type"" : ""TEXT_DETECTION"",
                                          ""maxResults"" : 1
                                        }}
                                      ]
                                    }}
                                  ]
                                }}";
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            var httpResponse = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                JToken token = JObject.Parse(result);
                Code = ((string)token["responses"][0]["textAnnotations"][0]["description"]).Replace(" ", "").Replace("\n", "");
            }
            return Code;
        }

        //讀取化學物網頁
        public ChemInfo GetChemInfo(string urls, string keyword)
        {
            //傳送GET給驗證碼 此session就是用這個驗證碼圖片
            HttpWebRequest ImgRequest = (HttpWebRequest)WebRequest.Create("https://csnn.osha.gov.tw/common/CheckCode.aspx");
            ImgRequest.Method = "GET";
            ImgRequest.Headers.Add("Cookie", sessionID);
            ImgRequest.KeepAlive = true;
            ImgRequest.Host = "csnn.osha.gov.tw";
            ImgRequest.Referer = "https://csnn.osha.gov.tw/content/home/Substance_Query_Q.aspx";
            HttpWebResponse response = (HttpWebResponse)ImgRequest.GetResponse();
            var stream = response.GetResponseStream();
            Bitmap bmp = new Bitmap(stream);
            string code = GetCAPTCHA(bmp);

            //綁定sessionID 傳送GET給搜尋網頁
            HttpWebRequest InitRequest = (HttpWebRequest)WebRequest.Create("https://csnn.osha.gov.tw/content/home/Substance_Query_Q.aspx");
            HtmlDocument initdoc = new HtmlDocument();
            InitRequest.Headers.Add("Cookie", sessionID);
            HttpWebResponse InitResponse = (HttpWebResponse)InitRequest.GetResponse();
            var initstream = InitResponse.GetResponseStream();
            initdoc.Load(initstream);
            string ViewState = initdoc.GetElementbyId("__VIEWSTATE").GetAttributeValue("value", "");
            string EventVal = initdoc.GetElementbyId("__EVENTVALIDATION").GetAttributeValue("value", "");
            string ViewGen = initdoc.GetElementbyId("__VIEWSTATEGENERATOR").GetAttributeValue("value", "");


            //POST請求
            HttpWebRequest request = (HttpWebRequest)WebRequest.CreateHttp("https://csnn.osha.gov.tw/content/home/Substance_Query_Q.aspx");
            request.Method = "POST";
            request.Headers.Add("Cookie", sessionID);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Host = "csnn.osha.gov.tw";
            request.Referer = "https://csnn.osha.gov.tw/content/home/Substance_Query_Q.aspx";

            NameValueCollection outgoingQueryString = HttpUtility.ParseQueryString(String.Empty);
            outgoingQueryString.Add("ctl00$ContentPlaceHolder1$substance_Q1$txtKey", keyword);
            outgoingQueryString.Add("ctl00$ContentPlaceHolder1$txtCheckCode", code);
            outgoingQueryString.Add("__VIEWSTATEGENERATOR", ViewGen);
            outgoingQueryString.Add("__EVENTVALIDATION", EventVal);
            outgoingQueryString.Add("__VIEWSTATE", ViewState);
            outgoingQueryString.Add("ctl00$ContentPlaceHolder1$btnSearch.x", "10");
            outgoingQueryString.Add("ctl00$ContentPlaceHolder1$btnSearch.y", "13");

            string postdata = outgoingQueryString.ToString();
            request.ContentLength = postdata.Length;
            var data = Encoding.ASCII.GetBytes(postdata);
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(postdata);
            }
            HttpWebResponse postResponse = (HttpWebResponse)request.GetResponse();
            var a = postResponse.GetResponseStream();
            using (var reader = new StreamReader(a))
            {   //可以先看Post的結果
                string html = reader.ReadToEnd();
            }

            //GET 結果 Headers已簡化至最低需求 勿刪減
            HttpWebRequest SubmitRequest = (HttpWebRequest)WebRequest.Create("https://csnn.osha.gov.tw/content/home/Substance_Result.aspx?r=1");
            SubmitRequest.Method = "GET";
            SubmitRequest.Headers.Add("Cookie", sessionID);
            SubmitRequest.Referer = "https://csnn.osha.gov.tw/content/home/Substance_Query_Q.aspx";
            HttpWebResponse chemresponse = (HttpWebResponse)SubmitRequest.GetResponse();
            var responseStream = chemresponse.GetResponseStream();
            string responsehtml;
            using (var reader = new StreamReader(responseStream))
            {
                responsehtml = reader.ReadToEnd();
            }
            HtmlDocument responsedoc = new HtmlDocument();
            responsedoc.LoadHtml(responsehtml);
            ChemInfo chemInfo = new ChemInfo();
            chemInfo.SearchField = responsedoc.GetElementbyId("ctl00_ContentPlaceHolder1_Repeater1_ctl00_lblQuery").InnerText;
            chemInfo.Results = responsedoc.GetElementbyId("ctl00_ContentPlaceHolder1_Repeater1_ctl00_lblResult").InnerText;
            chemInfo.Information = responsedoc.GetElementbyId("ctl00_ContentPlaceHolder1_Repeater1_ctl00_lblNote").InnerText;
            chemInfo.Notes = responsedoc.GetElementbyId("ctl00_ContentPlaceHolder1_Repeater1_ctl00_lblClassify").InnerText;
            return chemInfo;
        }
    }
}
