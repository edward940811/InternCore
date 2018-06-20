using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legal.Models
{
    /// <summary>
    /// 分頁模組
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagingModel<T>
    {
        /// <summary>
        /// 總頁數
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// 第幾頁
        /// </summary>
        public int? PageIndex { get; set; }

        /// <summary>
        /// 資料總筆數
        /// </summary>
        public int TotalRecords { get; set; }

        /// <summary>
        /// 資料
        /// </summary>
        public T Data { get; set; }
    }
}
