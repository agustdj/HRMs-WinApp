using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SunShine_HRMs.Model
{
    public partial class HRMs : DbContext
    {
        public HRMs()
            : base("name=HRMs")
        {
        }

        public virtual DbSet<BANGCAP> BANGCAPs { get; set; }
        public virtual DbSet<BAOHIEM> BAOHIEMs { get; set; }
        public virtual DbSet<CHAMCONG> CHAMCONGs { get; set; }
        public virtual DbSet<CHUCVU> CHUCVUs { get; set; }
        public virtual DbSet<DAOTAONHANVIEN> DAOTAONHANVIENs { get; set; }
        public virtual DbSet<HOPDONG> HOPDONGs { get; set; }
        public virtual DbSet<KHOADAOTAO> KHOADAOTAOs { get; set; }
        public virtual DbSet<LOAIBH> LOAIBHs { get; set; }
        public virtual DbSet<LOAIHD> LOAIHDs { get; set; }
        public virtual DbSet<LOAITK> LOAITKs { get; set; }
        public virtual DbSet<LUONG> LUONGs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<PHONGBAN> PHONGBANs { get; set; }
        public virtual DbSet<PHONGVAN> PHONGVANs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }
        public virtual DbSet<TKNGANHANG> TKNGANHANGs { get; set; }
        public virtual DbSet<TUYENDUNG> TUYENDUNGs { get; set; }
        public virtual DbSet<UNGVIEN> UNGVIENs { get; set; }
        public virtual DbSet<VITRICV> VITRICVs { get; set; }
        public virtual DbSet<YEUCAUNGHIPHEP> YEUCAUNGHIPHEPs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BANGCAP>()
                .Property(e => e.IDNV)
                .IsUnicode(false);

            modelBuilder.Entity<BAOHIEM>()
                .Property(e => e.IDNV)
                .IsUnicode(false);

            modelBuilder.Entity<CHAMCONG>()
                .Property(e => e.IDNV)
                .IsUnicode(false);

            modelBuilder.Entity<CHUCVU>()
                .HasMany(e => e.NHANVIENs)
                .WithOptional(e => e.CHUCVU)
                .HasForeignKey(e => e.IDChucVu);

            modelBuilder.Entity<DAOTAONHANVIEN>()
                .Property(e => e.IDNV)
                .IsUnicode(false);

            modelBuilder.Entity<HOPDONG>()
                .Property(e => e.IDNV)
                .IsUnicode(false);

            modelBuilder.Entity<KHOADAOTAO>()
                .HasMany(e => e.DAOTAONHANVIENs)
                .WithOptional(e => e.KHOADAOTAO)
                .HasForeignKey(e => e.IDKHOADT);

            modelBuilder.Entity<LOAIBH>()
                .Property(e => e.TenLoai)
                .IsUnicode(false);

            modelBuilder.Entity<LOAIBH>()
                .HasMany(e => e.BAOHIEMs)
                .WithOptional(e => e.LOAIBH)
                .HasForeignKey(e => e.IDLoai);

            modelBuilder.Entity<LOAIHD>()
                .Property(e => e.TenLoai)
                .IsUnicode(false);

            modelBuilder.Entity<LOAIHD>()
                .HasMany(e => e.HOPDONGs)
                .WithOptional(e => e.LOAIHD)
                .HasForeignKey(e => e.IDLoaiHopDong);

            modelBuilder.Entity<LOAITK>()
                .Property(e => e.TenLoai)
                .IsUnicode(false);

            modelBuilder.Entity<LOAITK>()
                .HasMany(e => e.TAIKHOANs)
                .WithOptional(e => e.LOAITK)
                .HasForeignKey(e => e.IDLoai);

            modelBuilder.Entity<LUONG>()
                .Property(e => e.DonVi)
                .IsUnicode(false);

            modelBuilder.Entity<LUONG>()
                .Property(e => e.IDNV)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.CCCD)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.BANGCAPs)
                .WithOptional(e => e.NHANVIEN)
                .HasForeignKey(e => e.IDNV);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.BAOHIEMs)
                .WithOptional(e => e.NHANVIEN)
                .HasForeignKey(e => e.IDNV);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.CHAMCONGs)
                .WithRequired(e => e.NHANVIEN)
                .HasForeignKey(e => e.IDNV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.DAOTAONHANVIENs)
                .WithOptional(e => e.NHANVIEN)
                .HasForeignKey(e => e.IDNV);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.HOPDONGs)
                .WithOptional(e => e.NHANVIEN)
                .HasForeignKey(e => e.IDNV);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.LUONGs)
                .WithRequired(e => e.NHANVIEN)
                .HasForeignKey(e => e.IDNV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.TAIKHOANs)
                .WithOptional(e => e.NHANVIEN)
                .HasForeignKey(e => e.IDNV);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.TKNGANHANGs)
                .WithOptional(e => e.NHANVIEN)
                .HasForeignKey(e => e.IDNV);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.YEUCAUNGHIPHEPs)
                .WithOptional(e => e.NHANVIEN)
                .HasForeignKey(e => e.IDNV);

            modelBuilder.Entity<PHONGBAN>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<PHONGBAN>()
                .HasMany(e => e.NHANVIENs)
                .WithOptional(e => e.PHONGBAN)
                .HasForeignKey(e => e.IDPhongBan);

            modelBuilder.Entity<PHONGBAN>()
                .HasMany(e => e.VITRICVs)
                .WithOptional(e => e.PHONGBAN)
                .HasForeignKey(e => e.IDPhongBan);

            modelBuilder.Entity<PHONGVAN>()
                .Property(e => e.NguoiPhongVan)
                .IsUnicode(false);

            modelBuilder.Entity<PHONGVAN>()
                .Property(e => e.IDUngVien)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.IDNV)
                .IsUnicode(false);

            modelBuilder.Entity<TKNGANHANG>()
                .Property(e => e.SoTaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<TKNGANHANG>()
                .Property(e => e.SoThe)
                .IsUnicode(false);

            modelBuilder.Entity<TKNGANHANG>()
                .Property(e => e.IDNV)
                .IsUnicode(false);

            modelBuilder.Entity<TUYENDUNG>()
                .Property(e => e.IDUngVien)
                .IsUnicode(false);

            modelBuilder.Entity<UNGVIEN>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<UNGVIEN>()
                .Property(e => e.CCCD)
                .IsUnicode(false);

            modelBuilder.Entity<UNGVIEN>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<UNGVIEN>()
                .HasMany(e => e.PHONGVANs)
                .WithOptional(e => e.UNGVIEN)
                .HasForeignKey(e => e.IDUngVien);

            modelBuilder.Entity<UNGVIEN>()
                .HasMany(e => e.TUYENDUNGs)
                .WithOptional(e => e.UNGVIEN)
                .HasForeignKey(e => e.IDUngVien);

            modelBuilder.Entity<VITRICV>()
                .HasMany(e => e.NHANVIENs)
                .WithOptional(e => e.VITRICV)
                .HasForeignKey(e => e.IDViTri);

            modelBuilder.Entity<VITRICV>()
                .HasMany(e => e.TUYENDUNGs)
                .WithOptional(e => e.VITRICV)
                .HasForeignKey(e => e.IDViTri);

            modelBuilder.Entity<YEUCAUNGHIPHEP>()
                .Property(e => e.IDNV)
                .IsUnicode(false);
        }
    }
}
