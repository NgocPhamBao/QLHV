using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLHV.Models.ViewModels.Account
{
    public class AccountView
    {
        public int STT { get; set; }
        public string MaHV { get; set; }
        public string TenHV { get; set; }
        //public int Quyen { get; set; }
        public bool Khoa { get; set; }
        public DateTime EditTime { get; set; }
        public string TenDN { get; set; }

        public string Email { get; set; }
        public string SDT { get; set; }

    }
}