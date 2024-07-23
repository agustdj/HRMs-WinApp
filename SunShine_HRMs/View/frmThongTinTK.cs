using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using SunShine_HRMs.Model;

namespace SunShine_HRMs.View
{
    public partial class frmThongTinTK : Form
    {
        HRMs DBContext = new HRMs();
        private string ID_NhanVien;

        bool textboxesEnabled = false;
        public frmThongTinTK(string ID)
        {
            InitializeComponent();
            ID_NhanVien = ID;
        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            LoadThongTinNhanVien();
            SetTextboxesEnabled(false);
        }

        private void LoadThongTinNhanVien()
        {
                var nhanvien = DBContext.NHANVIENs.FirstOrDefault(x => x.ID == ID_NhanVien);
                if (nhanvien == null)
                {
                    MessageBox.Show("Bạn cần đăng nhập để xem thông tin!");
                    return;
                }

                lblTen.Text = nhanvien.HoDem + nhanvien.Ten;

                var chucvu = DBContext.CHUCVUs.FirstOrDefault(x => x.ID == nhanvien.IDChucVu);
                if (chucvu == null) return;
                var vitri = DBContext.VITRICVs.FirstOrDefault(x => x.ID == nhanvien.IDViTri);
                if (vitri == null) return;

                lbVaitro.Text = chucvu.TenChucVu;
                txtID.Text = nhanvien.ID;
                txtTen.Text = nhanvien.HoDem + nhanvien.Ten;
                txtNS.Text = nhanvien.NgaySinh.ToString();
                txtGioiTinh.Text = nhanvien.GioiTinh == true ? "Nam" : "Nữ";
                txtCCCD.Text = nhanvien.CCCD;
                txtSdt.Text = nhanvien.SDT;
                txtVitri.Text = vitri.TenVitri;
                txtChucvu.Text = chucvu.TenChucVu;
                txtEmail.Text = nhanvien.SDT;
                txtDiaChi.Text = nhanvien.DiaChi;
                txtQuequan.Text = nhanvien.QueQuan;
                txtNTD.Text = nhanvien.NgayTuyenDung.ToString();
            
        }

        private void btnThaydoi_Click(object sender, EventArgs e)
        {
            if (!textboxesEnabled)
            {
                SetTextboxesEnabled(true);
                SetTextboxesEnableWithRole();
                btnThaydoi.Text = "Cập Nhật";
            }
            else
            {
                SetTextboxesEnabled(false);
                btnThaydoi.Text = "Thay Đổi";
                CapNhatThongTin();
            }
        }

        private void CapNhatThongTin()
        {
                NHANVIEN nhanvien = DBContext.NHANVIENs.FirstOrDefault(x => x.ID.ToString() == ID_NhanVien);
                if (nhanvien != null)
                {
                    NHANVIEN updateNV = new NHANVIEN();

                    string[] name = txtTen.Text.Split(' ');
                    if (name.Length < 2) return;
                    string Hodem = name[0];
                    string Ten = name[1];

                    DateTime ngayTuyenDung;
                    if (DateTime.TryParseExact(txtNTD.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngayTuyenDung))
                    {
                        updateNV.NgayTuyenDung = ngayTuyenDung;
                    }
                    else
                    {
                        MessageBox.Show("Ngày tuyển dụng không hợp lệ!");
                    }

                    DateTime ngaySinh;
                    if (DateTime.TryParseExact(txtNS.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngaySinh))
                    {
                        updateNV.NgaySinh = ngaySinh;
                    }
                    else
                    {
                        MessageBox.Show("Ngày sinh không hợp lệ!");
                    }

                    updateNV.ID = txtID.Text;
                    updateNV.HoDem = Hodem;
                    updateNV.Ten = Ten;
                    updateNV.NgaySinh = ngaySinh;
                    updateNV.GioiTinh = txtGioiTinh.Text == "Name" ? true : false;
                    updateNV.CCCD = txtCCCD.Text;
                    updateNV.SDT = txtSdt.Text;
                    updateNV.Email = txtEmail.Text;
                    updateNV.DiaChi = txtDiaChi.Text;
                    updateNV.QueQuan = txtQuequan.Text;
                    updateNV.NgayTuyenDung = ngayTuyenDung;

                DBContext.SaveChanges(); 
                    SetTextboxesEnabled(false);
                    LoadThongTinNhanVien();
                    btnThaydoi.Text = "Thay Đổi";
                
            }
        }

        private void SetTextboxesEnabled(bool enable)
        {
            txtID.Enabled = enable;
            txtChucvu.Enabled = enable;
            txtVitri.Enabled = enable;
            txtTen.Enabled = enable;
            txtNS.Enabled = enable;
            txtGioiTinh.Enabled = enable;
            txtCCCD.Enabled = enable;
            txtSdt.Enabled = enable;
            txtEmail.Enabled = enable;
            txtDiaChi.Enabled = enable;
            txtQuequan.Enabled = enable;
            txtNTD.Enabled = enable;
        }

        private void SetTextboxesEnableWithRole()
        {
                var nhanvien = DBContext.NHANVIENs.FirstOrDefault(x => x.ID == ID_NhanVien);
                if (nhanvien == null) return;
                txtID.Enabled = nhanvien.IDChucVu.ToString() != "3" ? true : false;
                txtChucvu.Enabled = nhanvien.IDChucVu.ToString() != "3" ? true : false;
                txtVitri.Enabled = nhanvien.IDChucVu.ToString() != "3" ? true : false;
        }

        private void picProfile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Hình ảnh (*.jpg, *.png)|*.jpg;*.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    // Đọc hình ảnh từ tệp và hiển thị nó trên PictureBox
                    Image image = Image.FromFile(filePath);
                    picProfile.Image = image;

                    // Lưu hình ảnh vào cơ sở dữ liệu
                    NHANVIEN nv = DBContext.NHANVIENs.FirstOrDefault(x => x.ID == ID_NhanVien);
                    nv.AnhProfile = File.ReadAllBytes(filePath);
                    DBContext.SaveChanges();

                }
            }
            HienAnhProfile(ID_NhanVien);
        }
        private void HienAnhProfile(string ID)
        {
            var nhanvien = DBContext.NHANVIENs.FirstOrDefault(x => x.ID == ID); // Thay đổi truy vấn để lấy thông tin từ bảng
            if (nhanvien != null)
            {
                byte[] imageBytes = nhanvien.AnhProfile;
                if (imageBytes != null)
                {
                    using (MemoryStream memoryStream = new MemoryStream(imageBytes))
                    {
                        Image image = Image.FromStream(memoryStream);
                        picProfile.Image = image;
                    }
                }
            }
        }
    }
}
