using QLHV.Handling;
using QLHV.Models.Context;
using QLHV.Models.Repository.BaoCaoRes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLHV.Common;

namespace QLHV.Controllers
{
    public class BaoCaoController : Controller
    {
       
        private MyContext _context = new MyContext();
        private int Nam = DateTime.Now.Year;
        private int Quy = (DateTime.Now.Month - 1) / 3 + 1;
        List<Field> fs = Field.listFields;
        string input = "BaoCao.doc";

        public UserLogin userlogin()
        {
            var user = (UserLogin)Session[CommonConstants.USER_SESSION];
            return user;
        }
        // GET: Report
        public ActionResult ReportYear()
        {
            var DSHoi = Hoi.getListHoi();
            /*List<BaoCao> listBC = _context.BaoCaos.Where(x => x.Quy == null).OrderByDescending(X => X.Nam).ToList();
            ViewBag.BaoCaos = listBC;*/
            ViewBag.DSHoi = DSHoi;
            return View();
        }

        public ActionResult ReportQuarter()
        {
            var DSHoi = Hoi.getListHoi();
            ViewBag.DSHoi = DSHoi;
            return View();
        }

        public ActionResult KhoBaoCaoNam()
        {
            var DSHoi = Hoi.getListHoi();
            /*List<BaoCao> listBC = _context.BaoCaos.Where(x => x.Quy == null).OrderByDescending(X => X.Nam).ToList();
            ViewBag.BaoCaos = listBC;*/
            ViewBag.DSHoi = DSHoi;
            return View();
        }
        public ActionResult KhoBaoCaoQuy()
        {
            var DSHoi = Hoi.getListHoi();
            ViewBag.DSHoi = DSHoi;
            return View();
        }

        //[HttpPost]
        //public int ChotBaoCao(Hoi hoi, bool theoNam)
        //{
        //    fs = Field.listFields;
        //    BaoCao bc = new BaoCao();
        //    int quyBC = theoNam == true ? 0 : (int)Quy;
        //    bc = _context.BaoCaos.Where(x => (x.TG == hoi.LoaiHoi && (x.MaHPN == hoi.Ma || x.MaCD == hoi.Ma) && x.Nam == Nam && x.Quy == quyBC)).FirstOrDefault();

        //    if (bc == null)
        //    {
        //        // thêm báo cáo năm
        //        bc = new BaoCao();
        //        bc.TG = hoi.LoaiHoi;
        //        if (hoi.LoaiHoi == 1) bc.MaHPN = hoi.Ma;
        //        else if (hoi.LoaiHoi == 2) bc.MaCD = hoi.Ma;
        //        bc.TenBaoCao = "";
        //        if (quyBC != null) bc.TenBaoCao = " QUÝ " + quyBC.ToString();
        //        bc.TenBaoCao = " NĂM " + Nam.ToString();
        //        bc.Nam = Nam;
        //        bc.Quy = quyBC;
        //        bc.NgayLuu = DateTime.Now;
        //        bc.MaNguoiLuu = null;
        //        bc.Khoa = true;
        //        _context.BaoCaos.Add(bc);     // thêm báo cáo vào kho
        //        _context.SaveChanges();
        //        bc = _context.BaoCaos.Where(x => (x.Nam == Nam && x.Quy == quyBC)).FirstOrDefault();

        //        // Thêm số liệu cho báo cáo
        //        foreach (Field f in fs)
        //        {
        //            if (f.type == "output")
        //            {
        //                SoLieu sl = new SoLieu();
        //                sl.SoLieu1 = int.Parse(f.value);
        //                sl.TenSoLieu = f.templatecode;
        //                sl.BaoCao = bc;
        //                _context.SoLieux.Add(sl);     // thêm số liệu của báo cáo
        //            }
        //            _context.SaveChanges();
        //        }
        //        return 1;
        //    }
        //    else
        //    {
        //        if (bc.Khoa == true) return 0;
        //        // Sửa báo cáo
        //        bc.NgayLuu = DateTime.Now;
        //        bc.Khoa = true;
        //        //_context.Entry(bc).State = System.Data.Entity.EntityState.Modified;
        //        _context.SaveChanges();

        //        // Sửa số liệu
        //        List<SoLieu> listSL = _context.SoLieux.Where(x => x.MaBaoCao == bc.MaBaoCao).ToList();

        //        if (listSL.Count == fs.Count - 3)
        //        {
        //            int i = 2;
        //            // sửa từng số liệu
        //            foreach (SoLieu sl in listSL)
        //            {
        //                i++;
        //                sl.SoLieu1 = int.Parse(fs[i].value);
        //                sl.TenSoLieu = fs[i].templatecode;
        //                sl.BaoCao = bc;
        //                //_context.Entry(sl).State = System.Data.Entity.EntityState.Modified;
        //            }
        //            _context.SaveChanges();
        //        }
        //        else
        //        {
        //            // xóa toan bộ số liệu của báo cáo và thêm lại
        //            foreach (SoLieu sl in listSL)
        //            {
        //                _context.SoLieux.Remove(sl);
        //            }
        //            _context.SaveChanges();

