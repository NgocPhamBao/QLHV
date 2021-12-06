namespace QLHV.Models.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoiVien")]
    public partial class HoiVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoiVien()
        {
            BCH_HCD = new HashSet<BCH_HCD>();
            BCH_HPN = new HashSet<BCH_HPN>();
            CapLaiMatKhaus = new HashSet<CapLaiMatKhau>();
            HoanCanhGDs = new HashSet<HoanCanhGD>();
            HoiVien_LDST = new HashSet<HoiVien_LDST>();
            LichSuCapBacs = new HashSet<LichSuCapBac>();
            LichSuChucDanhs = new HashSet<LichSuChucDanh>();
            LichSuDanhHieux = new HashSet<LichSuDanhHieu>();
            LichSuTrinhDoes = new HashSet<LichSuTrinhDo>();
            TaiKhoans = new HashSet<TaiKhoan>();
        }

        [Key]
        [StringLength(15)]
        public string MaHV { get; set; }

        [Required]
        [StringLength(50)]
        public string TenHV { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgaySinh { get; set; }

        public bool GioiTinh { get; set; }

        [StringLength(25)]
        public string DanToc { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(20)]
        public string SDT { get; set; }

        public int? NamNhapNgu { get; set; }

        public short? BacTho { get; set; }

        public int? MaLDV { get; set; }

        public int? MaLHV { get; set; }

        public int? MaDV { get; set; }

        public int? MaHPN { get; set; }

        public int? MaHCD { get; set; }

        public int? MaVTDU { get; set; }

        public int? MaVTCB { get; set; }

        public int? MaVTDT { get; set; }

        public DateTime? EditTime { get; set; }

        public DateTime? NgayVaoHPN { get; set; }

        public DateTime? NgayVaoCD { get; set; }

        [StringLength(100)]
        public string Anh { get; set; }

        public int? MaDH { get; set; }

        public int? MaCD { get; set; }

        public int? MaTD { get; set; }

        public int? MaCB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BCH_HCD> BCH_HCD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BCH_HPN> BCH_HPN { get; set; }

        public virtual CapBac CapBac { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CapLaiMatKhau> CapLaiMatKhaus { get; set; }

        public virtual ChiBo ChiBo { get; set; }

        public virtual ChucDanh ChucDanh { get; set; }

        public virtual DangUy DangUy { get; set; }

        public virtual DonVi DonVi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoanCanhGD> HoanCanhGDs { get; set; }

        public virtual HoiCongDoan HoiCongDoan { get; set; }

        public virtual HoiPhuNu HoiPhuNu { get; set; }

        public virtual LoaiDangVien LoaiDangVien { get; set; }

        public virtual LoaiHoiVien LoaiHoiVien { get; set; }

        public virtual TrinhDo TrinhDo { get; set; }

        public virtual ToChucDoanThe ToChucDoanThe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoiVien_LDST> HoiVien_LDST { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichSuCapBac> LichSuCapBacs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichSuChucDanh> LichSuChucDanhs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichSuDanhHieu> LichSuDanhHieux { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichSuTrinhDo> LichSuTrinhDoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
    }
}
