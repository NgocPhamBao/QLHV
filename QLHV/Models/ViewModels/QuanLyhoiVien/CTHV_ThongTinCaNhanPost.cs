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
        public bool GioiTinh { get; set; }
        public string DanToc { get; set; }
        public DateTime NgaySinh { get; set; }
        public Int32? NamNhapNgu { get; set; }
        public Int32? MaLHV { get; set; }
        public Int32? MaDV { get; set; }
        public Int32? BacTho { get; set; }
        public Int32? MaLDV { get; set; }
        public Int32? MaHPN { get; set; }  
        public Int32? MaHCD { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string Anh { get; set; }
        public Int32? MaVTCB { get; set; }
        public Int32? MaVTDU { get; set; }
        public Int32? MaVTDT { get; set; }
    }
}