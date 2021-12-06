using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLHV.Models.Context;
using QLHV.Models.Repository.QuanLyHoiVien;
using QLHV.Models.ViewModels.QuanLyhoiVien;

namespace QLHV.Models.ViewModels.QuanLyhoiVien
{
    public class GioiTinh
    {
        public bool MaGT;
        public string TenGT;
        public GioiTinh(bool MaGT, string TenGT)
        {
            this.MaGT = MaGT;
            this.TenGT = TenGT;
        }
    }
    public class CTHV_ThongTinCaNhan
     {
          MyContext mycontext = new MyContext();
          public string MaHV { get; set; }
          public string TenHV { get; set; }
          public List<GioiTinh> GT { get; set; }
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
          public CTHV_ThongTinCaNhan()
          {
               GT = new List<GioiTinh>();
               GT.Add(new GioiTinh(false, "Nữ"));
               GT.Add(new GioiTinh(true, "Nam"));
               LHV = mycontext.LoaiHoiViens.ToList();
               DV = mycontext.DonVis.ToList();
               BacTho = new List<int>() {0, 2, 3, 4, 5, 6, 7 };
               LDV = mycontext.LoaiDangViens.ToList();
               HPN = mycontext.Database.SqlQuery<HPN>("SELECT MaHPN, TenHPN FROM dbo.HoiPhuNu").ToList();
               HCD = mycontext.Database.SqlQuery<HCD>("SELECT MaHCD, TenHCD FROM HoiCongDoan").ToList();
               VTCB = mycontext.ChiBoes.ToList();
               VTDU = mycontext.DangUys.ToList();
               VTDT = mycontext.ToChucDoanThes.ToList();
          }
     }
}