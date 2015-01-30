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
    public partial class frmHopDong_in : Form
    {
        public frmHopDong_in()
        {
            InitializeComponent();
        }

        public frmHopDong_in(string maHopDong)
        {
            InitializeComponent();
            TTC_HopDongThueDatEntities entity = new TTC_HopDongThueDatEntities();
            List<HopDong_in> list_hd_in = null;
            if (maHopDong != "0")
            {
                label2.Text = maHopDong;
                int mhd = int.Parse(maHopDong);
                list_hd_in = entity.HopDong_in.Where(item => item.MaHopDong == mhd).ToList();
            }
            else
            {
                label1.Text = "";
                label2.Text = "Xem tất cả";
                list_hd_in = entity.HopDong_in.OrderByDescending(item => item.MaHopDong).ToList();
            }
            foreach (HopDong_in hd_in in list_hd_in)
            {
                dataGridView_HopDong_in.Rows.Add(hd_in.MaHopDong + " - " + hd_in.UserID, hd_in.Time);
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            frmHopDong frm = new frmHopDong();
            this.Visible = false;
            frm.Visible = true;
        }

        private void btn_DanhSachHopDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_XemSoLanin_Click(object sender, EventArgs e)
        {
            frmHopDong_in_Main frm = new frmHopDong_in_Main();
            this.Visible = false;
            frm.Visible = true;
        }
    }
}
