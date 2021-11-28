using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLHV.Models.Context;
using QLHV.Models.Repository.QuanLyHoiVien;
using QLHV.Models.ViewModels.QuanLyhoiVien;

namespace QLHV.Models.ViewModels.QuanLyhoiVien
{
    public class CTHV_ThongTinCaNhan
    {
        MyContext mycontext = new MyContext();
        public string MaHV { get; set; }
        public string TenHV { get; set; }
        public List<string> GioiTinh { get; set; }
        public string DanToc { get; set; }
        public DateTime NgaySinh { get; set; }
        public int? NamNhapNgu { get; set; }
        public List<string> TenLHV { get; set; }
        public List<string> TenDV { get; set; }
        public List<int> BacTho { get; set; }
        public List<string> TenLDV { get; set; }
        public List<string> TenHPN { get; set; }
        public List<string> TenCD { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string Anh { get; set; }
        public List<string> TenVTCB { get; set; }
        public List<string> TenVTDU { get; set; }
        public List<string> TenVTDT { get; set; }
        public CTHV_ThongTinCaNhan()
        {
            GioiTinh = new List<string>() { "Nữ", "Nam" };
            TenLHV = mycontext.Database.SqlQuery<string>("SELECT TenLHV FROM dbo.LoaiHoiVien").ToList();
            TenDV = mycontext.Database.SqlQuery<string>("SELECT TenDV FROM dbo.DonVi").ToList();
            BacTho = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            TenLDV = mycontext.Database.SqlQuery<string>("SELECT TenLDV FROM dbo.LoaiDangVien").ToList();
            TenHPN = mycontext.Database.SqlQuery<string>("SELECT TenHPN FROM dbo.HoiPhuNu").ToList();
            //TenCD = mycontext.Database.SqlQuery<string>("SELECT TenCD FROM dbo.CongDoan").ToList();
            TenVTCB = mycontext.Database.SqlQuery<string>("SELECT TenVTCB FROM dbo.ChiBo").ToList();
            TenVTDU = mycontext.Database.SqlQuery<string>("SELECT TenVTDU FROM dbo.DangUy").ToList();
            TenVTDT = mycontext.Database.SqlQuery<string>("SELECT TenVTDT FROM dbo.ToChucDoanThe").ToList();
        }
    }
}