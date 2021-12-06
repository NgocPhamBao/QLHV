using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using QLHV.Models.Context;
using QLHV.Models.Repository.QuanLyHoiVien;
using QLHV.Models.ViewModels.QuanLyhoiVien;
using System.Data.SqlClient;
using QLHV.Common;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlTypes;

namespace QLHV.Controllers
{
     public class QuanLyHoiVienController : Controller
     {
          public static string MAHV;
          public UserLogin userlogin()
          {
               var user = (UserLogin)Session[CommonConstants.USER_SESSION];
               return user;
          }

          MyContext mycontext = new MyContext();
          [OutputCache(Location = System.Web.UI.OutputCacheLocation.Server, Duration = 60 * 5)]
          public ActionResult DanhSachHoiVien()
          {
               DanhSachHoiVien DS = new DanhSachHoiVien();
               var DS_HV = DS.DanhSachHV();
               return View(DS_HV);
          }
          [CustomAuthorize(Roles = "BCH_CD,BCH_PN,HVIEN")]
          public ActionResult ChiTietHoiVien(string id)
          {
               ViewBag.Message_TTCN = 1;
               MAHV = id;
               var HoiVien = new CTHV_ThongTinCaNhan();
               ChiTietHoiVien CTHV = new ChiTietHoiVien();
               ViewBag.TTCN = CTHV.ThongTinCaNhan(id);
               ViewBag.LSCB = CTHV.CapBac(id);
               ViewBag.LSCD = CTHV.ChucDanh(id);
               ViewBag.LSDH = CTHV.DanhHieu(id);
               ViewBag.LSTD = CTHV.TrinhDo(id);
               ViewBag.HCGD = CTHV.HoanCanhGiaDinh(id);
               ViewBag.LDST = CTHV.LaoDongSangTao(id);
               return View(HoiVien);
          }
          [CustomAuthorize(Roles = "BCH_CD,BCH_PN,HVIEN")]
          public ActionResult ThemMoiHoiVien()
          {
               var HoiVien = new ThemMoiHoiVienPost();
               ViewBag.Message = 1;
               ViewBag.temp = new ThemMoiHoiVien();
               return View(HoiVien);
          }
          
