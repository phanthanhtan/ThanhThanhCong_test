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
    public partial class frmHopDong_in_Main : Form
    {
        public frmHopDong_in_Main()
        {
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Main frm = new Main();
            this.Visible = false;
            frm.Visible = true;
        }
        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Xem_All_Click(object sender, EventArgs e)
        {
            frmHopDong_in frm = new frmHopDong_in("0");
            this.Visible = false;
            frm.Visible = true;
        }

        private void btn_Xem_MaHopDong_Click(object sender, EventArgs e)
        {
            if (txt_MaHopDong.Text != "")
            {
                frmHopDong_in frm = new frmHopDong_in(txt_MaHopDong.Text);
                this.Visible = false;
                frm.Visible = true;
            }
            else
                MessageBox.Show("Chưa nhập mã hợp đồng.");
        }

        private void txt_MaHopDong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
