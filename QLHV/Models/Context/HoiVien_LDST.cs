namespace QLHV.Models.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HoiVien_LDST
    {
        [StringLength(15)]
        public string MaHV { get; set; }

        public int? MaLDST { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ThamGia { get; set; }

        public virtual HoiVien HoiVien { get; set; }

        public virtual LaoDongSangTao LaoDongSangTao { get; set; }
    }
}
