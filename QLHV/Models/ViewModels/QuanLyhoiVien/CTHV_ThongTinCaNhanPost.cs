using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLHV.Models.ViewModels.QuanLyhoiVien
{
    public class CTHV_ThongTinCaNhanPost
    {
        public string MaHV { get; set; }
        public string TenHV { get; set; }
        public string GioiTinh { get; set; }
        public string DanToc { get; set; }
        public DateTime NgaySinh { get; set; }
        public int? NamNhapNgu { get; set; }
        public string TenLHV { get; set; }
        public string TenDV { get; set; }
        public short? BacTho { get; set; }
        public string TenLDV { get; set; }
        public string TenHPN { get; set; }  
        public string TenCD { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string Anh { get; set; }
        public string TenVTCB { get; set; }
        public string TenVTDU { get; set; }
        public string TenVTDT { get; set; }
    }
}