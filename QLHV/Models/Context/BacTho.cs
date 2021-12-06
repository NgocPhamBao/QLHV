namespace QLHV.Models.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BacTho")]
    public partial class BacTho
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaBacTho { get; set; }

        [Key]
        [Column("BacTho", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BacTho1 { get; set; }
    }
}
