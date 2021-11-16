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

        [Required]
        [StringLength(50)]
        public string TenSoLieu { get; set; }

        [Column("SoLieu")]
        public int? SoLieu1 { get; set; }

        public int MaBaoCao { get; set; }

        public virtual BaoCao BaoCao { get; set; }
    }
}
