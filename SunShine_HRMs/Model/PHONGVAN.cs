namespace SunShine_HRMs.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHONGVAN")]
    public partial class PHONGVAN
    {
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayPhongVan { get; set; }

        [StringLength(10)]
        public string NguoiPhongVan { get; set; }

        [StringLength(400)]
        public string GhiChu { get; set; }

        [StringLength(10)]
        public string IDUngVien { get; set; }

        [StringLength(50)]
        public string KetQua { get; set; }

        public virtual UNGVIEN UNGVIEN { get; set; }
    }
}
