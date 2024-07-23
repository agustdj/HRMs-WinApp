using System;

namespace SunShine_HRMs.ViewModel
{
    internal class HRMViewModel
    {
        public string ID { get; set; }

        public string HoDem { get; set; }

        public string Ten { get; set; }

        public DateTime? NgaySinh { get; set; }

        public bool? GioiTinh { get; set; }

        public string CCCD { get; set; }

        public string DiaChi { get; set; }

        public string SDT { get; set; }

        public string Email { get; set; }

        public string QueQuan { get; set; }

        public DateTime? NgayTuyenDung { get; set; }

        public int? IDViTri { get; set; }

        public string TenVitri { get; set; }

        public int? IDChucVu { get; set; }

        public string TenChucVu { get; set; }
    }
}
