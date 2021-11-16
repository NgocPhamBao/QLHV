using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLHV.Models.Context;
using QLHV.Models.ViewModels.QuanLyhoiVien;

namespace QLHV.Models.Repository.QuanLyHoiVien
{
    public class ChiTietHoiVien
    {
        MyContext mycontext = new MyContext();
        public CTHV_ThongTinCaNhanPost ThongTinCaNhan(string MaHV)
        {
            CTHV_ThongTinCaNhan_Update TTCN_Update = mycontext.Database.SqlQuery<CTHV_ThongTinCaNhan_Update>
                ("EXEC proc_ChiTietHoiVien_ThongTinCaNhan '" + MaHV + "'").FirstOrDefault();
            var TTCN = new CTHV_ThongTinCaNhanPost();
            TTCN.MaHV = TTCN_Update.MaHV;
            TTCN.TenHV = TTCN_Update.TenHV;
            if (TTCN_Update.GioiTinh == false) TTCN.GioiTinh = "Nữ";
            else if(TTCN_Update.GioiTinh == true) TTCN.GioiTinh = "Nam";
            TTCN.DanToc = TTCN_Update.DanToc;
            TTCN.NgaySinh = TTCN_Update.NgaySinh;
            TTCN.NamNhapNgu = TTCN_Update.NamNhapNgu;
            TTCN.TenLHV = TTCN_Update.TenLHV;
            TTCN.TenDV = TTCN_Update.TenDV;
            TTCN.BacTho = TTCN_Update.BacTho;
            TTCN.TenLDV = TTCN_Update.TenLDV;
            TTCN.TenHPN = TTCN_Update.TenHPN;
            TTCN.TenCD = TTCN_Update.TenCD;
            TTCN.Email = TTCN_Update.Email;
            TTCN.SDT = TTCN_Update.SDT;
            TTCN.Anh = TTCN_Update.Anh;
            TTCN.TenVTCB = TTCN_Update.TenVTCB;
            TTCN.TenVTDU = TTCN_Update.TenVTDU;
            TTCN.TenVTDT = TTCN_Update.TenVTDT;
            return TTCN;
        }
        public List<CTHV_TrinhDo> TrinhDo(string MaHV)
        {
            List<CTHV_TrinhDo> TD = mycontext.Database.SqlQuery<CTHV_TrinhDo>("EXEC proc_ChiTietHoiVien_TrinhDo '" + MaHV + "'").ToList();
            return TD;
        }
        public List<CTHV_ChucDanh> ChucDanh(string MaHV)
        {
            List<CTHV_ChucDanh> CD = mycontext.Database.SqlQuery<CTHV_ChucDanh>("EXEC proc_ChiTietHoiVien_ChucDanh '" + MaHV + "'").ToList();
            return CD;
        }
        public List<CTHV_DanhHieu> DanhHieu(string MaHV)
        {
            List<CTHV_DanhHieu> DH = mycontext.Database.SqlQuery<CTHV_DanhHieu>("EXEC proc_ChiTietHoiVien_DanhHieu '" + MaHV + "'").ToList();
            return DH;
        }
        public List<CTHV_CapBac> CapBac(string MaHV)
        {
            List<CTHV_CapBac> CB = mycontext.Database.SqlQuery<CTHV_CapBac>("EXEC proc_ChiTietHoiVien_CapBac '" + MaHV + "'").ToList();
            return CB;
        }
        public HoanCanhGD HoanCanhGiaDinh(string MaHV)
        {
            HoanCanhGD HCGD = mycontext.Database.SqlQuery<HoanCanhGD>
                ("SELECT MaHCGD, MaHV, Nam, MatChongVo, LyHon, NuoiConMotMinh, HoNgheo, HoCanNgheo, BenhAnBanThan, " +
                "BenhAnConCai, NhaCua, VoChong, DaKetHon FROM dbo.HoanCanhGD WHERE MaHV = '" + MaHV + "'").FirstOrDefault();
            return HCGD;
        }
        public List<CTHV_LDST> LaoDongSangTao(string MaHV)
        {
            List<CTHV_LDST> LDST = mycontext.Database.SqlQuery<CTHV_LDST>
                ("EXEC proc_ChiTietHoiVien_LaoDongSangTao '" + MaHV + "'").ToList();
            return LDST;
        }
    }
}