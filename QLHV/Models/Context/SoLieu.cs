namespace QLHV.Models.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SoLieu")]
    public partial class SoLieu
    {
        [Key]
        public int MaSoLieu { get; set; }

        public int? MaBaoCao { get; set; }

        public int? STTNhom { get; set; }

        [StringLength(200)]
        public string Ten { get; set; }

        public int? SoLuongPN { get; set; }

        public int? SoLuongCDNam { get; set; }

        public int? SoLuongCDNu { get; set; }

        public virtual BaoCao BaoCao { get; set; }
    }
}
