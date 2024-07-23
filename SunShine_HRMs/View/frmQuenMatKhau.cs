using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twilio;
using Twilio.Types;
using Twilio.TwiML;
using System.Data.Common;
using Twilio.Rest.Api.V2010.Account;

namespace SunShine_HRMs.View
{
    public partial class frmQuenMatKhau : Form
    {
        public frmQuenMatKhau()
        {
            InitializeComponent();
        }

        private void frmQuenMatKhau_Load(object sender, EventArgs e)
        {
            txtSoDienThoai.Focus();
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        private void txtSoDienThoai_Validating(object sender, CancelEventArgs e)
        {
            if (txtSoDienThoai.Text == "")
            {
                errorProvider.SetError(txtSoDienThoai, "Vui lòng nhập số điện thoại!");
            }
        }
        public class randomMa
        {
            static public int ma;
        }
        int random()
        {
            Random rnd = new Random();
            int ma = rnd.Next(100000, 999999);
            return ma;
        }
	
        private void btnGuiMa_Click(object sender, EventArgs e)
        {
            if (txtSoDienThoai.TextLength == 12)
            {
                randomMa.ma = random();
                /*
                try
                {
                   // const string acountsid = "-------secret-----------";
                   // const string autotoken = "--------secret------------";
                    TwilioClient.Init(acountsid, autotoken);
                    var message = MessageResource.Create(body: "Your code: " + randomMa.ma, from: new Twilio.Types.PhoneNumber("+14156305841"), to: new Twilio.Types.PhoneNumber(txtSoDienThoai.Text));
                    MessageBox.Show("Message Sent");
                    MessageBox.Show(randomMa.ma.ToString());
                    frmXacThucMa f2 = new frmXacThucMa();
                    f2.Show();
                }
                catch (Exception ex) { MessageBox.Show("Error" + ex.Message); }
                */
                MessageBox.Show(randomMa.ma.ToString());
                frmXacThucMa frm = new frmXacThucMa();
                this.Hide();
                frm.Show();
            }
            else errorProvider.SetError(txtSoDienThoai, "Số điện thoại không đúng định dạng");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmDangNhap frm = new frmDangNhap();
            this.Hide();
            frm.Show();
        }

    }
}
