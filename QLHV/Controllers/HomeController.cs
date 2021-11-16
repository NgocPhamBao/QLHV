using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLHV.Common;
using QLHV.Models.ViewModels;
using QLHV.Models.Repository.AccountRep;
using QLHV.Models.Repository.QuanLyHoiVien;
using System.Data.SqlClient;
using QLHV.Models.Context;

namespace QLHV.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string[] model)
        {
            if(model[0]==""|| model[1] == "")
            {
                if(model[0] == "")
                    ModelState.AddModelError("errorUsername", "Tên đăng nhập không được để trống!");
                if (model[1] == "")
                    ModelState.AddModelError("errorPassword", "Mật khẩu không được để trống!");
                return View();
            }
            var Ac = new AccountReposi();
            var ACI = Ac.GetLogin(model);
            if (ACI == null)
            {
                ViewBag.Message = "Mật khẩu nhập chưa đúng!";
            }
            else if (ACI.Khoa)
            {
                ViewBag.Message = "Tài khoản bạn đã bị khóa!";
            }
            else
            {
                var user = new UserLogin();
                user.MaHV = ACI.MaHV;
                user.Name = ACI.HoiVien.TenHV;
                user.UserName = ACI.TenDN;
                user.Anh = ACI.HoiVien.Anh;
                user.MaCD = ACI.HoiVien.MaHCD;
                user.MaHPN = ACI.HoiVien.MaHPN;
                using (var context = new MyContext())
                {
                    SqlParameter[] idparam =
               {
                    new SqlParameter
                    {
                        ParameterName = "username", Value= ACI.TenDN
                    },
                };
                    var roles = context.Database.SqlQuery<string>("proc_quyen_nguoidung @username", idparam);
                    user.Roles = roles.ToList();
                }        
                Session.Add(CommonConstants.USER_SESSION, user);
                //ViewBag.user = ACI.HoiVien.TenHV;
                return View("Home");
            }
            //if(model[0]=="admin" && model[1] == "admin")
            //{
            //    var user = new UserLogin();
            //    user.MaHV = "5874850012";
            //    user.Name = "Nguyễn Thị Hà";
            //    user.UserName = "";
            //    user.Role_HPN = 3;
            //    user.Role_CD = 3;
            //    user.MaHPN = 3;
            //    user.MaCD = 3;
            //    Session.Add(CommonConstants.USER_SESSION, user);
            //    return View("Home");
            //}    

            return View();
        }
        //[CustomAuthorize(Roles ="BCH_CD")]
        public ActionResult Profile()
        {
            var user = (UserLogin)Session[CommonConstants.USER_SESSION];
            ChiTietHoiVien CTHV = new ChiTietHoiVien();
            var TTCN = CTHV.ThongTinCaNhan(user.MaHV);
            ViewBag.LSCB = CTHV.CapBac(user.MaHV);
            ViewBag.LSCD = CTHV.ChucDanh(user.MaHV);
            ViewBag.LSDH = CTHV.DanhHieu(user.MaHV);
            ViewBag.LSTD = CTHV.TrinhDo(user.MaHV);
            ViewBag.HCGD = CTHV.HoanCanhGiaDinh(user.MaHV);
            ViewBag.LDST = CTHV.LaoDongSangTao(user.MaHV);
            return View(TTCN);
            
        }
        public ActionResult Home()
        {
            return View();
        }
        

    }
}