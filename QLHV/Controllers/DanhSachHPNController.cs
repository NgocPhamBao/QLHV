using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLHV.Models.Context;
using QLHV.Models.Repository.DanhSachCacHoi;
using QLHV.Models.ViewModels.DanhSachCacHoi;
using QLHV.Common;

namespace QLHV.Controllers
{
    public class DanhSachHPNController : Controller
    {
        public UserLogin userlogin()
        {
            var user = (UserLogin)Session[CommonConstants.USER_SESSION];
            return user;
        }
 
        MyContext mycontext = new MyContext();
        // GET: DanhSachCacHoi
        [OutputCache(Location = System.Web.UI.OutputCacheLocation.Server, Duration = int.MaxValue)]
        public ActionResult DanhSachHPN()
        {
            DanhSachCacHoi DS = new DanhSachCacHoi();
            var DS_HPN = DS.DanhSachHPN();
            return View(DS_HPN);
        }
        public ActionResult ChiTietHPN(string id)
        {
            DanhSachCacHoi HPN = new DanhSachCacHoi();
            var CTHPN_HV = HPN.ChiTiet_HV(id, "HPN");
            ViewBag.BCH = HPN.ChiTiet_BCH(id,"HPN");
            ViewBag.TenHPN = mycontext.Database.SqlQuery<string>("SELECT TenHPN FROM dbo.HoiPhuNu WHERE MaHPN = '" + id + "'").FirstOrDefault();
            return View(CTHPN_HV);
        }
    }
}