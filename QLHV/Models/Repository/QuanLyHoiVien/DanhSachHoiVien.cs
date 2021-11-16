using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLHV.Models.Context;
using QLHV.Models.ViewModels.QuanLyhoiVien;

namespace QLHV.Models.Repository.QuanLyHoiVien
{
    public class DanhSachHoiVien
    {        
        public List<DanhSachHV> DanhSachHV()
        {
            MyContext mycontext = new MyContext();
            List<DanhSachHV> DS_HV = mycontext.Database.SqlQuery<DanhSachHV>("EXEC proc_DanhSachHoiVien").ToList();
            foreach (var i in DS_HV)
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
            return DS_HV;
        }
    }
}