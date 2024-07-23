namespace SunShine_HRMs.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DAOTAONHANVIEN")]
    public partial class DAOTAONHANVIEN
    {
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayHoanThanh { get; set; }

        [StringLength(10)]
        public string IDNV { get; set; }

        public int? IDKHOADT { get; set; }

        public virtual KHOADAOTAO KHOADAOTAO { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
