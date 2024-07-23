namespace SunShine_HRMs.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAIKHOAN")]
    public partial class TAIKHOAN
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string TenDangNhap { get; set; }

        [StringLength(50)]
        public string MatKhau { get; set; }

        public int? IDLoai { get; set; }

        [StringLength(10)]
        public string IDNV { get; set; }

        public virtual LOAITK LOAITK { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
