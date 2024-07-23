namespace SunShine_HRMs.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LUONG")]
    public partial class LUONG
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public double? ThanhTien { get; set; }

        [StringLength(10)]
        public string DonVi { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string IDNV { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
