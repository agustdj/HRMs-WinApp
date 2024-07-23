using SunShine_HRMs.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SunShine_HRMs
{
    public partial class frmChamCong : Form
    {
        public frmChamCong()
        {
            InitializeComponent();
        }
        HRMs dbcontect = new HRMs();
        private void btnChonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.InitialDirectory = "";
            op.Filter = "Excel Sheet (*.xls, *.xlsx)|*.xls;*.xlsx";
            op.FilterIndex = 0;
            op.RestoreDirectory = true;

            if (op.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            else
            {
                string filepath = op.FileName;

                string con = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties='Excel 12.0 Xml;HDR=YES';";
                con = string.Format(con, filepath, "yes");
                OleDbConnection excelconnection = new OleDbConnection(con);
                excelconnection.Open();
                DataTable dt = excelconnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string name = dt.Rows[0]["TABLE_NAME"].ToString();
                OleDbCommand com = new OleDbCommand("Select * from[" + name + "]", excelconnection);
                OleDbDataAdapter sda = new OleDbDataAdapter(com);
                DataTable data = new DataTable();
                sda.Fill(data);
                excelconnection.Close();
                dgvChamCong.DataSource = data;
            }
        }
        private void btnChamCong_Click_1(object sender, EventArgs e)
        {
         //   int songaylam = 0, solantre = 0, songaynghi = 0;
            var userSums = dgvChamCong.Rows.Cast<DataGridViewRow>()
            .GroupBy(row => row.Cells[0].Value.ToString())
            .Select(g => new
            {
                IDNV = g.Key,
                songaylam = g.Sum(row => Convert.ToInt32(row.Cells[5].Value)),
                solantre = g.Count(row => ((row.Cells[6].Value.ToString().CompareTo(1.ToString()) == 0))),
                songaynghi = g.Count(row => ((row.Cells[7].Value.ToString().CompareTo(1.ToString()) == 0)))
            }).ToList();
            dgvKetQua.DataSource = userSums;
            DateTime tg = (DateTime)dgvChamCong.Rows[0].Cells[1].Value;
            MessageBox.Show(tg.Month.ToString()+tg.Year.ToString());
            try
            {
                foreach (var item in userSums)
                {
                    CHAMCONG cc = new CHAMCONG();
                    cc.ID = Convert.ToInt32(tg.Month.ToString() + tg.Year.ToString());
                    cc.IDNV = item.IDNV;
                    cc.SoNgayLam = item.songaylam;
                    cc.SoNgayNghi = item.songaynghi;
                    cc.SoLanTre = item.solantre;
                    cc.ThoiGian = tg.Date;
                    dbcontect.CHAMCONGs.Add(cc);
                }
                dbcontect.SaveChanges();
                MessageBox.Show("Đã lưu dữ liệu thành công!");
            } catch(Exception ex)
            {
                MessageBox.Show("Dữ liệu đã tồn tại!" +ex.Message);
            }
        }

    }
}   

