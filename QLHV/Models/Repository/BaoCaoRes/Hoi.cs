using QLHV.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLHV.Models.Repository.BaoCaoRes
{
    public class Hoi
    {
        public short LoaiHoi { get; set; }

        public int? Ma { get; set; }

        public string TenHoi { get; set; }

        public Hoi(short _LoaiHoi, int? _Ma, string _TenHoi)
        {
            LoaiHoi = _LoaiHoi;
            Ma = _Ma;
            TenHoi = _TenHoi;
        }

        public Hoi(){}


        public Hoi Map(HoiPhuNu hpn)
        {
            var hoi = new Hoi(1, hpn.MaHPN, hpn.TenHPN);
            return hoi;
        }

        public Hoi Map(HoiCongDoan cd)
        {
            var hoi = new Hoi(2, cd.MaHCD, cd.TenHCD);
            return hoi;
        }

        public static List<Hoi> getListHoi()
        {
            using (var _context = new MyContext())
            {
                var DSHoi = new List<Hoi>();
                var Hoi = new Hoi(0, null, "Học viện Kỹ thuật Quân sự");
                DSHoi.Add(Hoi);
                List<HoiPhuNu> listHPN = _context.HoiPhuNus.ToList();
                foreach (HoiPhuNu hpn in listHPN)
                {
                    DSHoi.Add(Hoi.Map(hpn));
                }
                List<HoiCongDoan> listCD = _context.HoiCongDoans.ToList();
                foreach (HoiCongDoan cd in listCD)
                {
                    DSHoi.Add(Hoi.Map(cd));
                }
                return DSHoi;
            } 
        }
    }
}