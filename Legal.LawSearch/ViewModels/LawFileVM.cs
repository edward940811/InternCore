using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Legal;
using Legal.Enums;

namespace Legal.LawSearch.ViewModel
{
    public class LawFileVM
    {
        /// <summary>
        /// 法規編號
        /// </summary>
        public decimal LawNo { get; set; }

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
        /// 附檔編號
        /// </summary>
        public decimal LFNo { get; set; }

        /// <summary>
        /// 附檔位置
        /// </summary>
        public string LFUrl { get; set; }

        /// <summary>
        /// 附檔名稱
        /// </summary>
        public string LFName { get; set; }

        /// <summary>
        /// 自訂附檔識別碼
        /// </summary>
        public string ContentKey { get; set; }

        /// <summary>
        /// 發佈日期
        /// </summary>
        public DateTime? PDate { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? MDate { get; set; }

        /// <summary>
        /// 修訂類型
        /// </summary>
        public ModifyType ModifyType { get; set; }

        /// <summary>
        /// 資料總筆數
        /// </summary>
        [IgnoreDataMember]
        public int TotalRecords { get; set; }
    }
}
