using System;
using System.Collections.Generic;
using System.Text;

namespace ESHCloud.Bulletine.ViewModels
{
    public class BulletineViewModel
    {
        public int Id { get; set; }
        public string CompanyId { get; set; }
        public string Module { get; set; }
        public string FileName { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public Boolean Top { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Boolean Notify { get; set; }
        public int Status { get; set; } 
    }
}
