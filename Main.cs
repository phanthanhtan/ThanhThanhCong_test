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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            if (Session.permission != "1")
            {
                btn_DanhSachHopDong.Enabled = false;
                btn_Vung.Enabled = false;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            frmDangNhap frm = new frmDangNhap();
            this.Visible = false;
            frm.Visible = true;
        }
        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Vung_Click(object sender, EventArgs e)
        {
            frmVung frm = new frmVung();
            this.Visible = false;
            frm.Visible = true;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            frmHopDong_ChiTiet frm = new frmHopDong_ChiTiet();
            this.Visible = false;
            frm.Visible = true;
        }

        private void btn_DanhSachHopDong_Click(object sender, EventArgs e)
        {
            frmHopDong frm = new frmHopDong();
            this.Visible = false;
            frm.Visible = true;
        }
    }
}
