﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ESHCloud.Bulletine.ViewModels
{
    public class BulletineViewModel
    {
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string Module { get; set; }
        public string FileName { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public string Top { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public Boolean Notify { get; set; }
    }
}