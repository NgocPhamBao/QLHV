using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLHV.Models.Context
{
    public partial class MyContext : DbContext
    {
        public MyContext()
            : base("name=MyContext")
        {
        }

        public virtual DbSet<BaoCao> BaoCaos { get; set; }
        public virtual DbSet<BCH_HCD> BCH_HCD { get; set; }
        public virtual DbSet<BCH_HPN> BCH_HPN { get; set; }
        public virtual DbSet<CapBac> CapBacs { get; set; }
        public virtual DbSet<CapLaiMatKhau> CapLaiMatKhaus { get; set; }
        public virtual DbSet<ChiBo> ChiBoes { get; set; }
        public virtual DbSet<ChucDanh> ChucDanhs { get; set; }
        public virtual DbSet<DangUy> DangUys { get; set; }
        public virtual DbSet<DanhHieu> DanhHieux { get; set; }
        public virtual DbSet<DonVi> DonVis { get; set; }
        public virtual DbSet<HoanCanhGD> HoanCanhGDs { get; set; }
        public virtual DbSet<HoiCongDoan> HoiCongDoans { get; set; }
        public virtual DbSet<HoiPhuNu> HoiPhuNus { get; set; }
        public virtual DbSet<HoiVien> HoiViens { get; set; }
        public virtual DbSet<KyBaoCao> KyBaoCaos { get; set; }
        public virtual DbSet<LaoDongSangTao> LaoDongSangTaos { get; set; }
        public virtual DbSet<LichSuCapBac> LichSuCapBacs { get; set; }
        public virtual DbSet<LichSuChucDanh> LichSuChucDanhs { get; set; }
        public virtual DbSet<LichSuDanhHieu> LichSuDanhHieux { get; set; }
        public virtual DbSet<LichSuTrinhDo> LichSuTrinhDoes { get; set; }
        public virtual DbSet<LoaiDangVien> LoaiDangViens { get; set; }
        public virtual DbSet<LoaiHoiVien> LoaiHoiViens { get; set; }
        public virtual DbSet<LoaiLDST> LoaiLDSTs { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<SoLieu> SoLieux { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ToChucDoanThe> ToChucDoanThes { get; set; }
        public virtual DbSet<TrinhDo> TrinhDoes { get; set; }
        public virtual DbSet<BacTho> BacThoes { get; set; }
        public virtual DbSet<HoiVien_LDST> HoiVien_LDST { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BCH_HCD>()
                .Property(e => e.MaHV)
                .IsUnicode(false);

            modelBuilder.Entity<BCH_HPN>()
                .Property(e => e.MaHV)
                .IsUnicode(false);

            modelBuilder.Entity<CapBac>()
                .HasMany(e => e.LichSuCapBacs)
                .WithRequired(e => e.CapBac)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CapLaiMatKhau>()
                .Property(e => e.MaHV)
                .IsUnicode(false);

            modelBuilder.Entity<HoanCanhGD>()
                .Property(e => e.MaHV)
                .IsUnicode(false);

            modelBuilder.Entity<HoiCongDoan>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<HoiCongDoan>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<HoiPhuNu>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<HoiPhuNu>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<HoiVien>()
                .Property(e => e.MaHV)
                .IsUnicode(false);

            modelBuilder.Entity<HoiVien>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<HoiVien>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<HoiVien>()
                .Property(e => e.Anh)
                .IsUnicode(false);

            modelBuilder.Entity<LichSuCapBac>()
                .Property(e => e.MaHV)
                .IsUnicode(false);

            modelBuilder.Entity<LichSuChucDanh>()
                .Property(e => e.MaHV)
                .IsUnicode(false);

            modelBuilder.Entity<LichSuDanhHieu>()
                .Property(e => e.MaHV)
                .IsUnicode(false);

            modelBuilder.Entity<LichSuTrinhDo>()
                .Property(e => e.MaHV)
                .IsUnicode(false);

            modelBuilder.Entity<PhanQuyen>()
                .Property(e => e.TenDN)
                .IsUnicode(false);

            modelBuilder.Entity<PhanQuyen>()
                .Property(e => e.MaQuyen)
                .IsUnicode(false);

            modelBuilder.Entity<Quyen>()
                .Property(e => e.MaQuyen)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TenDN)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.MaHV)
                .IsUnicode(false);

            modelBuilder.Entity<HoiVien_LDST>()
                .Property(e => e.MaHV)
                .IsUnicode(false);
        }
    }
}
