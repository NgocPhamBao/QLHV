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
          //[HttpPost]
          //[CustomAuthorize(Roles = "BCH_CD,BCH_PN,HVIEN")]
          //public ActionResult ChiTietHoiVien(CTHV_ThongTinCaNhanPost model)
          //{
          //    var HoiVien = new CTHV_ThongTinCaNhan();
          //    ChiTietHoiVien CTHV = new ChiTietHoiVien();
          //    bool temp = true;            
          //    if (model.TenHV == null)
          //    {
          //        ModelState.AddModelError("TenHV", "Không được để trống!");
          //        temp = false;
          //    }
          //    bool GioiTinh = false;
          //    if (model.GioiTinh == "Nữ") GioiTinh = false;
          //    else if (model.GioiTinh == "Nam") GioiTinh = true;
          //    else
          //    {
          //        ModelState.AddModelError("GioiTinh", "Không hợp lệ!");
          //        temp = false;
          //    }

          //    int MaLHV = 0;
          //    if (model.TenLHV == "SQ") MaLHV = 1;
          //    else if (model.TenLHV == "QNCN") MaLHV = 2;
          //    else if (model.TenLHV == "CNVQP") MaLHV = 3;
          //    else if (model.TenLHV == "LĐHĐ") MaLHV = 4;
          //    else if (model.TenLHV == "HV") MaLHV = 5;
          //    else
          //    {
          //        ModelState.AddModelError("TenLHV", "Không hợp lệ!");
          //        temp = false;
          //    }

          //    int? MaDV = 0;
          //    if (model.TenDV != null)
          //    {
          //        MaDV = mycontext.Database.SqlQuery<int>
          //        ("SELECT MaDV FROM dbo.DonVi WHERE TenDV = N'" + model.TenDV + "'").FirstOrDefault();
          //        if (MaDV == null)
          //        {
          //            ModelState.AddModelError("TenDV", "Không hợp lệ!");
          //            temp = false;
          //        }
          //    }

          //    int? MaVTCB = null;
          //    if (model.TenVTCB != null && model.TenVTCB != "Không")
          //    {
          //        if (model.TenVTCB == "Chi uỷ viên") MaVTCB = 1;
          //        else if (model.TenVTCB == "Phó bí thư") MaVTCB = 2;
          //        else if (model.TenVTCB == "Bí thư") MaVTCB = 3;
          //        else
          //        {
          //            ModelState.AddModelError("TenVTCB", "Không hợp lệ!");
          //            temp = false;
          //        }
          //    }

          //    int? MaVTDU = null;
          //    if (model.TenVTDU != null && model.TenVTDU != "Không")
          //    {
          //        if (model.TenVTDU == "Bí thư") MaVTDU = 1;
          //        else if (model.TenVTDU == "Phó bí thư") MaVTDU = 2;
          //        else if (model.TenVTDU == "Đảng uỷ viên") MaVTDU = 3;
          //        else if (model.TenVTDU == "Thường vụ") MaVTDU = 4;
          //        else
          //        {
          //            ModelState.AddModelError("TenVTDU", "Không hợp lệ!");
          //            temp = false;
          //        }
          //    }

          //    int? MaVTDT = null;
          //    if (model.TenVTDT != null && model.TenVTDT != "Không")
          //    {
          //        if (model.TenVTDT == "Chủ tịch") MaVTDT = 1;
          //        else if (model.TenVTDT == "Phó chủ tịch") MaVTDT = 2;
          //        else if (model.TenVTDT == "Uỷ viên") MaVTDT = 3;
          //        else if (model.TenVTDT == "Bí thư Đoàn") MaVTDT = 4;
          //        else if (model.TenVTDT == "Phó bí thư Đoàn") MaVTDT = 5;
          //        else if (model.TenVTDT == "Uỷ viên BCH Đoàn") MaVTDT = 6;
          //        else
          //        {
          //            ModelState.AddModelError("TenVTDT", "Không hợp lệ!");
          //            temp = false;
          //        }
          //    }
          //    if (model.TenHPN == null && model.TenCD == null)
          //    {
          //        ModelState.AddModelError("TenPN", "Nhập thông tin hội phụ nữ hoặc hội công đoàn!");
          //        temp = false;
          //    }

          //    int? MaHPN = null;
          //    if (model.TenHPN != null && model.TenHPN != "Không")
          //    {
          //        MaHPN = mycontext.Database.SqlQuery<int>
          //        ("SELECT MaHPN FROM dbo.HoiPhuNu WHERE TenHPN = N'" + model.TenHPN + "'").FirstOrDefault();
          //        if (MaHPN == null)
          //        {
          //            ModelState.AddModelError("TenHPN", "Không hợp lệ!");
          //            temp = false;
          //        }
          //    }

          //    int? MaCD = null;
          //    if (model.TenCD != null && model.TenCD != "Không")
          //    {
          //        MaCD = mycontext.Database.SqlQuery<int>
          //        ("SELECT MaCD FROM dbo.CongDoan WHERE TenCD = N'" + model.TenCD + "'").FirstOrDefault();
          //        if (MaCD == null)
          //        {
          //            ModelState.AddModelError("TenCD", "Không hợp lệ!");
          //            temp = false;
          //        }
          //    }

          //    if (model.BacTho < 1 || model.BacTho > 7)
          //    {
          //        ModelState.AddModelError("BacTho", "Không hợp lệ!");
          //        temp = false;
          //    }

          //    int MaLDV = 1;
          //    if (model.TenLDV == "Đảng viên") MaLDV = 1;
          //    else if (model.TenLDV == "Đảng viên mới kết nạp (Đảng viên dự bị)") MaLDV = 2;
          //    else if (model.TenLDV == "Đảng viên đang đề xuất kết nạp") MaLDV = 3;
          //    else if (model.TenLDV == "Đảng viên chưa trong danh sách đề xuất kết nạp") MaLDV = 4;
          //    else
          //    {
          //        ModelState.AddModelError("TenLDV", "Không hợp lệ!");
          //        temp = false;
          //    }

          //    if (temp == true)
          //    {
          //        var check = mycontext.Database.ExecuteSqlCommand("EXEC proc_ChiTietHoiVien_ThongTinCaNhan_Edit " +
          //            "@MaHV='"+ model.MaHV + "', @TenHV = N'"+ model.TenHV +"', @GioiTinh = "+ GioiTinh +", @DanToc = N'"+ 
          //            model.DanToc +"', @NgaySinh = '"+ model.NgaySinh +"', @NamNhapNgu = "+ model.NamNhapNgu +", @MaLHV = "
          //            + MaLHV +", @MaDV = " + MaDV +", @BacTho = "+ model.BacTho +", @Email = '"+ model.Email +"', @SDT = '"
          //            + model.SDT +"',@MaHPN = "+ MaHPN +", @MaCD = "+ MaCD +", @MaLDV = "+ MaLDV +", @MaVTCB = "+ MaVTCB +
          //            ", @MaVTDU = "+ MaVTDU +",	@MaVTDT = "+ MaVTDT +", @Anh = '"+ model.Anh +"'");
          //        if (check > 0)
          //        {
          //            ViewBag.Message_TTCN = "Ok";
          //            ViewBag.TTCN = CTHV.ThongTinCaNhan(model.MaHV);
          //            ViewBag.LSCB = CTHV.CapBac(model.MaHV);
          //            ViewBag.LSCD = CTHV.ChucDanh(model.MaHV);
          //            ViewBag.LSDH = CTHV.DanhHieu(model.MaHV);
          //            ViewBag.LSTD = CTHV.TrinhDo(model.MaHV);
          //            ViewBag.HCGD = CTHV.HoanCanhGiaDinh(model.MaHV);
          //            ViewBag.LDST = CTHV.LaoDongSangTao(model.MaHV);
          //            return View(HoiVien);
          //        }
          //    }
          //    ViewBag.TTCN = model;
          //    ViewBag.LSCB = CTHV.CapBac(model.MaHV);
          //    ViewBag.LSCD = CTHV.ChucDanh(model.MaHV);
          //    ViewBag.LSDH = CTHV.DanhHieu(model.MaHV);
          //    ViewBag.LSTD = CTHV.TrinhDo(model.MaHV);
          //    ViewBag.HCGD = CTHV.HoanCanhGiaDinh(model.MaHV);
          //    ViewBag.LDST = CTHV.LaoDongSangTao(model.MaHV);
          //    return View(HoiVien);
          //}
          //[HttpPost]
          //[CustomAuthorize(Roles = "BCH_CD,BCH_PN,HVIEN")]        
          //public ActionResult UploadAnh(HttpPostedFileBase postedFile)
          //{
          //    //Extract Image File Name.
          //    string fileName = System.IO.Path.GetFileName(postedFile.FileName);

          //    //Set the Image File Path.
          //    string filePath = "~/Uploads/" + fileName;

          //    //Save the Image File in Folder.
          //    postedFile.SaveAs(Server.MapPath(filePath));

          //    //Insert the Image File details in Table.
          //    FilesEntities entities = new FilesEntities();
          //    entities.Files.Add(new File
          //    {
          //        Name = fileName,
          //        Path = filePath
          //    });
          //    entities.SaveChanges();

          //    //Redirect to Index Action.
          //    return RedirectToAction("ThemMoiHoiVien");
          //}
          [HttpPost]
          [CustomAuthorize(Roles = "BCH_CD,BCH_PN,HVIEN")]
          public ActionResult ThemMoiHoiVien(ThemMoiHoiVienPost model)
          {
               if (ModelState.IsValid == true)
               {
                    if (model.MaHPN == null && model.MaHCD == null)
                    {
                         ModelState.AddModelError("MaHPN", "Nhập thông tin hội phụ nữ hoặc hội công đoàn!");
                         var HoiVien = new ThemMoiHoiVienPost();
                         ViewBag.temp = new ThemMoiHoiVien();
                         return View(HoiVien);
                    }
                    else
                    {
                         var check = mycontext.Database.ExecuteSqlCommand("EXEC proc_ThemMoiHoiVien @MaHV = '" + model.MaHV +
                             "',@TenHV = N'" + model.TenHV + "', @GioiTinh = " + model.GioiTinh + ",@DanToc = N'" + model.DanToc + "',@NgaySinh = '"
                             + model.NgaySinh + "',@NamNhapNgu = " + model.NamNhapNgu + ",@MaLHV = " + model.MaLDV + ",@MaDV = " + model.MaDV
                             + ",@BacTho = " + model.BacTho + ",@Email = '" + model.Email + "',@SDT = '" + model.SDT + "',@MaHPN = " + model.MaHPN
                             + ",@MaHCD = " + model.MaHCD + ",@MaLDV = " + model.MaLDV + ",@MaVTCB = " + model.MaVTCB + ",@MaVTDU = " + model.MaVTDU
                             + ",@MaVTDT = " + model.MaVTDT + ",@Anh = '" + model.Anh + "',@MaTD = " + model.MaTD + ",@MaCD = "
                             + model.MaCD + ",@MaDH = " + model.MaDH + ",@MaCB = " + model.MaCB);
                         if (check > 0)
                         {
                              ViewBag.Message = "Ok";
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
          public JsonResult ChinhSuaHoiVien(string MaHV, string TenHV, string GioiTinh, string DanToc, string NgaySinh, string NamNhapNgu,
              string TenLHV, string TenDV, string BacTho, string Email, string SDT, string TenHPN, string TenLDV, string TenVTDU, string TenVTCB, string TenVTDT)
          {


               //Hàm chỉnh sửa thông tin cá nhân 
               //Viết truy vấn vào đây nhé
               var check = mycontext.Database.ExecuteSqlCommand("EXEC proc_ChiTietHoiVien_ThongTinCaNhan_Edit @MaHV, @TenHV, @GioiTinh, @DanToc, " +
                   "@NgaySinh, @NamNhapNgu, @MaLHV, @MaDV, @BacTho, @Email, @SDT, @MaHPN, @MaHCD, @MaLDV, @MaVTCB, @MaVTDU, @MaVTDT", mycontext);

               EntityParameter param1 = new EntityParameter();
               param1.ParameterName = "@MaHV";
               param1.Value = MaHV;

               EntityParameter param2 = new EntityParameter();
               param1.ParameterName = "@TenHV";
               param1.Value = TenHV;

               EntityParameter param3 = new EntityParameter();
               param1.ParameterName = "@GioiTinh";
               param1.Value = GioiTinh;

               EntityParameter param4 = new EntityParameter();
               param1.ParameterName = "@DanToc";
               param1.Value = DanToc;

               EntityParameter param5 = new EntityParameter();
               param1.ParameterName = "@NgaySinh";
               param1.Value = NgaySinh;

               EntityParameter param6 = new EntityParameter();
               param1.ParameterName = "@NamNhapNgu";
               param1.Value = NamNhapNgu;
               //Anh truyền vào số nhưng lười đổi tên đấy, dùng như anh là được 
               EntityParameter param7 = new EntityParameter();
               param1.ParameterName = "@MaLHV";
               param1.Value = Int32.Parse(TenLHV);

               EntityParameter param8 = new EntityParameter();
               param1.ParameterName = "@MaDV";
               param1.Value = Int32.Parse(TenDV);

               EntityParameter param9 = new EntityParameter();
               param1.ParameterName = "@BacTho";
               param1.Value = BacTho;

               EntityParameter param10 = new EntityParameter();
               param1.ParameterName = "@Email";
               param1.Value = Email;

               EntityParameter param11 = new EntityParameter();
               param1.ParameterName = "@SDT";
               param1.Value = SDT;

               //EntityParameter param12 = new EntityParameter();
               //param1.ParameterName = "@MaHPN";
               //param1.Value = MaHPN;

               //EntityParameter param13 = new EntityParameter();
               //param1.ParameterName = "@MaHCD";
               //param1.Value = MaHCD;

               //EntityParameter param14 = new EntityParameter();
               //param1.ParameterName = "@MaLDV";
               //param1.Value = MaLDV;

               //EntityParameter param15 = new EntityParameter();
               //param1.ParameterName = "@MaVTCB";
               //param1.Value = MaVTCB;

               //EntityParameter param16 = new EntityParameter();
               //param1.ParameterName = "@MaVTDU";
               //param1.Value = MaVTDU;

               //EntityParameter param17 = new EntityParameter();
               //param1.ParameterName = "@MaVTDT";
               //param1.Value = MaVTDT;
               return Json(new
               {

                    status = true

               });
          }
          public JsonResult ChinhSuaHoiVienHCGD(string MaHV, string HoNgheo, string HoCanNgheo, string DaKetHon, string LyHon, string VoChong,
              string MatChongVo, string NuoiConMotMinh, string BenhAnBanThan, string BenhAnConCai, string NhaCua)
          {

               //Hàm chỉnh sửa hoàn cảnh gia đình
               //Viết truy vấn vào đây nhé
               var check = mycontext.Database.ExecuteSqlCommand("EXEC proc_ChiTietHoiVien_HoanCanhGiaDinh_Edit @MaHV, @HoNgheo, @HoCanNgheo, @DaKetHon, " +
                   "@LyHon, @VoChong, @MatChongVo, @NuoiConMotMinh, @BenhAnBanThan, @BenhAnConCai, @NhaCua", mycontext);

               EntityParameter param1 = new EntityParameter();
               param1.ParameterName = "@MaHV";
               param1.Value = MaHV;

               EntityParameter param2 = new EntityParameter();
               param1.ParameterName = "@HoNgheo";
               param1.Value = HoNgheo;

               EntityParameter param3 = new EntityParameter();
               param1.ParameterName = "@HoCanNgheo";
               param1.Value = HoCanNgheo;

               EntityParameter param4 = new EntityParameter();
               param1.ParameterName = "@DaKetHon";
               param1.Value = DaKetHon;

               EntityParameter param5 = new EntityParameter();
               param1.ParameterName = "@LyHon";
               param1.Value = LyHon;

               EntityParameter param6 = new EntityParameter();
               param1.ParameterName = "@VoChong";
               param1.Value = VoChong;

               EntityParameter param7 = new EntityParameter();
               param1.ParameterName = "@MatChongVo";
               param1.Value = MatChongVo;

               EntityParameter param8 = new EntityParameter();
               param1.ParameterName = "@NuoiConMotMinh";
               param1.Value = NuoiConMotMinh;

               EntityParameter param9 = new EntityParameter();
               param1.ParameterName = "@BenhAnBanThan";
               param1.Value = BenhAnBanThan;

               EntityParameter param10 = new EntityParameter();
               param1.ParameterName = "@BenhAnConCai";
               param1.Value = BenhAnConCai;

               EntityParameter param11 = new EntityParameter();
               param1.ParameterName = "@NhaCua";
               param1.Value = NhaCua;

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