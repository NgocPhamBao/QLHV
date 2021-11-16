namespace QLHV.Models.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichSuChucDanh")]
    public partial class LichSuChucDanh
    {
        [Key]
        public int MaLSCD { get; set; }

        public int? MaCD { get; set; }

        [StringLength(15)]
        public string MaHV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayQD { get; set; }

        public virtual ChucDanh ChucDanh { get; set; }

        public virtual HoiVien HoiVien { get; set; }
    }
}
