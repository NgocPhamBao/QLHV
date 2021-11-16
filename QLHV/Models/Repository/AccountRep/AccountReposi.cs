using QLHV.Models.Context;
using QLHV.Models.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QLHV.Models.Repository.AccountRep
{
    public class AccountReposi
    {
        public TaiKhoan GetLogin(string[] id)
        {
            try
            {
                using (var context = new MyContext())
                {
                    var TenDN = id[0];
                    var Ac = context.TaiKhoans.AsNoTracking().Where(x => x.TenDN == TenDN).Include("HoiVien").FirstOrDefault();
                    if (Ac == null) return null;
                    if (Ac.MatKhau == id[1])
                    {
                        var ACT = context.TaiKhoans.Find(TenDN);
                        ACT.EditTime = DateTime.Now;
                        context.SaveChanges();
                        return Ac;
                    }

                    else return null;
                }
            }
            catch
            {
                return null;
            }

        }
        public List<AccountView> ViewAc()
        {
            using (var context = new MyContext())
            {
               
                var L = context.Database.SqlQuery<AccountView>("proc_AccountView");
                var ListTKView = L.ToList();
                return ListTKView;
            }
        }
        public AccountViewItem ViewAcI(string TenDN)
        {
            using (var context = new MyContext())
            {
                var Ac = context.TaiKhoans.AsNoTracking().Where(x => x.TenDN == TenDN).Include("HoiVien").FirstOrDefault();
                //var Ac=AC.fi
                var AcI = new AccountViewItem();
                AcI.MaHV = Ac.MaHV;
                AcI.TenHV = Ac.HoiVien.TenHV;
                AcI.TenDN = Ac.TenDN;
                AcI.Khoa = Ac.Khoa;
                AcI.NgaySinh = Ac.HoiVien.NgaySinh.ToString("dd/MM/yyyy");
                AcI.Email = Ac.HoiVien.Email;
                AcI.SDT = Ac.HoiVien.SDT;
                return AcI;
            }
        }
        public bool isKeyAc(bool key, string TenDN)
        {
            using (var context = new MyContext())
            {

                var Ac = context.TaiKhoans.Find(TenDN);
                Ac.Khoa = key;
                context.SaveChanges();
                if (key) return true;
                else return false;
            }



        }

        public Dictionary<string, AccountRole> TaiKhoanHV()
        {
            using (var context = new MyContext())
            {
                //var ListTK = context.TaiKhoans.AsNoTracking().Include("HoiVien").ToList();
                var ListTKView = new Dictionary<string, AccountRole>();
                var L = context.Database.SqlQuery<AccountRole>("proc_DSQuyenTaiKhoan");
                var ListTK = L.ToList();
                int Dem = 0;
                foreach (var t in ListTK)
                {
                    Dem++;
                    if (t.Roles.Contains("HVPN"))
                    {
                        ListTKView.Add("HVPN" + Dem, t);
                        continue;
                    }
                    if (t.Roles.Contains("HVCD"))
                    {
                        ListTKView.Add("HVCD" + Dem, t);
                        continue;
                    }
                    if (t.Roles.Contains("BCH_PN"))
                    {
                        ListTKView.Add("BCH_PN" + Dem, t);
                        continue;
                    }
                    if (t.Roles.Contains("BCH_CD"))
                    {
                        ListTKView.Add("BCH_CD" + Dem, t);
                        continue;
                    }
                }

                return ListTKView;
            }
        }
    }
}