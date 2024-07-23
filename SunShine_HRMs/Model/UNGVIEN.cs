namespace SunShine_HRMs.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UNGVIEN")]
    public partial class UNGVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UNGVIEN()
        {
            PHONGVANs = new HashSet<PHONGVAN>();
            TUYENDUNGs = new HashSet<TUYENDUNG>();
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

        [StringLength(12)]
        public string CCCD { get; set; }

        [StringLength(300)]
        public string DiaChi { get; set; }

        [StringLength(100)]
        public string SDT { get; set; }

        [StringLength(300)]
        public string Email { get; set; }

        [StringLength(300)]
        public string QueQuan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayUngTuyen { get; set; }

        [StringLength(300)]
        public string LinkHoSo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHONGVAN> PHONGVANs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TUYENDUNG> TUYENDUNGs { get; set; }
    }
}
