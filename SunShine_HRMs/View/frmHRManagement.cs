using SunShine_HRMs.Model;
using SunShine_HRMs.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SunShine_HRMs.View
{
    public partial class frmHRManagement : Form
    {
        HRMs db = new HRMs();
        int lastCellClick = -1; 
        public frmHRManagement()
        {
            InitializeComponent();
            cmbViTri.ValueMember = "ID";
            cmbViTri.DisplayMember = "TenViTri";
            cmbViTri.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbChucVu.ValueMember = "ID";
            cmbChucVu.DisplayMember = "TenChucVu";
            cmbChucVu.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbGioiTinh.DisplayMember = "Key"; // Hiển thị "Nam" hoặc "Nữ"
            cmbGioiTinh.ValueMember = "Value"; // Lưu trữ 1 hoặc 0
            cmbGioiTinh.Items.Add(new { Key = "Nam", Value = 1 });
            cmbGioiTinh.Items.Add(new { Key = "Nữ", Value = 0 });
            cmbGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbLoaiTimKiem.DisplayMember = "Key";
            cmbLoaiTimKiem.ValueMember = "Value";
            cmbLoaiTimKiem.Items.Add(new { Key = "Mã NV", Value = 1 });
            cmbLoaiTimKiem.Items.Add(new { Key = "Tên NV", Value = 2 });
        }

        private void frmHRManagement_Load(object sender, EventArgs e)
        {
            dgvDSNhanVien.AutoGenerateColumns = false;
            cmbChucVu.DataSource = db.CHUCVUs.ToList();
            cmbViTri.DataSource = db.VITRICVs.ToList();
            btnXoa.Enabled = false;
            btnCapNhat.Enabled = false;
            dgvDSNhanVien.DataSource = GetHRMViewModels();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var check = false;
            if (string.IsNullOrEmpty(txtID.Text))
            {
                errBlank.SetError(txtID, "*");
                check = true;
            }
            if (string.IsNullOrEmpty(txtHoDem.Text))
            {
                errBlank.SetError(txtHoDem, "*");
                check = true;
            }
            if (string.IsNullOrEmpty(txtTen.Text))
            {
                errBlank.SetError(txtTen, "*");
                check = true;
            }
            if (string.IsNullOrEmpty(txtCCCD.Text))
            {
                errBlank.SetError(txtCCCD, "*");
                check = true;
            }
            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                errBlank.SetError(txtSDT, "*");
                check = true;
            }
            if (string.IsNullOrEmpty(txtCCCD.Text))
            {
                errBlank.SetError(txtCCCD, "*");
                check = true;
            }
            if (string.IsNullOrEmpty(txtQueQuan.Text))
            {
                errBlank.SetError(txtQueQuan, "*");
                check = true;
            }
            if (!check)
            {
                var id = txtID.Text.Trim();
                var hoDem = txtHoDem.Text.Trim();
                var ten = txtTen.Text.Trim();
                var ngaySinh = dtpNgaySinh.Value;
                var cccd = txtCCCD.Text.Trim();
                var diaChi = txtDiaChi.Text.Trim();
                var gioiTinh = (int)cmbGioiTinh.SelectedIndex;
                var sdt = txtSDT.Text.Trim();
                var email = txtEmail.Text.Trim();
                var queQuan = txtQueQuan.Text.Trim();
                var viTri = db.VITRICVs.FirstOrDefault(x => x.ID == (int)cmbViTri.SelectedValue);
                var chucVu = db.CHUCVUs.FirstOrDefault(x => x.ID == (int)cmbChucVu.SelectedValue);
                var ngayTuyen = dtpNgayTuyenDung.Value;
                var existingStaff = db.NHANVIENs.FirstOrDefault(s => s.ID == id);
                if (existingStaff != null)
                {
                    MessageBox.Show("ID Nhân viên đã tồn tại!");
                }
                else
                {
                    NHANVIEN nv = new NHANVIEN()
                    {
                        ID = id,
                        HoDem = hoDem,
                        Ten = ten,
                        NgaySinh = ngaySinh,
                        CCCD = cccd,
                        DiaChi = diaChi,
                        GioiTinh = (gioiTinh==1)?true:false,
                        SDT = sdt,
                        Email = email,
                        QueQuan = queQuan,
                        IDViTri = viTri.ID,
                        IDChucVu = chucVu.ID,
                        NgayTuyenDung = ngayTuyen,
                    };
                    db.NHANVIENs.Add(nv);
                    try
                    {
                        db.SaveChanges();
                        var dsNV = GetHRMViewModels();
                        dgvDSNhanVien.DataSource = dsNV; 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.InnerException?.Message);
                    }
                }
            }
        }

        private void MacDinh()
        {
            txtID.Text =  txtHoDem.Text = txtTen.Text = txtDiaChi.Text
                = txtSDT.Text = txtEmail.Text = txtQueQuan.Text = txtCCCD.Text = string.Empty;
            cmbViTri.SelectedIndex = -1;
            cmbChucVu.SelectedIndex = -1;
            dtpNgaySinh.ResetText();
            dtpNgayTuyenDung.ResetText();
            btnCapNhat.Enabled = btnXoa.Enabled = txtID.Enabled =false;
            btnThem.Enabled = true;
        }

        private List<HRMViewModel> GetHRMViewModels()
        {
            var HRMsList = new List<HRMViewModel>();
            var dsNhanVien = db.NHANVIENs.ToList();
            var dsViTri = db.VITRICVs.ToList();
            var dsChucVu = db.CHUCVUs.ToList();
            HRMsList = (from nv in dsNhanVien
                        join vt in dsViTri on nv.IDViTri equals vt.ID
                        join cv in dsChucVu on nv.IDChucVu equals cv.ID
                        select new HRMViewModel
                        {
                            ID = nv.ID,
                            HoDem = nv.HoDem,
                            Ten = nv.Ten,
                            NgaySinh = nv.NgaySinh,
                            GioiTinh = nv.GioiTinh,
                            CCCD = nv.CCCD,
                            DiaChi = nv.DiaChi,
                            SDT = nv.SDT,
                            Email = nv.Email,
                            QueQuan = nv.QueQuan,
                            NgayTuyenDung = nv.NgayTuyenDung,
                            IDViTri = nv.IDViTri,
                            TenVitri = vt.TenVitri,
                            IDChucVu = nv.IDChucVu,
                            TenChucVu = cv.TenChucVu
                        }
                        ).ToList();
            return HRMsList;
        }

        private void dgvDSNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (lastCellClick == e.RowIndex)
            {
                dgvDSNhanVien.ClearSelection();
                MacDinh();
                txtID.Enabled = true;
                lastCellClick = -1;
            }
            else if (e.RowIndex >= 0)
            {
                lastCellClick = e.RowIndex;
                btnThem.Enabled = false;
                btnXoa.Enabled = true;
                btnCapNhat.Enabled = true;
                txtID.Enabled = false;
                DataGridViewRow selectedRow = dgvDSNhanVien.Rows[e.RowIndex];

                txtID.Text = selectedRow.Cells["colID"].Value.ToString();
                txtHoDem.Text = selectedRow.Cells["colHoDem"].Value.ToString();
                txtTen.Text = selectedRow.Cells["colTen"].Value.ToString();
                dtpNgaySinh.Value = (DateTime)selectedRow.Cells["colNgaySinh"].Value;
                txtCCCD.Text = selectedRow.Cells["colCCCD"].Value.ToString();
                txtDiaChi.Text = selectedRow.Cells["colDiaChi"].Value.ToString();

                bool gioiTinhValue = (bool)selectedRow.Cells["colGioiTinh"].Value;
                cmbGioiTinh.SelectedIndex = gioiTinhValue==true?1:0;

                txtSDT.Text = selectedRow.Cells["colSDT"].Value.ToString();
                txtEmail.Text = selectedRow.Cells["colEmail"].Value.ToString();
                txtQueQuan.Text = selectedRow.Cells["colQueQuan"].Value.ToString();
                cmbViTri.SelectedValue = selectedRow.Cells["colIDViTri"].Value;
                cmbChucVu.SelectedValue = selectedRow.Cells["colIDChucVu"].Value;
                dtpNgayTuyenDung.Value = (DateTime)selectedRow.Cells["colNgayTuyenDung"].Value;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id = txtID.Text.Trim();
            XoaNhanVien(id);
            dgvDSNhanVien.DataSource = GetHRMViewModels();
        }

        private void XoaNhanVien(string id)
        {
            var existingNhanVien = db.NHANVIENs.FirstOrDefault(nv => nv.ID == id);
            if (existingNhanVien != null)
            {
                db.NHANVIENs.Remove(existingNhanVien);

                db.SaveChanges();
                MacDinh();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            if (cmbLoaiTimKiem.SelectedIndex >= 0)
            {
                int loaiTimKiem = (int)cmbLoaiTimKiem.SelectedIndex+1;
                if (!string.IsNullOrEmpty(keyword))
                {
                    dgvDSNhanVien.DataSource = SearchNhanVien(keyword, loaiTimKiem);
                }
                else
                {
                    // Nếu ô tìm kiếm trống, hiển thị toàn bộ danh sách nhân viên
                    dgvDSNhanVien.DataSource = GetHRMViewModels();
                }
            }
            else
            {
                MessageBox.Show("DS Nhân viên trống");
            }
        }

        private List<HRMViewModel> SearchNhanVien(string keyword, int loaiTimKiem)
        {
            var dsNhanVien = GetHRMViewModels();
            switch(loaiTimKiem)
            {
                case 1:
                    dsNhanVien = dsNhanVien.Where(nv => nv.ID.Contains(keyword)).ToList();
                    break;
                case 2: 
                    dsNhanVien = dsNhanVien.Where(nv => nv.Ten.Contains(keyword)).ToList();
                    break;
            }
            return dsNhanVien;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string id = txtID.Text.Trim();
            var existingNhanVien = db.NHANVIENs.FirstOrDefault(nv => nv.ID == id);

            if (existingNhanVien != null)
            {
                existingNhanVien.HoDem = txtHoDem.Text.Trim();
                existingNhanVien.Ten = txtTen.Text.Trim();
                existingNhanVien.NgaySinh = dtpNgaySinh.Value;
                existingNhanVien.CCCD = txtCCCD.Text.Trim();
                existingNhanVien.DiaChi = txtDiaChi.Text.Trim();
                existingNhanVien.GioiTinh = cmbGioiTinh.SelectedIndex == 1; // 1 là Nam, 0 là Nữ
                existingNhanVien.SDT = txtSDT.Text.Trim();
                existingNhanVien.Email = txtEmail.Text.Trim();
                existingNhanVien.QueQuan = txtQueQuan.Text.Trim();
                existingNhanVien.IDViTri = (int)cmbViTri.SelectedValue;
                existingNhanVien.IDChucVu = (int)cmbChucVu.SelectedValue;
                existingNhanVien.NgayTuyenDung = dtpNgayTuyenDung.Value;
                try
                {
                    db.SaveChanges();
                    MessageBox.Show("Cập nhật thông tin thành công!");
                    dgvDSNhanVien.DataSource = GetHRMViewModels();
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật nhân viên: " + ex.InnerException?.Message);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên có ID: " + id);
            }
        }
    }
}