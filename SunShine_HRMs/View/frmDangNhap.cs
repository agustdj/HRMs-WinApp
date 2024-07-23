using SunShine_HRMs.Model;
using SunShine_HRMs.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SunShine_HRMs
{
    public partial class frmDangNhap : Form
    {
        public int ID_Quyen_Nguoi_Dung { get; private set; }
        public string ID_NhanVien { get; private set; }
        public frmDangNhap()
        {
            InitializeComponent();
        }
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        HRMs dbcontext = new HRMs();
        bool kiemtra = true;

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (txtUsername.Text == "")
            {
                errorProvider.SetError(txtUsername, "Vui lòng nhập tên đăng nhập!");
                kiemtra = false;
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text == "")
            {
                errorProvider.SetError(txtPassword, "Vui lòng nhập mật khẩu!");
                kiemtra = false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (kiemtra == true)
            {
                TAIKHOAN tk = dbcontext.TAIKHOANs.FirstOrDefault(p => p.TenDangNhap == txtUsername.Text && p.MatKhau == txtPassword.Text);
                if (tk != null)
                {
                    ID_NhanVien = tk.IDNV;
                    ID_Quyen_Nguoi_Dung = tk.LOAITK.ID;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sai thông tin đăng nhập");
                }
            }
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPass.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
                txtPassword.UseSystemPasswordChar = true;
        }
        private void lblQuenMatKhau_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmQuenMatKhau frm = new frmQuenMatKhau();
            frm.Show();
        }

    }
}
