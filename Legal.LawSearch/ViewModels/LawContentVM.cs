using Legal.LawSearch.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;

namespace Legal.LawSearch.ViewModels
{
 
    public class LawContentVM
    {
        /// <summary>
        /// 法規編號
        /// </summary>
        public decimal LawNo { get; set; }

        /// <summary>
        /// 法條編號
        /// </summary>
        public decimal LCNo { get; set; }

        /// <summary>
        /// 法規名稱
        /// </summary>
        public string LawName { get; set; }

        /// <summary>
        /// 法規資料庫
        /// </summary>
        public string BType { get; set; }

        /// <summary>
        /// 法規分類
        /// </summary>
        public string MType { get; set; }

        /// <summary>
        /// 條次
        /// </summary>
        public string LCArticle { get; set; }

        private string _LCHtml;

        /// <summary>
        /// 條文內容
        /// </summary>
        public string LCHtml
        {
            get { return Regex.Replace(_LCHtml, @"(?i)<img[^>]*>", String.Empty); }
            set { _LCHtml = value; }
        }

        /// <summary>
        /// 更新前內容
        /// </summary>
        public string LCNow { get; set; }

        /// <summary>
        /// 更新後內容
        /// </summary>
        public string LCBefore { get; set; }

        /// <summary>
        /// 修訂類型
        /// </summary>
        public ModifyType ModifyType { get; set; }

        /// <summary>
        /// 發佈日期
        /// </summary>
        public DateTime? PDate { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? MDate { get; set; }

        /// <summary>
        /// 資料總筆數
        /// </summary>
        [IgnoreDataMember]
        public int TotalRecords { get; set; }
    }
    
}
