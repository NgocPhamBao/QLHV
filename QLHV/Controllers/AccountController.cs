using QLHV.Common;
using QLHV.Models.ViewModels.Account;
using QLHV.Models.Repository.AccountRep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLHV.Controllers
{
    public class AccountController : Controller
    {
        public UserLogin userlogin()
        {
            var user = (UserLogin)Session[CommonConstants.USER_SESSION];
            return user;
        }
        // GET: Account
        public ActionResult Index()
        {
            
                var Ac = new AccountReposi();
                var models = Ac.ViewAc();
                return View(models);
            
        }
        [HttpPost]
        public ActionResult UpdateItem(string[] id)
        {
            try
            {
                var Ac = new AccountReposi();
                if (Ac.isKeyAc(bool.Parse(id[1]), id[0]))
                    TempData["notice"] = "Khóa tài khoản thành công";
                if (!Ac.isKeyAc(bool.Parse(id[1]), id[0]))
                    TempData["notice"] = "Bỏ khóa tài khoản thành công";
            }
            catch
            {
                TempData["notice"] = "Cập nhật không thành công";
            }
            var AC = new AccountReposi();
            var models = AC.ViewAc();
            return RedirectToAction("Index", models);

        }

        public ActionResult DanhSachTaiKhoan()
        {

            var Ac = new AccountReposi();
            var models = Ac.TaiKhoanHV();
            List<AccountRole> BCH_PN = new List<AccountRole>();
            List<AccountRole> BCH_CD = new List<AccountRole>();
            List<AccountRole> HVPN = new List<AccountRole>();
            List<AccountRole> HVCD = new List<AccountRole>();
            foreach (var t in models)
            {
                if (t.Key.Contains("BCH_PN"))
                {
                    BCH_PN.Add(t.Value);
                    continue;
                }
                if (t.Key.Contains("BCH_CD"))
                {
                    BCH_CD.Add(t.Value);
                    continue;
                }
                if (t.Key.Contains("HVPN"))
                {
                    HVPN.Add(t.Value);
                    continue;
                }
                if (t.Key.Contains("HVCD"))
                {
                    HVCD.Add(t.Value);
                    continue;
                }
            }
            ViewBag.TaiKhoanBCH_PN = BCH_PN;
            ViewBag.TaiKhoanBCH_CD = BCH_CD;
            ViewBag.TaiKhoanHVPN = HVPN;
            ViewBag.TaiKhoanHVCD = HVCD;
            //ViewBag.DsNhomQuyen = Ac.DsNhomQuyen();
            return View();

        }
        [HttpPost]
        public ActionResult UpdateRole(string[] id)
        {
            try
            {
                if(id.Length<=1)
                {
                    TempData["notice"] = "Cấp Quyền hội viên không được để trống";
                }
                else if (id.Length == 1)
                {
                    if(id[1]=="admin")
                        TempData["notice"] = "Cấp quyền học viện thành công";
                    //else if(id[1]=="HVPN")
                }
                else
                {

                }
            }
            catch
            {
                TempData["notice"] = "Cập nhật không thành công";
            }

            return RedirectToAction("DanhSachTaiKhoan");
        }


    }
}