          [HttpPost]
          [CustomAuthorize(Roles = "BCH_CD,BCH_PN,HVIEN")]
          public ActionResult ThemMoiHoiVien(ThemMoiHoiVienPost model)
          {
               if (ModelState.IsValid == true)
               {
                    bool checkServer = true;
                    if (model.MaHPN == 0 && model.MaHCD == 0)
                    {
                         ModelState.AddModelError("MaHPN", "Nhập thông tin hội phụ nữ hoặc hội công đoàn!");
                         checkServer = false;
                    }                    
                    if (model.NamNhapNgu >= DateTime.Now.Year)
                    {
                        ModelState.AddModelError("NamNhapNgu", "Không hợp lệ!");
                        checkServer = false;
                    }
                    if (checkServer == false)
                    {
                        var HoiVien = new ThemMoiHoiVienPost();
                        ViewBag.temp = new ThemMoiHoiVien();
                        return View(HoiVien);
                    }
                    else
                    {
                        List<SqlParameter> paralist = new List<SqlParameter>();
                        paralist.Add(new SqlParameter("@MaHV", model.MaHV));
                        paralist.Add(new SqlParameter("@TenHV", model.TenHV));
                        paralist.Add(new SqlParameter("@GioiTinh", model.GioiTinh));
                        paralist.Add(new SqlParameter("@DanToc", model.DanToc));
                        paralist.Add(new SqlParameter("@NgaySinh", model.NgaySinh));
                        paralist.Add(new SqlParameter("@NamNhapNgu", model.NamNhapNgu));
                        paralist.Add(new SqlParameter("@MaLHV", model.MaLHV));
                        paralist.Add(new SqlParameter("@MaDV", model.MaDV));
                        if (model.BacTho == 0) paralist.Add(new SqlParameter("@BacTho", SqlInt32.Null));
                        else paralist.Add(new SqlParameter("@BacTho", model.BacTho));
                        paralist.Add(new SqlParameter("@Email", model.Email));
                        paralist.Add(new SqlParameter("@SDT", model.SDT));
                        if (model.MaHPN == 0) paralist.Add(new SqlParameter("@MaHPN", SqlInt32.Null));
                        else paralist.Add(new SqlParameter("@MaHPN", model.MaHPN));
                        if (model.MaHCD == 0) paralist.Add(new SqlParameter("@MaHCD", SqlInt32.Null));
                        else paralist.Add(new SqlParameter("@MaHCD", model.MaHCD));
                        paralist.Add(new SqlParameter("@MaLDV", model.MaLDV));
                        if (model.MaVTCB == 0) paralist.Add(new SqlParameter("@MaVTCB", SqlInt32.Null));
                        else paralist.Add(new SqlParameter("@MaVTCB", model.MaVTCB));
                        if (model.MaVTDU == 0) paralist.Add(new SqlParameter("@MaVTDU", SqlInt32.Null));
                        else paralist.Add(new SqlParameter("@MaVTDU", model.MaVTDU));
                        if (model.MaVTDT == 0) paralist.Add(new SqlParameter("@MaVTDT", SqlInt32.Null));
                        else paralist.Add(new SqlParameter("@MaVTDT", model.MaVTDT));
                        paralist.Add(new SqlParameter("@MaTD", model.MaTD));
                        if (model.MaCD == 0) paralist.Add(new SqlParameter("@MaCD", SqlInt32.Null));
                        else paralist.Add(new SqlParameter("@MaCD", model.MaCD));
                        if (model.MaDH == 0) paralist.Add(new SqlParameter("@MaDH", SqlInt32.Null));
                        else paralist.Add(new SqlParameter("@MaDH", model.MaDH));
                        paralist.Add(new SqlParameter("@MaCB", model.MaCB));

                        var check = mycontext.Database.ExecuteSqlCommand("EXEC proc_ThemMoiHoiVien @MaHV, @TenHV, @GioiTinh, @DanToc," +
                          "@NgaySinh, @NamNhapNgu, @MaLHV, @MaDV, @BacTho, @Email, @SDT, @MaHPN, @MaHCD, @MaLDV, @MaVTCB, @MaVTDU, " +
                          "@MaVTDT, @MaTD, @MaCD, @MaDH, @MaCB", paralist.ToArray());

                        if (check > 0)
                        {
                            ViewBag.Message = 2;
                            var HoiVien = new ThemMoiHoiVienPost();
                            ViewBag.temp = new ThemMoiHoiVien();
                            return View(HoiVien);
                        }
                        else
                        {
                            var HoiVien = new ThemMoiHoiVienPost();
                            ViewBag.temp = new ThemMoiHoiVien();
                            return View(HoiVien);
                        }
                    }               

               }
               else
               {
                    var HoiVien = new ThemMoiHoiVienPost();
                    ViewBag.temp = new ThemMoiHoiVien();
                    return View(HoiVien);
               }
          }
          [HttpPost]
          [ValidateInput(false)]
          public ActionResult UpdateAvatar(HttpPostedFileBase postedFile)
          {
               //Ham Load anh 
               postedFile = Request.Files["postedFile"];
               string filename = postedFile.FileName.ToString();
               if (filename.Equals("") == false)
               {
                    //lấy đuôi ảnh
                    string ExtensionFile = GetFileExtension(filename);
                    //lấy tên mới của ảnh + [đuôi ảnh lấy đc]
                    string namefilenew = MAHV + "-300x300" + "." + ExtensionFile;

                    var path = Path.Combine(Server.MapPath("~/Models/ImageFile"), namefilenew);
                    //nếu thư mục k tồn tại thì tạo thư mục
                    var folder = Server.MapPath("~/Models/ImageFile");
                    if (!Directory.Exists(folder))
                    {
                         Directory.CreateDirectory(folder);
                    }
                    //lưu ảnh vào đường đẫn
                    postedFile.SaveAs(path);
                    System.Web.Helpers.WebImage file = new System.Web.Helpers.WebImage(path);
                    // resize ảnh về 300x300px
                    file.Resize(302, 302, false);
                    file.Crop(1, 1, 1, 1);
                    file.Save(path);
                    //có thể lấy ảnh đường dẫn như sau
                    //Hv.imange = namefilenew;
               }
               return RedirectToAction("ChiTietHoiVien", new { id = MAHV });
          }
          public JsonResult ChinhSuaHoiVien(string MaHV, string TenHV, bool? GioiTinh, string DanToc, DateTime NgaySinh, int NamNhapNgu,
              int MaLHV, int MaDV, int BacTho, string Email, int SDT, int MaHPN, int MaHCD, int MaLDV, int MaVTDU, int MaVTCB, int MaVTDT)
          {

            //Hàm chỉnh sửa thông tin cá nhân 
            List<SqlParameter> paralist = new List<SqlParameter>();
            paralist.Add(new SqlParameter("@MaHV",MaHV));
            paralist.Add(new SqlParameter("@TenHV", TenHV));
            paralist.Add(new SqlParameter("@GioiTinh", GioiTinh));
            paralist.Add(new SqlParameter("@DanToc", DanToc));
            paralist.Add(new SqlParameter("@NgaySinh", NgaySinh));
            paralist.Add(new SqlParameter("@NamNhapNgu", NamNhapNgu));
            paralist.Add(new SqlParameter("@MaLHV", MaLHV));
            paralist.Add(new SqlParameter("@MaDV", MaDV));
            if (BacTho == 0) paralist.Add(new SqlParameter("@BacTho", SqlInt32.Null));
            else paralist.Add(new SqlParameter("@BacTho", BacTho));
            paralist.Add(new SqlParameter("@Email", Email));
            paralist.Add(new SqlParameter("@SDT", SDT));
            if (MaHPN == 0) paralist.Add(new SqlParameter("@MaHPN", SqlInt32.Null));
            else paralist.Add(new SqlParameter("@MaHPN", MaHPN));
            if (MaHCD == 0) paralist.Add(new SqlParameter("@MaHCD", SqlInt32.Null));
            else paralist.Add(new SqlParameter("@MaHCD", MaHCD));
            paralist.Add(new SqlParameter("@MaLDV", MaLDV));
            if (MaVTCB == 0) paralist.Add(new SqlParameter("@MaVTCB", SqlInt32.Null));
            else paralist.Add(new SqlParameter("@MaVTCB", MaVTCB));
            if (MaVTDU == 0) paralist.Add(new SqlParameter("@MaVTDU", SqlInt32.Null));
            else paralist.Add(new SqlParameter("@MaVTDU", MaVTDU));
            if (MaVTDT == 0) paralist.Add(new SqlParameter("@MaVTDT", SqlInt32.Null));
            else paralist.Add(new SqlParameter("@MaVTDT", MaVTDT));
            var check = mycontext.Database.ExecuteSqlCommand("EXEC proc_ChiTietHoiVien_ThongTinCaNhan_Edit @MaHV, @TenHV, @GioiTinh, @DanToc, " +
                   "@NgaySinh, @NamNhapNgu, @MaLHV, @MaDV, @BacTho, @Email, @SDT, @MaHPN, @MaHCD, @MaLDV, @MaVTCB, @MaVTDU, @MaVTDT", paralist.ToArray());
            if(check > 0)
            {
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }  
          }
          public JsonResult ChinhSuaHoiVienHCGD(string MaHV, bool HoNgheo, bool HoCanNgheo, bool DaKetHon, bool LyHon, bool VoChong,
              bool MatChongVo, bool NuoiConMotMinh, string BenhAnBanThan, string BenhAnConCai, bool NhaCua)
          {

            //Hàm chỉnh sửa hoàn cảnh gia đình
            List<SqlParameter> paralist = new List<SqlParameter>();
            paralist.Add(new SqlParameter("@MaHV", MaHV));
            paralist.Add(new SqlParameter("@HoNgheo", HoNgheo));
            paralist.Add(new SqlParameter("@HoCanNgheo", HoCanNgheo));
            paralist.Add(new SqlParameter("@DaKetHon", DaKetHon));
            paralist.Add(new SqlParameter("@LyHon", LyHon));
            paralist.Add(new SqlParameter("@VoChong", VoChong));
            paralist.Add(new SqlParameter("@MatChongVo", MatChongVo));
            paralist.Add(new SqlParameter("@NuoiConMotMinh", NuoiConMotMinh));
            paralist.Add(new SqlParameter("@BenhAnBanThan", BenhAnBanThan));
            paralist.Add(new SqlParameter("@BenhAnConCai", BenhAnConCai));
            paralist.Add(new SqlParameter("@NhaCua", NhaCua));

            var check = mycontext.Database.ExecuteSqlCommand("EXEC proc_ChiTietHoiVien_HoanCanhGiaDinh_Edit @MaHV, @HoNgheo, @HoCanNgheo, @DaKetHon, " +
                   "@LyHon, @VoChong, @MatChongVo, @NuoiConMotMinh, @BenhAnBanThan, @BenhAnConCai, @NhaCua", paralist.ToArray());

               return Json(new
               {

                    status = true

               });
          }
          [HttpPost]
          public ActionResult ThemCapbac(string TenCapbac, string NgayNhan)
          {
               return View();
          }
          public string GetFileExtension(string s)
          {
               string[] Name_extension = s.Split('.');
               int countarray = Name_extension.Count();
               s = Name_extension[countarray - 1];
               return s;
          }

     }
}