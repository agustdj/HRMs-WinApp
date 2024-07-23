using SunShine_HRMs.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SunShine_HRMs.View
{
    public partial class frmTrangChinh : Form
    {
        HRMs DBcontext = new HRMs();
        public frmTrangChinh()
        {
            InitializeComponent();
        }

        private void frmTrangChinh_Load(object sender, EventArgs e)
        {
            //cpbNhanVien_load();
            cpbUngVien_load();
            // cpbUVLoai_load();
            chart_load();
        }

        private void chart_load()
        {
            var result = DBcontext.UNGVIENs
                            .Where(u => u.NgayUngTuyen != null)  // không null
                            .GroupBy(u => u.NgayUngTuyen.Value.Month)
                            .Select(g => new { Month = g.Key, Count = g.Count() })
                            .OrderBy(x => x.Month)
                            .ToList();

            chart.ChartAreas.Add(new ChartArea());
            chart.Series.Clear();
            Series series = new Series("Số ứng viên");
            series.ChartType = SeriesChartType.Line;
            //series.BorderColor = Color.FromArgb(255, 128, 0);
            series.BorderWidth = 4;

            foreach (var item in result)
            {
                series.Points.AddXY(item.Month, item.Count);
            }
            chart.Series.Add(series);
        }

        //private void cpbUVLoai_load()
        //{
        //    int SLUngVienLoai = DBcontext.PHONGVANs.Count(pv => pv.KetQua == "Không đạt");
        //    //cpbUVLoai.Size = new Size(180, 180);
        //    cpbUVLoai.Value = SLUngVienLoai;
        //    cpbUVLoai.Maximum = DBcontext.PHONGVANs.Count();
        //    lblSoUVLoai.Text = SLUngVienLoai.ToString();
        //}

        private void cpbUngVien_load()
        {
            int SLUngVien = DBcontext.UNGVIENs.Count();
            //cpbUngVien.Size = new Size(180, 180);
            cpbUngVien.Value = SLUngVien;
            cpbUngVien.Maximum = DBcontext.NHANVIENs.Count();
            lblSoUngVien.Text = SLUngVien.ToString();
        }

        //private void cpbNhanVien_load()
        //{
        //    int SLNhanVien = DBcontext.NHANVIENs.Count();
        //    //cpbNhanVien.Size = new Size(180, 180);
        //    cpbNhanVien.Value = SLNhanVien;
        //    cpbNhanVien.Maximum = SLNhanVien;
        //    lblSoNhanVien.Text = SLNhanVien.ToString();
        //}
    }
}
