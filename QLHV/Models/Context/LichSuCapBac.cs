namespace QLHV.Models.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichSuCapBac")]
    public partial class LichSuCapBac
    {
        [Key]
        public int MaLSCD { get; set; }

        public int MaCB { get; set; }

        [StringLength(15)]
        public string MaHV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayQD { get; set; }

        public virtual CapBac CapBac { get; set; }

        public virtual HoiVien HoiVien { get; set; }
    }
}