        //            foreach (Field f in fs)
        //            {
        //                if (f.type == "output")
        //                {
        //                    SoLieu sl = new SoLieu();
        //                    sl.SoLieu1 = int.Parse(f.value);
        //                    sl.TenSoLieu = f.templatecode;
        //                    sl.BaoCao = bc;
        //                    _context.SoLieux.Add(sl);
        //                }
        //            }
        //            _context.SaveChanges();
        //        }
        //        return 1;
        //    }
        //}

        //[HttpPost]
        //public int HuyChotBaoCao(int idBC)
        //{
        //    BaoCao bc = new BaoCao();
        //    bc = _context.BaoCaos.Where(x => x.MaBaoCao == idBC).FirstOrDefault();

        //    if (bc == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        if (bc.Khoa == false) return 0;
        //        // Sửa báo cáo
        //        bc.Khoa = false;
        //        _context.SaveChanges();
        //        return 1;
        //    }
        //}


        //[HttpPost]
        //public JsonResult GetBaoCaoByHoi(Hoi hoi, bool theoNam)
        //{
        //    List<BaoCaoRes> ListBCRes = BaoCaoRes.GetDSBaoCaoByHoi(hoi, theoNam);
        //    //var json = JsonConvert.SerializeObject(baoCaos);
        //    return Json(ListBCRes, JsonRequestBehavior.AllowGet);
        //}

        //[HttpGet]
        //public ActionResult PartialViewReport(int idBC)    // Load lại báo cáo theo quý có mã là idBC
        //{
        //    BaoCao baoCao = _context.BaoCaos.Where(x => x.MaBaoCao == idBC).FirstOrDefault();
        //    if (baoCao == null) return null;
        //    List<SoLieu> soLieus = _context.SoLieux.Where(x => x.MaBaoCao == idBC).ToList();
        //    int TG = baoCao.TG;
        //    fs = Field.List(TG);
        //    int n = fs.Count;
        //    int namBC = baoCao.Nam;
        //    int quyBC = baoCao.Quy;

        //    for (int i = 0; i < n; i++)
        //    {
        //        if (fs[i].type == "donvi")
        //        {
        //            if (baoCao.TG == 0) fs[i].value = "Học viện Kỹ thuật Quân sự";
        //            //else if (baoCao.TG == 1) fs[i].value = baoCao.HoiPhuNu.TenHPN != null ? baoCao.HoiPhuNu.TenHPN : "";
        //            //else if (baoCao.TG == 2) fs[i].value = baoCao.HoiCongDoan.TenHCD != null ? baoCao.CongDoan.TenCD : "";
        //        }
        //        else if (fs[i].type == "output")
        //        {
        //            int? count = 0;
        //            string fieldName = fs[i].templatecode;
        //            count = _context.SoLieux.Where(x => (x.TenSoLieu == fieldName && x.MaBaoCao == idBC)).Select(x => x.SoLieu1).FirstOrDefault();
        //            if (count == null) count = 0;
        //            fs[i].value = count.ToString();
        //        }
        //        else if (fs[i].type == "thangnam")
        //        {
        //            fs[i].value = baoCao.NgayLuu.ToString("MM/yyyy");
        //        }
        //        else if (fs[i].type == "tenthongke")
        //        {
        //            fs[i].value = baoCao.TenBaoCao;
        //        }
        //    }    // set giá trị cho fields từ số liệu trong database

        //    /*ViewBag.DocumentContent = genHtml();
        //    string dataDir = System.Web.HttpContext.Current.Server.MapPath(@"~/Data/Word/") + "before_render_BaoCao.doc.html";
        //    return Json(dataDir, JsonRequestBehavior.AllowGet);*/
        //    ViewBag.fields = fs;
        //    if (TG == 0) return PartialView("Partial_BaoCao");
        //    else if (TG == 1) return PartialView("PartialBaoCaoHPN");
        //    else return PartialView("PartialBaoCaoCD");
        //}


