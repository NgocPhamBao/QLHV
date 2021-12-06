namespace QLHV.Models.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LaoDongSangTao")]
    public partial class LaoDongSangTao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LaoDongSangTao()
        {
            HoiVien_LDST = new HashSet<HoiVien_LDST>();
        }

        [Key]
        public int MaLDST { get; set; }

        [StringLength(200)]
        public string TenDeTai { get; set; }

        public int? MaLoaiLDST { get; set; }

        [StringLength(100)]
        public string KetQua { get; set; }

        public int? Nam { get; set; }

        public int? GiaTri { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoiVien_LDST> HoiVien_LDST { get; set; }

        public virtual LoaiLDST LoaiLDST { get; set; }
    }
}
