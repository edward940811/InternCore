using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using LawKing.Entity.Enums;

namespace LawKing.Entity.ViewModels
{
    /// <summary>
    /// 法規VM
    /// </summary>
    public class LawInfoVM
    {
        /// <summary>
        /// 法規編號
        /// </summary>
        public decimal LawNo { get; set; }

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
        /// 法規名稱
        /// </summary>
        public string LawName { get; set; }

        /// <summary>
        /// 法規連結
        /// </summary>
        public string LawUrl { get; set; }

        /// <summary>
        /// 發佈日期
        /// </summary>
        public DateTime? PDate { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? MDate { get; set; }

        /// <summary>
        /// 修訂類型(M修訂A發佈D廢除)
        /// </summary>
        public ModifyType ModifyType { get; set; }

        /// <summary>
        /// 修訂日期
        /// </summary>
        public DateTime? ModifyDate { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string ModifyMemo { get; set; }

        /// <summary>
        /// 最愛Id
        /// </summary>
        public int? FavoriteLawInfoId { get; set; }

        /// <summary>
        /// 清單Id
        /// </summary>
        public int? ShareLawInfoId { get; set; }

        /// <summary>
        /// 版次
        /// </summary>
        public string DBVersion { get; set; }

        /// <summary>
        /// 資料總筆數
        /// </summary>
        [IgnoreDataMember]
        public int TotalRecords { get; set; }
    }
}
