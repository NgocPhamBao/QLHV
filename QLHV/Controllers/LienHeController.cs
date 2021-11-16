using QLHV.Models.Repository.LienHe;
using QLHV.Models.ViewModels.LienHe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLHV.Common;
namespace QLHV.Controllers
{
    public class LienHeController : Controller
    {
        public UserLogin userlogin()
        {
            var user = (UserLogin)Session[CommonConstants.USER_SESSION];
            return user;
        }


        // GET: LienHe
        public ActionResult Index()
        {
            var list = LienHeRepository.GetLienHe();
            return View(list);
        }
    }
}