using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLHV.Common;
using QLHV.Models.Context;
using QLHV.Models.Repository.DanhSachCacHoi;

namespace QLHV.Controllers
{
    public class DanhSachCDController : Controller
    {
        public UserLogin user()
        {
            var user = (UserLogin)Session[CommonConstants.USER_SESSION];
            return user;
        }
        // GET: DanhSachCD
        [OutputCache(Location = System.Web.UI.OutputCacheLocation.Server, Duration = int.MaxValue)]
        public ActionResult DanhSachCD()
        {
            DanhSachCacHoi DS = new DanhSachCacHoi();
            var DS_CD = DS.DanhSachCD();
            return View(DS_CD);
        }
        [OutputCache(Location = System.Web.UI.OutputCacheLocation.Server, Duration = 60, VaryByParam = "id")]
        public ActionResult ChiTietCD(string id)
        {
            
            MyContext mycontext = new MyContext();
            DanhSachCacHoi CD = new DanhSachCacHoi();
            var CTCD_HV = CD.ChiTiet_HV(id, "HCD");
            ViewBag.BCH = CD.ChiTiet_BCH(id,"HCD");
            ViewBag.TenCD = mycontext.Database.SqlQuery<string>("SELECT TenHCD FROM dbo.HoiCongDoan WHERE MaHCD = '" + id + "'").FirstOrDefault();
            return View(CTCD_HV);
        }
    }
}