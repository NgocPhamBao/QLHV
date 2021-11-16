using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLHV.Models.ViewModels.DanhSachCacHoi
{
    public class DB_BanChapHanh
    {
        public string MaHV { get; set; }
        public string TenHV { get; set; }
        public int ViTri { get; set; }

        public int NhiemKy { get; set; }

        public int? NamBatDau { get; set; }

        public int? NamKetThuc { get; set; }
    }
}