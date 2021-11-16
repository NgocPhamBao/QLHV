using QLHV.Models.Context;
using QLHV.Models.ViewModels.CapMatKhau;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLHV.Models.Repository.CapMatKhau
{
    public class CapLaiMatKhauRepository
    {
        public static CapMatKhauView GetThongTin(string id)
        {
            using (var context = new MyContext())
            {
                HoiVien hv = context.HoiViens.Find(id);
                if (hv != null)
                {
                    CapMatKhauView cmk = new CapMatKhauView();
                    cmk.MaHV = hv.MaHV;
                    cmk.TenHV = hv.TenHV;
                    cmk.NgaySinh = hv.NgaySinh;
                    if (hv.MaLHV != null)
                    {
                        cmk.TenLHV = context.LoaiHoiViens.Find(hv.MaLHV).TenLHV;
                    }
                    if (hv.MaCD != null)
                    {
                        cmk.TenCD = context.ChucDanhs.Find(hv.MaCD).TenCD;
                    }
                    else cmk.TenCD = "_";
                    cmk.TenDV = hv.DonVi.TenDV;
                    cmk.Anh = hv.Anh;

                    //cmk.TenDN = context.CapLaiMatKhaus.Where(n => n.MaHV == hv.MaHV).FirstOrDefault().TenDN;
                    return cmk;
                }
                else return null;
            }
        }
        public static bool LuuMatKhauMoi(CapMatKhauView mk)
        {
            using (var context = new MyContext())
            {
                if (mk != null)
                {
                    var Ac = context.TaiKhoans.Where(n => n.MaHV == mk.MaHV).FirstOrDefault();
                    if (Ac != null)
                    {
                        CapLaiMatKhau cmk = new CapLaiMatKhau()
                        {
                            MaCLMK = context.CapLaiMatKhaus.Count() + 1,
                            MaHV = mk.MaHV,
                            EditTime = DateTime.Now,

                        };
                        context.CapLaiMatKhaus.Add(cmk);
                        Ac.MatKhau = mk.MatKhau;
                        context.SaveChanges();
                        return true;
                    }
                }

            }
            return false;
        }

    }
}