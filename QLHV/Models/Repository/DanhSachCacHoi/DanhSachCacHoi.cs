using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLHV.Models.Context;
using QLHV.Models.Repository.QuanLyHoiVien;
using QLHV.Models.ViewModels.DanhSachCacHoi;
using QLHV.Models.ViewModels.QuanLyhoiVien;

namespace QLHV.Models.Repository.DanhSachCacHoi
{
    public class DanhSachCacHoi
    {
        MyContext mycontext = new MyContext();        
        public List<DanhSachHPN> DanhSachHPN()
        {
            List<DanhSachHPN> DS_HPN = mycontext.Database.SqlQuery<DanhSachHPN>("EXEC proc_DanhSachHPN").ToList();
            return DS_HPN;
        }        
        public List<DanhSachCD> DanhSachCD()
        {
            List<DanhSachCD> DS_CD = mycontext.Database.SqlQuery<DanhSachCD>("EXEC proc_DanhSachCD").ToList();
            return DS_CD;
        }
        public List<DanhSachHV> ChiTiet_HV(string MaHPN, string Hoi)
        {
            List<DanhSachHV> CT_HV = mycontext.Database.SqlQuery<DanhSachHV>("EXEC proc_ChiTiet" + Hoi +"_HV '" + MaHPN + "'").ToList();
            foreach (var i in CT_HV)
            {
                string CB;
                if (i.MaCB == 1) CB = "H1";
                else if (i.MaCB == 2) CB = "H2";
                else if (i.MaCB == 3) CB = "H3";
                else if (i.MaCB == 4) CB = "1/";
                else if (i.MaCB == 5) CB = "2/";
                else if (i.MaCB == 6) CB = "3/";
                else if (i.MaCB == 7) CB = "4/";
                else if (i.MaCB == 8) CB = "1//";
                else if (i.MaCB == 9) CB = "2//";
                else if (i.MaCB == 10) CB = "3//";
                else if (i.MaCB == 11) CB = "4//";
                else CB = mycontext.Database.SqlQuery<string>("SELECT TenCB FROM dbo.CapBac WHERE MaCB = " + i.MaCB).FirstOrDefault();
                i.TenLHV = CB + " " + i.TenLHV;
            }
            return CT_HV;
        }
        public List<BanChapHanh> ChiTiet_BCH(string MaHPN, string Hoi)
        {
            List<DB_BanChapHanh> DB_BCH = mycontext.Database.SqlQuery<DB_BanChapHanh>("EXEC proc_ChiTiet" + Hoi + "_BCH '" + MaHPN + "'").ToList();
            var CTHPN_BCH = new List<BanChapHanh>();
            var NhiemKyMax = DB_BCH.Max(t => t.NhiemKy);
            var NhiemKyMin = DB_BCH.Min(t => t.NhiemKy);
            var temp = new BanChapHanh();
            temp.PhoChuTich = new List<ViTri_BCH>();
            temp.UyVien = new List<ViTri_BCH>();
            foreach (var i in DB_BCH)
            {
                if (NhiemKyMin > NhiemKyMax) break;
                else if (i.NhiemKy != NhiemKyMax)
                {
                    temp.NamBatDau = i.NamBatDau;
                    temp.NamKetThuc = i.NamKetThuc;
                    temp.NhiemKy = i.NhiemKy;
                    CTHPN_BCH.Add(temp);                    
                    NhiemKyMax--;
                    temp = new BanChapHanh();
                    temp.PhoChuTich = new List<ViTri_BCH>();
                    temp.UyVien = new List<ViTri_BCH>();
                }
                if(i.NhiemKy == NhiemKyMax)
                {
                    if(i.ViTri == 1)
                    {
                        var temp1 = new ViTri_BCH();
                        temp1.MaHV = i.MaHV;
                        temp1.TenHV = i.TenHV;
                        temp.ChuTich = temp1;
                    }
                    else if(i.ViTri == 2)
                    {
                        var temp1 = new ViTri_BCH();
                        temp1.MaHV = i.MaHV;
                        temp1.TenHV = i.TenHV;
                        temp.PhoChuTich.Add(temp1);
                    }
                    else if(i.ViTri == 3)
                    {
                        var temp1 = new ViTri_BCH();
                        temp1.MaHV = i.MaHV;
                        temp1.TenHV = i.TenHV;
                        temp.UyVien.Add(temp1);
                    }
                }
                if(NhiemKyMax == NhiemKyMin && i == DB_BCH.Last()){
                    temp.NamBatDau = i.NamBatDau;
                    temp.NamKetThuc = i.NamKetThuc;
                    temp.NhiemKy = i.NhiemKy;
                    CTHPN_BCH.Add(temp);
                    NhiemKyMax--;
                    temp = new BanChapHanh();
                }
            }
            return CTHPN_BCH;
        }
    }
}