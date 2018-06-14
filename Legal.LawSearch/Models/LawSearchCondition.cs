using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawKing.Entity
{
    /// <summary>
    /// 法規(條/附檔)搜尋條件
    /// </summary>
    public class LawSearchCondition : PagingCondition
    {
        private string _Keyword = "";
        /// <summary>
        /// 法規資料庫
        /// </summary>
        public string BType { get; set; }

        /// <summary>
        /// 法規分類
        /// </summary>
        public string MType { get; set; }

        /// <summary>
        /// 法規位階
        /// </summary>
        public string SType { get; set; }

        /// <summary>
        /// 法規編號
        /// </summary>
        public List<decimal> LawNos { get; set; } = new List<decimal>();
        /// <summary>
        /// 法條編號
        /// </summary>
        public List<decimal> LCNos { get; set; } = new List<decimal>();
        /// <summary>
        /// 附檔編號
        /// </summary>
        public List<decimal> LFNos { get; set; } = new List<decimal>();

        /// <summary>
        /// 法規+法條編號
        /// </summary>
        public List<string> LCKeys { get; set; }

        /// <summary>
        /// 附檔編號
        /// </summary>
        public List<string> LFKeys { get; set; }

        /// <summary>
        /// 關鍵字(法規與法條內容)
        /// </summary>
        public string Keyword
        {
            get
            {
                if (!string.IsNullOrEmpty(_Keyword) &&  _Keyword.Length > 0  )
                {
                    return Encoding.UTF8.GetString(Encoding.Convert(Encoding.GetEncoding("big5"), Encoding.UTF8,
                        Encoding.GetEncoding("big5").GetBytes(_Keyword)));
                }
                else
                {
                    return string.Empty;
                }

            }
            set { _Keyword = value; }
        }

        /// <summary>
        /// 異動起日
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// 異動迄日
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 報表Id
        /// </summary>
        public int? ReportId { get; set; }

        /// <summary>
        /// 客製報表識別碼
        /// </summary>
        public int? InstanceCode { get; set; }
        /// <summary>
        /// 版本名稱
        /// </summary>
        public string DBVersion { get; set; }
        /// <summary>
        /// 是否顯示廢止法規
        /// </summary>
        public bool AbolishedLaw { get; set; }
    }
}
