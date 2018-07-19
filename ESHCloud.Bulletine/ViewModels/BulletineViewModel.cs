using System;
using System.Collections.Generic;
using System.Text;

namespace ESHCloud.Bulletine.ViewModels
{
    public class BulletineViewModel
    {
        public int Id { get; set; }
        public string CompanyId { get; set; }
        public int ModuleId { get; set; }
        public string FileName { get; set; }
        public string EventName { get; set; }
        public string UserId { get; set; }
        public int SetTop { get; set; }
        public string EventType { get; set; }
        public string EventDesc { get; set; }
        public DateTime EventDate { get; set; }
        public Boolean NotifyType { get; set; }
        public Boolean NotifyMail { get; set; }
        public BulletineMailViewModel Mail { get; set; }
        public List<byte[]> Files { get; set;}
        public int Status { get; set; }
    }
}
