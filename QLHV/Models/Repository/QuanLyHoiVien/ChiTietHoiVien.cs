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
            var TTCN = mycontext.Database.SqlQuery<CTHV_ThongTinCaNhanPost>
                ("EXEC proc_ChiTietHoiVien_ThongTinCaNhan '" + MaHV + "'").FirstOrDefault();
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