        //[HttpPost]
        //public ActionResult BaoCaoHienTai(Hoi hoi, bool theoNam)
        //{
        //    BaoCao bc = new BaoCao();
        //    int? quyBC = theoNam == true ? null : (int?)Quy;
        //    bc = _context.BaoCaos.Where(x => (x.TG == hoi.LoaiHoi && (x.MaHPN == hoi.Ma || x.MaCD == hoi.Ma) && x.Nam == Nam && x.Quy == quyBC)).FirstOrDefault();
        //    if (bc != null) if (bc.Khoa == true) return PartialViewReport(bc.MaBaoCao);
        //    int TG = hoi.LoaiHoi;
        //    List<Field> fs = Field.List(TG);
        //    DateTime tg;
        //    if (theoNam == true)
        //    {
        //        tg = DateTime.Parse("01/01/" + Nam);
        //    }
        //    else
        //    {
        //        int thang = (Quy - 1) * 3 + 1;
        //        tg = DateTime.Parse("01/" + thang + "/" + Nam);
        //    }
        //    int n = fs.Count;
        //    for (int i = 0; i < n; i++)
        //    {
        //        if (fs[i].type == "donvi")
        //        {
        //            if (TG == 0) fs[i].value = "Học viện Kỹ thuật Quân sự";
        //            else if (TG == 1)
        //            {
        //                HoiPhuNu HPN = _context.HoiPhuNus.Find(hoi.Ma);
        //                if (HPN == null) return null;
        //                else fs[i].value = HPN.TenHPN != null ? HPN.TenHPN : "";

        //            }
        //            else if (TG == 2)
        //            {
        //                HoiCongDoan CD = _context.HoiCongDoans.Find(hoi.Ma);
        //                if (CD == null) return null;
        //                else fs[i].value = CD.TenHCD != null ? CD.TenHCD : "";
        //            }
        //        }
        //        else if (fs[i].type == "output")
        //        {
        //            int? count = 0;
        //            string str = "KetNapMoi";
        //            string str1 = "CD_";

        //            if (fs[i].templatecode.Contains(str1) == true)
        //            {
        //                fs[i].value = (int.Parse(fs[i - 1].value) + int.Parse(fs[i - 1].value)).ToString();
        //            }
        //            else if (fs[i].templatecode.Contains(str) == true)
        //            {
        //                List<SqlParameter> paralist = new List<SqlParameter>();
        //                paralist.Add(new SqlParameter("@ThoiGian", tg));
        //                paralist.Add(new SqlParameter("@TG", TG));
        //                paralist.Add(new SqlParameter("@MA", hoi.Ma == null ? 0 : hoi.Ma));
        //                count = _context.Database.SqlQuery<int?>("EXEC proc_" + fs[i].templatecode + " @ThoiGian, @TG, @MA", paralist.ToArray()).FirstOrDefault();

        //            }
        //            else
        //            {
        //                List<SqlParameter> paralist = new List<SqlParameter>();
        //                paralist.Add(new SqlParameter("@TG", TG));
        //                paralist.Add(new SqlParameter("@MA", hoi.Ma == null ? 0 : hoi.Ma));
        //                count = _context.Database.SqlQuery<int?>("EXEC proc_" + fs[i].templatecode + " @TG, @MA", paralist.ToArray()).FirstOrDefault();
        //            }
        //            if (count == null) count = 0;
        //            fs[i].value = count.ToString();
        //        }
        //        else if (fs[i].type == "thangnam")
        //        {
        //            fs[i].value = DateTime.Now.Month.ToString() + "/" + Nam.ToString();
        //        }
        //        else if (fs[i].type == "tenthongke")
        //        {
        //            if (theoNam == true)
        //                fs[i].value = " NĂM " + Nam.ToString();
        //            else
        //                fs[i].value = " QUÝ " + Quy.ToString() + " NĂM " + Nam.ToString();
        //        }
        //    }
        //    ViewBag.fields = fs;
        //    ViewBag.daChot = false;
        //    if (TG == 0) return PartialView("Partial_BaoCao");
        //    else if (TG == 1) return PartialView("PartialBaoCaoHPN");
        //    else return PartialView("PartialBaoCaoCD");
        //}

        //[HttpPost]
        //public int DaChotHT(Hoi hoi, bool theoNam)
        //{
        //    BaoCao bc = new BaoCao();
        //    int? quyBC = theoNam == true ? null : (int?)Quy;
        //    bc = _context.BaoCaos.Where(x => (x.TG == hoi.LoaiHoi && (x.MaHPN == hoi.Ma || x.MaCD == hoi.Ma) && x.Nam == Nam && x.Quy == quyBC)).FirstOrDefault();
        //    if (bc == null) return 0;
        //    else
        //    {
        //        bool b = (bool)bc.Khoa;
        //        if (b == true) return 1;
        //        else return 0;
        //    }
        //}

        //[HttpPost]
        //public int DaChotKho(int idBC)
        //{
        //    BaoCao baoCao = _context.BaoCaos.Where(x => x.MaBaoCao == idBC).FirstOrDefault();
        //    if (baoCao == null) return 0;
        //    else
        //    {
        //        if (baoCao.Nam != Nam) return 0;
        //        if (baoCao.Quy != null) if (baoCao.Quy != Quy) return 0;
        //        bool b = (bool)baoCao.Khoa;
        //        if (b == true) return 1;
        //        else return 0;
        //    }

        //}

        
    }
}