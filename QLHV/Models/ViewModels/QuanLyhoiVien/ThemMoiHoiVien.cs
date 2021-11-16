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
        public string Anh { get; set; }
        public List<ChiBo> VTCB { get; set; }
        public List<DangUy> VTDU { get; set; }
        public List<ToChucDoanThe> VTDT { get; set; }
        public List<TrinhDo> TD { get; set; }
        public List<ChucDanh> CD { get; set; }
        public List<DanhHieu> DH { get; set; }
        public List<CapBac> CB { get; set; }
        public ThemMoiHoiVien()
        {
            LHV = mycontext.Database.SqlQuery<LoaiHoiVien>("SELECT MaLHV, TenLHV FROM dbo.LoaiHoiVien").ToList();
            DV = mycontext.Database.SqlQuery<DonVi>("SELECT MaDV, TenDV FROM dbo.DonVi").ToList();
            BacTho = new List<int>() { 0, 2, 3, 4, 5, 6, 7 };
            LDV = mycontext.Database.SqlQuery<LoaiDangVien>("SELECT MaLDV, TenLDV FROM dbo.LoaiDangVien").ToList();
            HPN = mycontext.Database.SqlQuery<HPN>("SELECT MaHPN, TenHPN FROM dbo.HoiPhuNu").ToList();
            HCD = mycontext.Database.SqlQuery<HCD>("SELECT MaHCD, TenHCD FROM dbo.HoiCongDoan").ToList();
            VTCB = mycontext.Database.SqlQuery<ChiBo>("SELECT MaVTCB, TenVTCB FROM dbo.ChiBo").ToList();
            VTDU = mycontext.Database.SqlQuery<DangUy>("SELECT MaVTDU, TenVTDU FROM dbo.DangUy").ToList();
            VTDT = mycontext.Database.SqlQuery<ToChucDoanThe>("SELECT MaVTDT, TenVTDT FROM dbo.ToChucDoanThe").ToList();
            TD = mycontext.Database.SqlQuery<TrinhDo>("SELECT MaTD, TenTD FROM dbo.TrinhDo").ToList();
            CD = mycontext.Database.SqlQuery<ChucDanh>("SELECT MaCD, TenCD FROM dbo.ChucDanh").ToList();
            DH = mycontext.Database.SqlQuery<DanhHieu>("SELECT MaDH, TenDH FROM dbo.DanhHieu").ToList();
            CB = mycontext.Database.SqlQuery<CapBac>("SELECT MaCB, TenCB FROM dbo.CapBac").ToList();
        }
    }
}