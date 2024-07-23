//using SunShine_HRMs.View;
using SunShine_HRMs.FILE;
using SunShine_HRMs.Model;
using SunShine_HRMs.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SunShine_HRMs
{
    public partial class frmTrangChu : Form
    {
        public frmDangNhap loginForm = null;
        private frmTrangChinh frmChinh = null;
        private frmTuyenDung frmTDung = null;
        private frmThongTinTK frmProfile = null;

        int Quyen_Nguoi_Dung;
        string ID_NhanVien;

        bool SidebarExpand;

        HRMs DBcontext = new HRMs();

        public frmTrangChu()
        {
            InitializeComponent();
        }

        //Error
        private void SidebarTransition_Tick(object sender, EventArgs e)
        {
            if (SidebarExpand)
            {
                pnlSidebar.Width -= 2;

                if (pnlSidebar.Width <= 60)
                {
                    SidebarExpand = false;
                    SidebarTransitionTimer.Stop();
                }
                //Ẩn đi các thành phần không cần thiết
                lblMainMenu.Visible = false;
                pnlTuyenDung.Visible = false;
                pnlToChuc.Visible = false;
                pnlLogo.Visible = false;
            }
            else
            {
                pnlSidebar.Width += 2;
                if (pnlSidebar.Width >= 164)
                {
                    SidebarExpand = true;
                    SidebarTransitionTimer.Stop();
                }
                lblMainMenu.Visible = true;
                pnlTuyenDung.Visible = true;
                pnlToChuc.Visible = true;
                pnlLogo.Visible = true;
            }
        }


        private void btnHam_Click(object sender, EventArgs e)
        {
            SidebarTransitionTimer.Start();
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            this.Hide();
            loginForm = new frmDangNhap();
            loginForm.ShowDialog();
            //Có thể dùng cách khác là cho : public frmTrangChu(String Quyen_Nguoi_Dung, int ID_NhanVien)
            Quyen_Nguoi_Dung = loginForm.ID_Quyen_Nguoi_Dung;
            ID_NhanVien = loginForm.ID_NhanVien;

            btnDashboard_Click(sender, e);
            HienAnhProfile(ID_NhanVien);
            this.Show();
        }
        private void HienAnhProfile(string ID)
        {
            var nhanvien = DBcontext.NHANVIENs.FirstOrDefault(x => x.ID == ID);
            if (nhanvien != null)
            {
                byte[] imageBytes = nhanvien.AnhProfile;
                if (imageBytes != null)
                {
                    using (MemoryStream memoryStream = new MemoryStream(imageBytes))
                    {
                        Image image = Image.FromStream(memoryStream);
                        btnProfile.Image = image;
                    }
                }
            }
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            if (frmChinh == null || frmChinh.IsDisposed)
            {
                frmChinh = new frmTrangChinh();
                //frmChinh.FormBorderStyle = FormBorderStyle.None;
                //frmChinh.ControlBox = false;
                //frmChinh.WindowState = FormWindowState.Maximized;
                frmChinh.MdiParent = this;
                frmChinh.Show();
            }
            else
            {
                frmChinh.BringToFront();
            }
        }

        private void btnTuyendung_Click(object sender, EventArgs e)
        {
            if (frmTDung == null || frmTDung.IsDisposed)
            {
                frmTDung = new frmTuyenDung();
                //frmTDung.FormBorderStyle = FormBorderStyle.None;
                //frmTDung.ControlBox = false;
                //frmTDung.WindowState = FormWindowState.Maximized;
                frmTDung.MdiParent = this;
                frmTDung.Show();
            }
            else
            {
                frmTDung.BringToFront();
            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            if (frmProfile == null || frmProfile.IsDisposed)
            {
                frmProfile = new frmThongTinTK(ID_NhanVien);
                //frmProfile.FormBorderStyle = FormBorderStyle.None;
                //frmProfile.ControlBox = false;
                //frmProfile.WindowState = FormWindowState.Maximized;
                frmProfile.ShowDialog();
            }
            else
            {
                frmProfile.BringToFront();
            }
        }

        private void checkActivatedForm(Form frm)
        {
            bool check = false;
            foreach (var item in MdiChildren)
            {
                if (item.GetType() == frm.GetType())
                {
                    item.Activate();
                    check = true;
                }
            }
            if (!check)
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            frmHRManagement frm = new frmHRManagement();
            checkActivatedForm(frm);
        }

        private void btnDuAn_Click(object sender, EventArgs e)
        {
            frmChamCong frm = new frmChamCong();    
            checkActivatedForm(frm);
        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            frmLuong frm = new frmLuong();
            checkActivatedForm(frm);
        }
    }

}