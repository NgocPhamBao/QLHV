namespace QLHV.Models.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaoCao")]
    public partial class BaoCao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaoCao()
        {
            SoLieux = new HashSet<SoLieu>();
        }

        [Key]
        public int MaBaoCao { get; set; }

        [Required]
        [StringLength(200)]
        public string TenBaoCao { get; set; }

        public int Nam { get; set; }

        public short? Quy { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayLuu { get; set; }

        [StringLength(15)]
        public string MaNguoiLuu { get; set; }

        public int? MaCD { get; set; }

        public int? MaHPN { get; set; }

        public short TG { get; set; }

        public bool? Khoa { get; set; }

        public virtual HoiVien HoiVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SoLieu> SoLieux { get; set; }
    }
}
