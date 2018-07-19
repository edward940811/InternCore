using System;
using System.Collections.Generic;
using System.Text;

namespace ESHCloud.Bulletine.ViewModels
{
    public class BulletineMailViewModel
    {
        public BulletineMailViewModel() {}
        public int Id { get; set; }

        // 是否要設定郵件通知
        public Boolean NotifyMail { get; set; }

        /// <summary>
        /// 發送類型 (1) 一次性 (2) 週期性
        /// </summary>
        public Boolean NotifyType { get; set; }

        /// <summary>
        /// 提醒日期 (一次性提醒or週期性提醒)
        /// </summary>
        public DateTime NofityDatetime { get;set;}

        /// <summary>
        /// 每月幾號 or 每周星期幾 (1-7)
        /// </summary>
        public int NotifyValue { get; set; }

        /// <summary>
        /// 收件者
        /// </summary>
        public string MailTo { get; set; }

        /// <summary>
        /// 主旨
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 郵件內容
        /// </summary>
        public string MailBody { get; set; }
        /// <summary>
        /// 布告欄ID
        /// </summary>
        public int BulletineId { get; set; }
    }
}
