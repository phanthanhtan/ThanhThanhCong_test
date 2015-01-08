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
    public partial class frmHopDong : Form
    {
        public frmHopDong()
        {
            InitializeComponent();
            loadAll_HopDong();
        }

        private void loadAll_HopDong()
        {
            dataGridView_HopDong.Rows.Clear();
            foreach (DataGridViewColumn col in dataGridView_HopDong.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dataGridView_HopDong.Columns["MaHopDong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_HopDong.Columns["SoVu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_HopDong.Columns["TuVu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_HopDong.Columns["DonGiaThue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView_HopDong.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView_HopDong.Columns["UngTruoc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            TTC_HopDongThueDatEntities entity = new TTC_HopDongThueDatEntities();
            List<HopDong> listHopDong = entity.HopDong.OrderByDescending(item => item.MaHopDong).ToList();
            foreach (HopDong hd in listHopDong)
            {
                dataGridView_HopDong.Rows.Add(hd.MaHopDong, hd.HoTen_A1, hd.HoTen_B1, hd.SoVu, hd.TuVu, hd.DonGiaThue, hd.TongTien, hd.UngTruoc);
            }
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

        private void btn_Them_Click(object sender, EventArgs e)
        {
            frmHopDong_ChiTiet frm = new frmHopDong_ChiTiet();
            this.Visible = false;
            frm.Visible = true;
        }

        private void btn_ChiTiet_Click(object sender, EventArgs e)
        {
            string maHopDong = "";
            try
            {
                maHopDong = dataGridView_HopDong.SelectedRows[0].Cells["MaHopDong"].Value.ToString();
                frmHopDong_ChiTiet frm = new frmHopDong_ChiTiet(maHopDong);
                this.Visible = false;
                frm.Visible = true;
            }
            catch
            {
                if (maHopDong == "")
                    MessageBox.Show("Chưa chọn hợp đồng/Hoặc không có hợp đồng để xem chi tiết!");
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string maHopDong = "";
            try
            {
                maHopDong = dataGridView_HopDong.SelectedRows[0].Cells["MaHopDong"].Value.ToString();
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa?!?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        int _maHopDong = int.Parse(maHopDong);
                        TTC_HopDongThueDatEntities entity = new TTC_HopDongThueDatEntities();
                        List<HopDong_ChiTiet> listHDCT = entity.HopDong_ChiTiet.Where(item => item.MaHopDong == _maHopDong).ToList();
                        foreach (HopDong_ChiTiet hdct in listHDCT)
                        {
                            HopDong_ChiTiet _hdct = entity.HopDong_ChiTiet.Single(item => item.MaHopDong_ChiTiet == hdct.MaHopDong_ChiTiet);
                            entity.HopDong_ChiTiet.Remove(_hdct);
                            entity.SaveChanges();
                        }
                        HopDong HD = entity.HopDong.Single(item => item.MaHopDong == _maHopDong);
                        entity.HopDong.Remove(HD);
                        entity.SaveChanges();
                        MessageBox.Show("Xóa thành công!");
                        loadAll_HopDong();
                    }
                    catch
                    {
                        MessageBox.Show("Có lỗi xảy ra trogn quá trình xóa. Vui lòng thao tác lại!");
                    }
                }
            }
            catch
            {
                if (maHopDong == "")
                    MessageBox.Show("Chưa chọn hợp đồng/Hoặc không có hợp đồng để xóa!");
            }
        }
    }
}
