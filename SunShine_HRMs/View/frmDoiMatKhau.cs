using SunShine_HRMs.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SunShine_HRMs.View
{
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        HRMs dbcontext = new HRMs();
        bool kiemtra = true;

        private void txtTenDangNhap_Validating(object sender, CancelEventArgs e)
        {
            if(txtTenDangNhap.Text == "")
            {
                errorProvider.SetError(txtTenDangNhap, "Vui lòng nhập tên đăng nhập");
                kiemtra = false;
            }
        }

        private void txtMatKhauMoi_Validating(object sender, CancelEventArgs e)
        {
            if (txtMatKhauMoi.Text == "")
            {
                errorProvider.SetError(txtMatKhauMoi, "Vui lòng nhập mật khẩu mới");
                kiemtra = false;
            }
        }

        private void txtXacnhanMatKhau_Validating(object sender, CancelEventArgs e)
        {
            if (txtXacnhanMatKhau.Text == "")
            {
                errorProvider.SetError(txtXacnhanMatKhau, "Vui lòng xác nhận mật khẩu mới");
                kiemtra = false;
            }
        }


        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (KiemTraMatKhau() == true && kiemtra == true)
            {
                TAIKHOAN tk = dbcontext.TAIKHOANs.FirstOrDefault(p => p.TenDangNhap == txtTenDangNhap.Text);
                if (tk == null)
                    MessageBox.Show("Tên đăng nhập không tồn tại!");
                else
                {
                    tk.MatKhau = txtMatKhauMoi.Text;
                    dbcontext.SaveChanges();
                    MessageBox.Show("Đổi mật khẩu thành công!");
                    frmDangNhap frm = new frmDangNhap();
                    this.Hide();
                    frm.Show();
                }
            }
        }

        private bool KiemTraMatKhau()
        {
            if(txtMatKhauMoi.Text == txtXacnhanMatKhau.Text)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Vui lòng xác minh lại mật khẩu!");
                return false;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmDangNhap frm = new frmDangNhap();
            this.Hide();
            frm.Show();
        }
    }
}
