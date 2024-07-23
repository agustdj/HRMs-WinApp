namespace SunShine_HRMs.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TUYENDUNG")]
    public partial class TUYENDUNG
    {
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDeNghi { get; set; }

        [StringLength(1000)]
        public string ThongTinChiTiet { get; set; }

        public int? IDViTri { get; set; }

        [StringLength(10)]
        public string IDUngVien { get; set; }

        public virtual UNGVIEN UNGVIEN { get; set; }

        public virtual VITRICV VITRICV { get; set; }
    }
}
