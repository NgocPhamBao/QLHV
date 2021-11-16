namespace QLHV.Models.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiBo")]
    public partial class ChiBo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChiBo()
        {
            HoiViens = new HashSet<HoiVien>();
        }

        [Key]
        public int MaVTCB { get; set; }

        [Required]
        [StringLength(25)]
        public string TenVTCB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoiVien> HoiViens { get; set; }
    }
}
