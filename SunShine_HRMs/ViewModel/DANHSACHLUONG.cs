using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunShine_HRMs.ViewModel
{
    internal class DANHSACHLUONG
    {
        public int ID { get; set; }

        public double? ThanhTien { get; set; }

        public string DonVi { get; set; }

        public string IDNV { get; set; }

        public string HoDem { get; set; }

        public string Ten { get; set; }

        public DateTime? date { get; set; }
    }
}
