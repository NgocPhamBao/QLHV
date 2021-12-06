using QLHV.Models.Repository.CapMatKhau;
using QLHV.Models.ViewModels.CapMatKhau;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLHV.Common;
namespace QLHV.Controllers
{
    public class CapLaiMatKhauController : Controller
    {
        public UserLogin userlogin()
        {
            var user = (UserLogin)Session[CommonConstants.USER_SESSION];
            return user;
        }
 
        // GET: CapLaiMatKhau
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(CapMatKhauView cmk)
        {

            if (CapLaiMatKhauRepository.LuuMatKhauMoi(cmk) == true)
            {
                ViewBag.Message = "Luu mat khau thanh cong!";
                return View();
            }
            else
            {

                ViewBag.Message = "Luu mat khau that bai!";
                return View();
            }
        }
        [HttpPost]
        public ActionResult ThongTinHoiVien(string id)
        {
            if (id != "")
            {
                CapMatKhauView hv = CapLaiMatKhauRepository.GetThongTin(id);

                return View(hv);
            }
            return View();
        }
        [HttpGet]
        public ActionResult ThongTinHoiVien(CapMatKhauView hv)
        {
            return View(hv);
        }


    }
}