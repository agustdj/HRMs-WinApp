namespace SunShine_HRMs.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHOADAOTAO")]
    public partial class KHOADAOTAO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHOADAOTAO()
        {
            DAOTAONHANVIENs = new HashSet<DAOTAONHANVIEN>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string TenKhoa { get; set; }

        [StringLength(1000)]
        public string MoTa { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayBatDau { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayKetThuc { get; set; }

        [StringLength(50)]
        public string NguoiHuongDan { get; set; }

        [StringLength(300)]
        public string DiaChi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DAOTAONHANVIEN> DAOTAONHANVIENs { get; set; }
    }
}
