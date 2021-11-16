namespace QLHV.Models.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GroupUser")]
    public partial class GroupUser
    {
        [Key]
        [StringLength(20)]
        public string IDGroupUser { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
