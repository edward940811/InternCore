using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Legal.LawSearch.Entity
{
    /// <summary>
    /// 分頁條件
    /// </summary>
    public class PagingCondition
    {
        /// <summary>
        /// 一頁筆數
        /// </summary>
        public int? PageSize { get; set; } = 30;

        /// <summary>
        /// 第幾頁
        /// </summary>
        public int? PageIndex { get; set; } = 1;

        /// <summary>
        /// 排序欄位
        /// </summary>
        public string SortColumn { get; set; }

        /// <summary>
        /// 升降冪
        /// </summary>
        public string SortOrder { get; set; } = "ASC";
    }
}
