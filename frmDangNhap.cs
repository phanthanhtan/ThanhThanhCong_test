using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThanhThanhCong_test
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            //không thoát
            if (MessageBox.Show("Bạn chắc chắn muốn thoát?!?", "Thoát chương trình", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
                Application.Exit();
        }
        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            string id = txt_ID.Text;
            string pass = txt_Pass.Text;
            TTC_HopDongThueDatEntities entity = new TTC_HopDongThueDatEntities();
            User u = entity.User.Where(item => item.ID.Equals(id) && item.Pass.Equals(pass)).FirstOrDefault();
            if (u != null)
            {
                Session.id = u.ID;
                Session.permission = u.Permission.ToString();
                Main frm = new Main();
                this.Visible = false;
                frm.Visible = true;
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.");
                frmDangNhap frm = new frmDangNhap();
                this.Visible = false;
                frm.Visible = true;
            }
        }
    }
}
