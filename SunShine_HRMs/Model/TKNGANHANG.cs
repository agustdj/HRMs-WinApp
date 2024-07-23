namespace SunShine_HRMs.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TKNGANHANG")]
    public partial class TKNGANHANG
    {
        public int ID { get; set; }

        [StringLength(20)]
        public string SoTaiKhoan { get; set; }

        [StringLength(50)]
        public string TenNganHang { get; set; }

        [StringLength(50)]
        public string SoThe { get; set; }

        [StringLength(10)]
        public string IDNV { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
