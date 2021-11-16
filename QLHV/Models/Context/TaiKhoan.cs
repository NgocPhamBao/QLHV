namespace QLHV.Models.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [Key]
        [StringLength(25)]
        public string TenDN { get; set; }

        [Required]
        [StringLength(25)]
        public string MatKhau { get; set; }

        [Required]
        [StringLength(20)]
        public string IDGroupUser { get; set; }

        [StringLength(15)]
        public string MaHV { get; set; }

        public DateTime EditTime { get; set; }

        public bool Khoa { get; set; }

        public virtual HoiVien HoiVien { get; set; }
    }
}
