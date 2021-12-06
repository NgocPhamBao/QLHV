using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLHV.Models.ViewModels.CapMatKhau
{
    public class CapMatKhauView
    {
        public string MaHV { get; set; }

        public string TenHV { get; set; }

        public DateTime NgaySinh { get; set; }

        public string TenLHV { get; set; }

        public string TenDV { get; set; }

        public string TenCD { get; set; }
        public string MatKhau { get; set; }
        public string Anh { get; set; }
    }
}