namespace QLHV.Models.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KyBaoCao")]
    public partial class KyBaoCao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KyBaoCao()
        {
            BaoCaos = new HashSet<BaoCao>();
        }

        [Key]
        public int MaKy { get; set; }

        [Required]
        [StringLength(50)]
        public string TenBaoCao { get; set; }

        [Column(TypeName = "date")]
        public DateTime TGBatDau { get; set; }

        [Column(TypeName = "date")]
        public DateTime TGKetThuc { get; set; }

        public short Loai { get; set; }

        public bool? Xoa { get; set; }

        public bool? Khoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaoCao> BaoCaos { get; set; }
    }
}
