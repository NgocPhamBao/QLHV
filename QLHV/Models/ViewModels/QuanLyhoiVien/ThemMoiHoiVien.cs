using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using QLHV.Models.Context;

namespace QLHV.Models.ViewModels.QuanLyhoiVien
{
    public class HPN
    {
        public int MaHPN { get; set; }
        public string TenHPN { get; set; }
    }
    public class HCD
    {
        public int MaHCD { get; set; }
        public string TenHCD { get; set; }
    }
    public class ThemMoiHoiVien
    {
        MyContext mycontext = new MyContext();
        public string MaHV { get; set; }
        public string TenHV { get; set; }
        public string GioiTinh { get; set; }
        public string DanToc { get; set; }
        public DateTime NgaySinh { get; set; }
        public int NamNhapNgu { get; set; }
        public List<LoaiHoiVien> LHV { get; set; }
        public List<DonVi> DV { get; set; }
        public List<int> BacTho { get; set; }
        public List<LoaiDangVien> LDV { get; set; }
        public List<HPN> HPN { get; set; }
        public List<HCD> HCD { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public List<ChiBo> VTCB { get; set; }
        public List<DangUy> VTDU { get; set; }
        public List<ToChucDoanThe> VTDT { get; set; }
        public List<TrinhDo> TD { get; set; }
        public List<ChucDanh> CD { get; set; }
        public List<DanhHieu> DH { get; set; }
        public List<CapBac> CB { get; set; }
        public ThemMoiHoiVien()
        {
            LHV = mycontext.LoaiHoiViens.ToList();
            DV = mycontext.DonVis.ToList();
            BacTho = new List<int>() { 0, 2, 3, 4, 5, 6, 7 };
            LDV = mycontext.LoaiDangViens.ToList();
            HPN = mycontext.Database.SqlQuery<HPN>("SELECT MaHPN, TenHPN FROM dbo.HoiPhuNu").ToList();
            HCD = mycontext.Database.SqlQuery<HCD>("SELECT MaHCD, TenHCD FROM dbo.HoiCongDoan").ToList();
            VTCB = mycontext.ChiBoes.ToList();
            VTDU = mycontext.DangUys.ToList();
            VTDT = mycontext.ToChucDoanThes.ToList();
            TD = mycontext.TrinhDoes.ToList();
            CD = mycontext.ChucDanhs.ToList();
            DH = mycontext.DanhHieux.ToList();
            CB = mycontext.CapBacs.ToList();
        }
    }
}