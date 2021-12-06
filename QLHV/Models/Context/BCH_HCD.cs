namespace QLHV.Models.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BCH_HCD
    {
        [Key]
        public int MaBCH { get; set; }

        public int? MaHCD { get; set; }

        [StringLength(15)]
        public string MaHV { get; set; }

        public int ViTri { get; set; }

        public int NhiemKy { get; set; }

        public int? NamBatDau { get; set; }

        public int? NamKetThuc { get; set; }

        public virtual HoiCongDoan HoiCongDoan { get; set; }

        public virtual HoiVien HoiVien { get; set; }
    }
}
