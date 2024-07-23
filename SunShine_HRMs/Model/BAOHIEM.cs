namespace SunShine_HRMs.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BAOHIEM")]
    public partial class BAOHIEM
    {
        [Key]
        public int IDSoBaoHiem { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayHienHanh { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        public int? IDLoai { get; set; }

        [StringLength(10)]
        public string IDNV { get; set; }

        public virtual LOAIBH LOAIBH { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
