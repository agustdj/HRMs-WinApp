namespace SunShine_HRMs.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VITRICV")]
    public partial class VITRICV
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VITRICV()
        {
            NHANVIENs = new HashSet<NHANVIEN>();
            TUYENDUNGs = new HashSet<TUYENDUNG>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string TenVitri { get; set; }

        [StringLength(100)]
        public string MoTaCV { get; set; }

        public double? MucLuongCoBan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDang { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HetHan { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        public int? IDPhongBan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHANVIEN> NHANVIENs { get; set; }

        public virtual PHONGBAN PHONGBAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TUYENDUNG> TUYENDUNGs { get; set; }
    }
}
