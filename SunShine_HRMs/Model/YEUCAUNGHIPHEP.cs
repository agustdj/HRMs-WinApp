namespace SunShine_HRMs.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YEUCAUNGHIPHEP")]
    public partial class YEUCAUNGHIPHEP
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string LoaiNghiPhep { get; set; }

        [StringLength(400)]
        public string LyDo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayBatDau { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayKetThuc { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        [StringLength(10)]
        public string IDNV { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
