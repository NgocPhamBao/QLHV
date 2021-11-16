using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLHV.Models.ViewModels.QuanLyhoiVien
{
    public class ThemMoiHoiVienPost
    {
        [Required(ErrorMessage = "Không được để trống!")]
        public string MaHV { get; set; }
        [Required(ErrorMessage = "Không được để trống!")]
        public string TenHV { get; set; }
        [Required(ErrorMessage = "Không được để trống!")]
        public bool GioiTinh { get; set; }
        [Required(ErrorMessage = "Không được để trống!")]
        public string DanToc { get; set; }
        [Required(ErrorMessage = "Không được để trống!")]
        public DateTime NgaySinh { get; set; }
        [Required(ErrorMessage = "Không được để trống!")]
        public int NamNhapNgu { get; set; }
        [Required(ErrorMessage = "Không được để trống!")]
        public int MaLHV { get; set; }
        [Required(ErrorMessage = "Không được để trống!")]
        public int MaDV { get; set; }
        [Required(ErrorMessage = "Không được để trống!")]
        public int BacTho { get; set; }
        [Required(ErrorMessage = "Không được để trống!")]
        public int MaLDV { get; set; }
        public int? MaHPN { get; set; }
        public int? MaHCD { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string Anh { get; set; }
        public int? MaVTCB { get; set; }
        public int? MaVTDU { get; set; }
        public int? MaVTDT { get; set; }
        [Required(ErrorMessage = "Không được để trống!")]
        public int MaTD { get; set; }
        public int? MaCD { get; set; }
        public int? MaDH { get; set; }
        [Required(ErrorMessage = "Không được để trống!")]
        public int MaCB { get; set; }
    }
}