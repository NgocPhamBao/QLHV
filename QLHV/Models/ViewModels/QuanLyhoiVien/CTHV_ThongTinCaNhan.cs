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
          public List<LoaiHoiVien> TenLHV { get; set; }
          public List<DonVi> TenDV { get; set; }
          public List<int> BacTho { get; set; }
          public List<LoaiDangVien> TenLDV { get; set; }
          public List<HoiPhuNu> TenHPN { get; set; }
          public List<string> TenCD { get; set; }
          public string Email { get; set; }
          public string SDT { get; set; }
          public string Anh { get; set; }
          public List<ChiBo> TenVTCB { get; set; }
          public List<DangUy> TenVTDU { get; set; }
          public List<ToChucDoanThe> TenVTDT { get; set; }
          public CTHV_ThongTinCaNhan()
          {
               GioiTinh = new List<string>() { "Nữ", "Nam" };
               TenLHV = mycontext.Database.SqlQuery<LoaiHoiVien>("SELECT * FROM dbo.LoaiHoiVien").ToList();
               TenDV = mycontext.Database.SqlQuery<DonVi>("SELECT * FROM dbo.DonVi").ToList();
               BacTho = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
               TenLDV = mycontext.Database.SqlQuery<LoaiDangVien>("SELECT * FROM dbo.LoaiDangVien").ToList();
               TenHPN = mycontext.Database.SqlQuery<HoiPhuNu>("SELECT * FROM dbo.HoiPhuNu").ToList();
               //TenCD = mycontext.Database.SqlQuery<string>("SELECT TenCD FROM dbo.CongDoan").ToList();
               TenVTCB = mycontext.Database.SqlQuery<ChiBo>("SELECT * FROM dbo.ChiBo").ToList();
               TenVTDU = mycontext.Database.SqlQuery<DangUy>("SELECT * FROM dbo.DangUy").ToList();
               TenVTDT = mycontext.Database.SqlQuery<ToChucDoanThe>("SELECT * FROM dbo.ToChucDoanThe").ToList();
          }
     }
}