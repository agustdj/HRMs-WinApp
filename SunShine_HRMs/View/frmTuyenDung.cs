using SunShine_HRMs.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace SunShine_HRMs.View
{
    public partial class frmTuyenDung : Form
    {
        HRMs DBcontext = new HRMs();
        public frmTuyenDung()
        {
            InitializeComponent();
        }

        private void frmTuyenDung_Load(object sender, EventArgs e)
        {
            Loard_dgv();
            Load_CMBSapXep();
        }
        public class GenderOption
        {
            public int Value { get; set; }
            public string Text { get; set; }
        }
        private void Load_CMBSapXep()
        {
            cmbSapXep.Items.Add("Mặc định");
            cmbSapXep.Items.Add("Tên");
            cmbSapXep.Items.Add("Ngày ứng tuyển");

            List<GenderOption> genderOptions = new List<GenderOption>
            {
            new GenderOption { Value = 1, Text = "Nam" },
            new GenderOption { Value = 0, Text = "Nữ" }
            };

            cmbPhai.DataSource = genderOptions;
            cmbPhai.DisplayMember = "Text"; // Hiển thị văn bản trong ComboBox
            cmbPhai.ValueMember = "Value"; // Giá trị thực tế
        }
        private void Loard_dgv()
        {
            dgvTTTuyenDung.DataSource = DBcontext.UNGVIENs
                .Select(uv => new
                {
                    uv.NgayUngTuyen,
                    uv.HoDem,
                    uv.Ten,
                    uv.NgaySinh,
                    GioiTinh = (bool)uv.GioiTinh ? "Nam" : "Nữ",
                    uv.CCCD,
                    uv.SDT,
                    uv.Email,
                    uv.QueQuan,
                    uv.DiaChi
                })
                .ToList();
            foreach (DataGridViewColumn column in dgvTTTuyenDung.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Đặt AutoSizeMode cho từng cột
            }
        }
        private void cmbSapXep_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = cmbSapXep.SelectedItem.ToString();

            // Xác định cách sắp xếp dữ liệu dựa trên tùy chọn được chọn
            if (selectedOption == "Họ tên")
            {
                dgvTTTuyenDung.Sort(dgvTTTuyenDung.Columns["Ten"], ListSortDirection.Ascending);
            }
            else if (selectedOption == "Ngày ứng tuyển")
            {
                dgvTTTuyenDung.Sort(dgvTTTuyenDung.Columns["NgayUngTuyen"], ListSortDirection.Ascending);
            }
        }

        private void dgvTTTuyenDung_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvTTTuyenDung.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White; // Đặt lại màu nền mặc định
            }

        }

        private void dgvTTTuyenDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvTTTuyenDung.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(181, 222, 232);
            }
        }

        private void ThemUngVien()
        {

            if (string.IsNullOrEmpty(txtHo.Text) ||
                string.IsNullOrEmpty(txtTen.Text) ||
                string.IsNullOrEmpty(txtCCCD.Text) ||
                string.IsNullOrEmpty(txtDienThoai.Text) ||
                string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtDiaChi.Text) ||
                string.IsNullOrEmpty(txtQueQuan.Text) ||
                string.IsNullOrEmpty(txtQueQuan.Text) ||

            string.IsNullOrEmpty(cmbPhai.SelectedValue?.ToString()))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin hợp lệ!", "Thông báo");
                return;
            }

            UNGVIEN uv = new UNGVIEN()
            {
                HoDem = txtHo.Text,
                Ten = txtTen.Text,
                CCCD = txtCCCD.Text,
                DiaChi = txtDiaChi.Text,
                QueQuan = txtQueQuan.Text,
                SDT = txtDienThoai.Text,
                Email = txtEmail.Text,
                GioiTinh = (bool?)cmbPhai.SelectedValue,
            };

            if (KiemTraTonTai(uv, DBcontext) != true)
            {
                DBcontext.UNGVIENs.Add(uv);
                DBcontext.SaveChanges();
                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo");
            }
            else
            {
                MessageBox.Show("Sinh viên này đã tồn tại!", "Thông báo");
            }

        }

        private bool KiemTraTonTai(UNGVIEN uv, HRMs DBcontext)
        {
            if (uv is null)
            {
                MessageBox.Show("KiemTraTonTai that bai!");
            }
            var existingUV = DBcontext.UNGVIENs.FirstOrDefault(u => u.ID == uv.ID);
            return existingUV != null;
        }

    }
}
