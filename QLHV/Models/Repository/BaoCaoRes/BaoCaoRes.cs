using QLHV.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLHV.Models.Repository.BaoCaoRes
{
    public class BaoCaoRes
    {
        public int MaBaoCao { get; set; }

        public string TenBaoCao { get; set; }

        public int Nam { get; set; }

        public short? Quy { get; set; }

        public DateTime NgayLuu { get; set; }

        public short TG { get; set; }

        public int? MaCD { get; set; }

        public int? MaHPN { get; set; }

        public bool? Khoa { get; set; }

        public void Map(BaoCao bc)
        {
            MaBaoCao = bc.MaBaoCao;
            TenBaoCao = bc.TenBaoCao;
            Nam = bc.Nam;
            Quy = bc.Quy;
            NgayLuu = bc.NgayLuu;
            TG = bc.TG;
            MaCD = bc.MaCD;
            MaHPN = bc.MaHPN;
            Khoa = bc.Khoa;
        }

        public BaoCaoRes(BaoCao bc)
        {
            MaBaoCao = bc.MaBaoCao;
            TenBaoCao = bc.TenBaoCao;
            Nam = bc.Nam;
            Quy = bc.Quy;
            NgayLuu = bc.NgayLuu;
            TG = bc.TG;
            MaCD = bc.MaCD;
            MaHPN = bc.MaHPN;
            Khoa = bc.Khoa;
        }

        public static List<BaoCaoRes> GetDSBaoCaoByHoi(Hoi hoi, bool Nam)
        {
            List<BaoCaoRes> ListBaoCaoRes = new List<BaoCaoRes>();
            using (var _context = new MyContext())
            {
                List<BaoCao> baoCaos = new List<BaoCao>();
                if(Nam == true) {
                    baoCaos = _context.BaoCaos.
                    Where(x => (x.TG == hoi.LoaiHoi && (x.MaCD == hoi.Ma || x.MaHPN == hoi.Ma) && x.Quy == null)).
                    OrderByDescending(x => x.Nam).
                    ToList();
                }
                else
                {
                    baoCaos = _context.BaoCaos.
                    Where(x => (x.TG == hoi.LoaiHoi && (x.MaCD == hoi.Ma || x.MaHPN == hoi.Ma) && x.Quy != null)).
                    OrderByDescending(x => x.Nam).
                    ToList();
                }
                foreach(var bc in baoCaos)
                {
                    var Bcres = new BaoCaoRes(bc);
                    ListBaoCaoRes.Add(Bcres);
                }
                return ListBaoCaoRes;
            }
        }
    }
}