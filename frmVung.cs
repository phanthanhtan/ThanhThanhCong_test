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
    public partial class frmVung : Form
    {
        public frmVung()
        {
            InitializeComponent();
            Disable();
            loadAll_Vung();
        }

        private void Disable()
        {
            txt_MaVung.ReadOnly = true;

            lb_MaVung.Enabled = false;
            txt_MaVung.Enabled = false;
            txt_MaVung.Text = "";
            lb_TenVung.Enabled = false;
            txt_TenVung.Enabled = false;
            txt_TenVung.Text = "";

            btn_Luu.Enabled = false;
            btn_Huy.Enabled = false;
        }
        private void Enable()
        {
            lb_MaVung.Enabled = true;
            txt_MaVung.Enabled = true;
            lb_TenVung.Enabled = true;
            txt_TenVung.Enabled = true;

            btn_Luu.Enabled = true;
            btn_Huy.Enabled = true;
        }

        private void loadAll_Vung()
        {
            dataGridView_Vung.Rows.Clear();
            foreach (DataGridViewColumn col in dataGridView_Vung.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dataGridView_Vung.Columns["MaVung"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_Vung.Columns["TenVung"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            TTC_HopDongThueDatEntities entity = new TTC_HopDongThueDatEntities();
            List<Vung> listVung = entity.Vung.OrderBy(item => item.MaVung).ToList();
            foreach (Vung v in listVung)
            {
                dataGridView_Vung.Rows.Add(v.MaVung, v.TenVung);
            }
            load_Vung();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            Disable();
            Enable();
            txt_MaVung.ReadOnly = false;
            btn_Luu.Text = "Thêm";
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            if (btn_Luu.Text == "Thêm")
            {
                txt_MaVung.Text = "";
                txt_TenVung.Text = "";
            }
            else
            {
                load_Vung();
            }
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_MaVung.Text != "" && txt_TenVung.Text != "")
                {
                    int check = 0;//nếu có lỗi => không Disable
                    Vung v = new Vung();
                    v.MaVung = txt_MaVung.Text;
                    v.TenVung = txt_TenVung.Text;

                    TTC_HopDongThueDatEntities entity = new TTC_HopDongThueDatEntities();
                    try//them
                    {
                        entity.Vung.Add(v);
                        entity.SaveChanges();
                        MessageBox.Show("Thêm thành công!");
                        check = 1;
                    }
                    catch
                    {
                        if (btn_Luu.Text == "Thêm")
                        {
                            MessageBox.Show("Có lỗi xảy ra trong quá trình thêm/Mã vùng bạn muốn thêm có thể đã có. Vui lòng thao tác lại!");
                        }
                        else//sửa
                        {
                            try
                            {
                                entity.Vung.Attach(v);
                                entity.Entry(v).State = EntityState.Modified;
                                entity.SaveChanges();
                                MessageBox.Show("Sửa thành công!");
                                check = 1;
                            }
                            catch
                            {
                                MessageBox.Show("Có lỗi xảy ra trong quá trình sửa. Vui lòng thao tác lại!");
                            }
                        }
                    }
                    if (check == 1)
                    {
                        Disable();
                        loadAll_Vung();
                    }
                }
                else
                {
                    MessageBox.Show("Chưa nhập mã vùng hoặc tên vùng!");
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình xử lý. Vui lòng thao tác lại!");
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                Disable();
                int check = 0;//kiem tra xem co chon vung ben dataGV chua
                string maVung = "";
                string tenVung = "";
                try
                {
                    maVung = dataGridView_Vung.SelectedRows[0].Cells[0].Value.ToString();
                    tenVung = dataGridView_Vung.SelectedRows[0].Cells[1].Value.ToString();
                    check = 1;
                    //neu maVung == "" => catch
                }
                catch
                {
                    check = 0;
                    MessageBox.Show("Chưa chọn vùng để xóa!");
                }
                if (check == 1)
                {
                    //kiem tra xem MaVung co dung trong hop dong nao chua
                    TTC_HopDongThueDatEntities entity1 = new TTC_HopDongThueDatEntities();
                    HopDong_ChiTiet hd_ct = entity1.HopDong_ChiTiet.Where(item => item.MaVung == maVung).FirstOrDefault();
                    if (hd_ct != null)
                    {
                        MessageBox.Show("Mã vùng này được dùng trong hợp đồng. Không được xóa!");
                    }
                    else
                    {
                        if (MessageBox.Show("Bạn có chắc chắn muốn xóa?!?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            TTC_HopDongThueDatEntities entity = new TTC_HopDongThueDatEntities();
                            Vung v1 = entity.Vung.Single(item => item.MaVung == maVung && item.TenVung == tenVung);
                            entity.Vung.Remove(v1);
                            entity.SaveChanges();
                            MessageBox.Show("Xóa thành công!");
                            loadAll_Vung();
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình xử lý. Vui lòng thao tác lại!");
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

        private void load_Vung()
        {
            Disable();
            int check = 0;//kiem tra xem co chon vung ben dataGV chua
            string maVung = "";
            string tenVung = "";
            try
            {
                maVung = dataGridView_Vung.SelectedRows[0].Cells[0].Value.ToString();
                tenVung = dataGridView_Vung.SelectedRows[0].Cells[1].Value.ToString();
                check = 1;
                //neu maVung == "" => catch
            }
            catch
            {
                check = 0;
            }
            if (check == 1)
            {
                Enable();
                btn_Luu.Text = "Sửa";
                txt_MaVung.Text = maVung;
                txt_TenVung.Text = tenVung;
            }
        }
        private void dataGridView_Vung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            load_Vung();
        }

        private void btn_TaoMoiHopDong_Click(object sender, EventArgs e)
        {
            frmHopDong_ChiTiet frm = new frmHopDong_ChiTiet();
            this.Visible = false;
            frm.Visible = true;
        }
    }
}
