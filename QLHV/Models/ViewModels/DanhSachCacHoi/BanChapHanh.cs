using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLHV.Models.ViewModels.DanhSachCacHoi
{
    public class ViTri_BCH
    {
        public string MaHV { get; set; }
        public string TenHV { get; set; }
    }
    public class BanChapHanh
    {
        public int NhiemKy { get; set; }

        public int? NamBatDau { get; set; }

        public int? NamKetThuc { get; set; }
        public ViTri_BCH ChuTich { get; set; }
        public List<ViTri_BCH> PhoChuTich { get; set; }
        public List<ViTri_BCH> UyVien { get; set; }

    }
}