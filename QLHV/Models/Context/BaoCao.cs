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

        public int? MaKy { get; set; }

        public int? MaHPN { get; set; }

        public int? MaCD { get; set; }

        public int? Loai { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTao { get; set; }

        public bool? Chot { get; set; }

        public virtual KyBaoCao KyBaoCao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SoLieu> SoLieux { get; set; }
    }
}
