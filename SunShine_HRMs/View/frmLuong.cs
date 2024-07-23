using SunShine_HRMs.Model;
using SunShine_HRMs.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twilio.Rest.Api.V2010.Account.Usage.Record;
using static System.Net.WebRequestMethods;

namespace SunShine_HRMs.FILE
{
    public partial class frmLuong : Form
    {
        public frmLuong()
        {
            InitializeComponent();
        }

        HRMs dbcontext = new HRMs();

        static DateTime tg = DateTime.Now;
        static int day = Convert.ToInt32(tg.Day.ToString());
        static int month = Convert.ToInt32(tg.Month.ToString());
        static int year = Convert.ToInt32(tg.Year.ToString());
        private void frmLuong_Load(object sender, EventArgs e)
        {
        //    MessageBox.Show(day.ToString());
            //    int date = Convert.ToInt32((month-1).ToString()+year.ToString());
            int date = 92023;
        //    if (day == 1)
            {
                try
                {
                    foreach (var item in layDSLuong(date))
                    {
                        {
                            dbcontext.LUONGs.Add(
                                new LUONG
                                {
                                    ID = date,
                                    IDNV = item.IDNV,
                                    DonVi = item.DonVi,
                                    ThanhTien = item.ThanhTien,
                                });
                            dbcontext.SaveChanges();
                        }
                    }
                    dgvLuong.DataSource = layDSLuong(date);
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private List<DANHSACHLUONG> layDSLuong(int time)
        {
            return (from nv in dbcontext.NHANVIENs.ToList()
                    join cv in dbcontext.CHUCVUs.ToList()
                    on nv.IDChucVu equals cv.ID
                    join vt in dbcontext.VITRICVs.ToList()
                    on nv.IDViTri equals vt.ID
                    join cc in dbcontext.CHAMCONGs.ToList()
                    on nv.ID equals cc.IDNV
                    where cc.ID == time
                    select new DANHSACHLUONG
                    {
                        ID = time,
                        ThanhTien = Convert.ToInt32((((vt.MucLuongCoBan * cv.HeSoLuong) / 26) * cc.SoNgayLam + cv.PhuCapChucVu)),
                        DonVi = "VND",
                        IDNV = nv.ID,
                        HoDem = nv.HoDem,
                        Ten = nv.Ten,
                        date = cc.ThoiGian
                    }).ToList();
        }

        private void dtpNgayLuong_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime value = dtpNgayLuong.Value;
                dtpNgayLuong.Value = new DateTime(value.Year, value.Month, value.Day);
                int month = (int)value.Month;
                int year = (int)value.Year;
                dgvLuong.DataSource = layDSLuong(Convert.ToInt32(month.ToString() + year.ToString()));
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
