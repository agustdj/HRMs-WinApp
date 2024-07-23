namespace SunShine_HRMs.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            BANGCAPs = new HashSet<BANGCAP>();
            BAOHIEMs = new HashSet<BAOHIEM>();
            CHAMCONGs = new HashSet<CHAMCONG>();
            DAOTAONHANVIENs = new HashSet<DAOTAONHANVIEN>();
            HOPDONGs = new HashSet<HOPDONG>();
            LUONGs = new HashSet<LUONG>();
            TAIKHOANs = new HashSet<TAIKHOAN>();
            TKNGANHANGs = new HashSet<TKNGANHANG>();
            YEUCAUNGHIPHEPs = new HashSet<YEUCAUNGHIPHEP>();
        }

        [StringLength(10)]
        public string ID { get; set; }

        [StringLength(30)]
        public string HoDem { get; set; }

        [StringLength(20)]
        public string Ten { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        public bool? GioiTinh { get; set; }

        [StringLength(20)]
        public string CCCD { get; set; }

        [StringLength(300)]
        public string DiaChi { get; set; }

        [StringLength(15)]
        public string SDT { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(300)]
        public string QueQuan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTuyenDung { get; set; }

        [Column(TypeName = "image")]
        public byte[] AnhProfile { get; set; }

        public int? IDViTri { get; set; }

        public int? IDChucVu { get; set; }

        public int? IDPhongBan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BANGCAP> BANGCAPs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAOHIEM> BAOHIEMs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHAMCONG> CHAMCONGs { get; set; }

        public virtual CHUCVU CHUCVU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DAOTAONHANVIEN> DAOTAONHANVIENs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOPDONG> HOPDONGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LUONG> LUONGs { get; set; }

        public virtual PHONGBAN PHONGBAN { get; set; }

        public virtual VITRICV VITRICV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TAIKHOAN> TAIKHOANs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TKNGANHANG> TKNGANHANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<YEUCAUNGHIPHEP> YEUCAUNGHIPHEPs { get; set; }
    }
}
