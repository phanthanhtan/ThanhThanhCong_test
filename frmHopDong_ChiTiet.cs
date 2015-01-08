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
    public partial class frmHopDong_ChiTiet : Form
    {
        public frmHopDong_ChiTiet()
        {
            InitializeComponent();
            loadAll_Vung();
            txt_MaHopDong.Text = "";
        }

        public frmHopDong_ChiTiet(string maHopDong)
        {
            InitializeComponent();
            loadAll_Vung();
            txt_MaHopDong.Text = maHopDong;
            LoadChiTiet();
        }
        private void LoadChiTiet()
        {
            int _maHopDong = int.Parse(txt_MaHopDong.Text);
            TTC_HopDongThueDatEntities entity = new TTC_HopDongThueDatEntities();
            HopDong hd = entity.HopDong.Where(item => item.MaHopDong == _maHopDong).FirstOrDefault();
            List<HopDong_ChiTiet> list_hd_ct = entity.HopDong_ChiTiet.Where(item => item.MaHopDong == _maHopDong).ToList();
            txt_HoTen_A1.Text = hd.HoTen_A1;
            txt_HoTen_A2.Text = hd.HoTen_A2;
            txt_HoTen_B1.Text = hd.HoTen_B1;
            txt_HoTen_B2.Text = hd.HoTen_B2;
            txt_CMND_A1.Text = hd.CMND_A1;
            txt_CMND_A2.Text = hd.CMND_A2;
            txt_CMND_B1.Text = hd.CMND_B1;
            txt_CMND_B2.Text = hd.CMND_B2;
            txt_DiaChi_A1.Text = hd.DiaChi_A1;
            txt_DiaChi_A2.Text = hd.DiaChi_A2;
            txt_DiaChi_B1.Text = hd.DiaChi_B1;
            txt_DiaChi_B2.Text = hd.DiaChi_B2;
            txt_SDT_A1.Text = hd.SDT_A1;
            txt_SDT_A2.Text = hd.SDT_A2;
            txt_SDT_B1.Text = hd.SDT_B1;
            txt_SDT_B2.Text = hd.SDT_B2;
            txt_MoiQuanHeA.Text = hd.MoiQuanHeA;
            txt_MoiQuanHeB.Text = hd.MoiQuanHeB;
            txt_KiemSoatVien.Text = hd.KiemSoatVien;
            txt_SoVu.Text = hd.SoVu.ToString();
            txt_TuVu.Text = hd.TuVu;
            txt_DonGiaThue.Text = hd.DonGiaThue.ToString();
            txt_TongTien.Text = hd.TongTien.ToString("0,0.00");
            txt_UngTruoc.Text = hd.UngTruoc.ToString();
            dataGridView_ChiTiet.Rows.Clear();
            foreach (HopDong_ChiTiet hd_ct in list_hd_ct)
            {
                dataGridView_ChiTiet.Rows.Add(hd_ct.MaVung, hd_ct.SoThua, hd_ct.DienTich, hd_ct.ViTriDat, hd_ct.LoaiDat, hd_ct.TinhTrangDat);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            frmHopDong frm = new frmHopDong();
            this.Visible = false;
            frm.Visible = true;
        }
        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
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

            //canh giua cho dataGridView_ChiTiet
            foreach (DataGridViewColumn col in dataGridView_ChiTiet.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void TongTien()
        {
            int count = dataGridView_ChiTiet.RowCount;
            if (count > 0)
            {
                float DienTich = 0;
                for (int i = 0; i < count; i++)
                {
                    float dienTich = 0;
                    try
                    {
                        dienTich = float.Parse(dataGridView_ChiTiet.Rows[i].Cells["DienTich"].Value.ToString());
                        if (dienTich < 0)
                            dienTich = 0;
                    }
                    catch { }
                    DienTich = DienTich + dienTich;
                }
                float donGiaThue = 0;
                try
                {
                    donGiaThue = float.Parse(txt_DonGiaThue.Text.ToString());
                    if (donGiaThue < 0)
                        donGiaThue = 0;
                }
                catch { }
                float sum = 0;
                try
                {
                    sum = donGiaThue * DienTich;
                    if (sum < 0)
                        sum = 0;
                }
                catch { }
                if(sum == 0)
                    txt_TongTien.Text = "0";
                else
                    if(sum < 10)
                        txt_TongTien.Text = sum.ToString("0.00");
                    else
                        txt_TongTien.Text = sum.ToString("0,0.00");
            }
            else
            {
                txt_TongTien.Text = "0";
            }
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            string maVung = "";
            int check = 0;
            try
            {
                maVung = dataGridView_Vung.SelectedRows[0].Cells["MaVung"].Value.ToString();
                check = 1;
            }
            catch
            {
                MessageBox.Show("Không có vùng nào được chọn!");
            }
            if (check == 1)
            {
                dataGridView_ChiTiet.Rows.Add(maVung, "1", "1", "", "", "");
                TongTien();
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView_ChiTiet.Rows.Remove(dataGridView_ChiTiet.SelectedRows[0]);
                TongTien();
            }
            catch
            {//không có mã vùng nào trong hợp đồng
            }
        }

        private void dataGridView_ChiTiet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            TongTien();
        }

        private void txt_DonGiaThue_KeyUp(object sender, KeyEventArgs e)
        {
            TongTien();
        }

        private void HuyThemMoi()
        {
            txt_MaHopDong.Text = "";
            txt_HoTen_A1.Text = "";
            txt_HoTen_A2.Text = "";
            txt_HoTen_B1.Text = "";
            txt_HoTen_B2.Text = "";
            txt_CMND_A1.Text = "";
            txt_CMND_A2.Text = "";
            txt_CMND_B1.Text = "";
            txt_CMND_B2.Text = "";
            txt_DiaChi_A1.Text = "";
            txt_DiaChi_A2.Text = "";
            txt_DiaChi_B1.Text = "";
            txt_DiaChi_B2.Text = "";
            txt_SDT_A1.Text = "";
            txt_SDT_A2.Text = "";
            txt_SDT_B1.Text = "";
            txt_SDT_B2.Text = "";
            txt_MoiQuanHeA.Text = "";
            txt_MoiQuanHeB.Text = "";
            txt_KiemSoatVien.Text = "";
            txt_SoVu.Text = "";
            txt_TuVu.Text = "";
            txt_DonGiaThue.Text = "";
            txt_TongTien.Text = "0";
            txt_UngTruoc.Text = "";
            dataGridView_ChiTiet.Rows.Clear();
        }
        private void btn_Huy_Click(object sender, EventArgs e)
        {
            if (txt_MaHopDong.Text == "")
                HuyThemMoi();
            else
                LoadChiTiet();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            int check = 0;//kiểm tra trong dataGV có Diện tích nào nhập sai không? nhập vào ký tự khác số
            int count = dataGridView_ChiTiet.RowCount;
            try
            {
                for (int i = 0; i < count; i++)
                {
                    float.Parse(dataGridView_ChiTiet.Rows[i].Cells["DienTich"].Value.ToString());
                    check++;
                }
            }
            catch { }
            if (txt_HoTen_A1.Text != "" &&
            txt_HoTen_A2.Text != "" &&
            txt_HoTen_B1.Text != "" &&
            txt_HoTen_B2.Text != "" &&
            txt_CMND_A1.Text != "" &&
            txt_CMND_A2.Text != "" &&
            txt_CMND_B1.Text != "" &&
            txt_CMND_B2.Text != "" &&
            txt_DiaChi_A1.Text != "" &&
            txt_DiaChi_A2.Text != "" &&
            txt_DiaChi_B1.Text != "" &&
            txt_DiaChi_B2.Text != "" &&
            txt_SDT_A1.Text != "" &&
            txt_SDT_A2.Text != "" &&
            txt_SDT_B1.Text != "" &&
            txt_SDT_B2.Text != "" &&
            txt_MoiQuanHeA.Text != "" &&
            txt_MoiQuanHeB.Text != "" &&
            txt_KiemSoatVien.Text != "" &&
            txt_SoVu.Text != "" && int.Parse(txt_SoVu.Text) > 0 &&
            txt_TuVu.Text != "" && int.Parse(txt_TuVu.Text) >= 2000 &&
            txt_DonGiaThue.Text != "" && int.Parse(txt_DonGiaThue.Text) > 0 &&
            txt_TongTien.Text != "0" &&
            txt_UngTruoc.Text != "" && int.Parse(txt_UngTruoc.Text) <= float.Parse(txt_TongTien.Text) &&
            count > 0 && check == count)
            {
                try
                {
                    //MessageBox.Show("Ok");
                    HopDong hd = new HopDong();
                    if (txt_MaHopDong.Text != "")
                        hd.MaHopDong = int.Parse(txt_MaHopDong.Text);
                    hd.HoTen_A1 = txt_HoTen_A1.Text;
                    hd.HoTen_A2 = txt_HoTen_A2.Text;
                    hd.HoTen_B1 = txt_HoTen_B1.Text;
                    hd.HoTen_B2 = txt_HoTen_B2.Text;
                    hd.CMND_A1 = txt_CMND_A1.Text;
                    hd.CMND_A2 = txt_CMND_A2.Text;
                    hd.CMND_B1 = txt_CMND_B1.Text;
                    hd.CMND_B2 = txt_CMND_B2.Text;
                    hd.DiaChi_A1 = txt_DiaChi_A1.Text;
                    hd.DiaChi_A2 = txt_DiaChi_A2.Text;
                    hd.DiaChi_B1 = txt_DiaChi_B1.Text;
                    hd.DiaChi_B2 = txt_DiaChi_B2.Text;
                    hd.SDT_A1 = txt_SDT_A1.Text;
                    hd.SDT_A2 = txt_SDT_A2.Text;
                    hd.SDT_B1 = txt_SDT_B1.Text;
                    hd.SDT_B2 = txt_SDT_B2.Text;
                    hd.MoiQuanHeA = txt_MoiQuanHeA.Text;
                    hd.MoiQuanHeB = txt_MoiQuanHeB.Text;
                    hd.KiemSoatVien = txt_KiemSoatVien.Text;
                    hd.SoVu = int.Parse(txt_SoVu.Text);
                    hd.TuVu = txt_TuVu.Text;
                    hd.DonGiaThue = float.Parse(txt_DonGiaThue.Text);
                    hd.TongTien = float.Parse(txt_TongTien.Text);
                    hd.UngTruoc = float.Parse(txt_UngTruoc.Text);
                    TTC_HopDongThueDatEntities entity = new TTC_HopDongThueDatEntities();
                    if (txt_MaHopDong.Text == "") //tạo mới
                    {
                        entity.HopDong.Add(hd);
                        entity.SaveChanges();

                        //lay MaHopDong tu csdl len, de lam khóa ngoại cho HopDong_ChiTiet
                        //where theo 5nguoi co ten trong hop dong
                        HopDong hd_ma = entity.HopDong.Where(item => item.HoTen_A1 == hd.HoTen_A1
                            && item.HoTen_A2 == hd.HoTen_A2
                            && item.HoTen_B1 == hd.HoTen_B1
                            && item.HoTen_B2 == hd.HoTen_B2
                            && item.KiemSoatVien == hd.KiemSoatVien).OrderByDescending(item => item.MaHopDong).FirstOrDefault();
                        if (hd_ma != null)//lưu HopDong_ChiTiet
                        {
                            HopDong_ChiTiet hd_ct = new HopDong_ChiTiet();
                            for (int i = 0; i < dataGridView_ChiTiet.RowCount; i++)
                            {
                                hd_ct.MaHopDong = hd_ma.MaHopDong;
                                hd_ct.MaVung = dataGridView_ChiTiet.Rows[i].Cells["MaVung1"].Value.ToString();
                                hd_ct.SoThua = dataGridView_ChiTiet.Rows[i].Cells["SoThua"].Value.ToString();
                                hd_ct.DienTich = float.Parse(dataGridView_ChiTiet.Rows[i].Cells["DienTich"].Value.ToString());
                                hd_ct.ViTriDat = dataGridView_ChiTiet.Rows[i].Cells["ViTriDat"].Value.ToString();
                                hd_ct.LoaiDat = dataGridView_ChiTiet.Rows[i].Cells["LoaiDat"].Value.ToString();
                                hd_ct.TinhTrangDat = dataGridView_ChiTiet.Rows[i].Cells["TinhTrangDat"].Value.ToString();
                                entity.HopDong_ChiTiet.Add(hd_ct);
                                entity.SaveChanges();
                            }
                            MessageBox.Show("Lưu thành công!");
                            HuyThemMoi();
                        }
                        else
                            MessageBox.Show("Có lỗi xảy ra trong quá trình lưu hợp đồng. Vui lòng thao tác lại!");
                    }
                    else //sửa
                    {
                        //update HopDong
                        entity.HopDong.Attach(hd);
                        entity.Entry(hd).State = EntityState.Modified;
                        entity.SaveChanges();

                        int maHopDong = int.Parse(txt_MaHopDong.Text);
                        //xoa HopDong_ChiTiet
                        List<HopDong_ChiTiet> listHDCT = entity.HopDong_ChiTiet.Where(item => item.MaHopDong == maHopDong).ToList();
                        foreach (HopDong_ChiTiet hdct in listHDCT)
                        {
                            HopDong_ChiTiet hdct_delete = entity.HopDong_ChiTiet.Single(item => item.MaHopDong_ChiTiet == hdct.MaHopDong_ChiTiet);
                            entity.HopDong_ChiTiet.Remove(hdct_delete);
                            entity.SaveChanges();
                        }

                        //lưu HopDong_ChiTiet mới
                        HopDong_ChiTiet hd_ct = new HopDong_ChiTiet();
                        for (int i = 0; i < dataGridView_ChiTiet.RowCount; i++)
                        {
                            hd_ct.MaHopDong = maHopDong;
                            hd_ct.MaVung = dataGridView_ChiTiet.Rows[i].Cells["MaVung1"].Value.ToString();
                            hd_ct.SoThua = dataGridView_ChiTiet.Rows[i].Cells["SoThua"].Value.ToString();
                            hd_ct.DienTich = float.Parse(dataGridView_ChiTiet.Rows[i].Cells["DienTich"].Value.ToString());
                            hd_ct.ViTriDat = dataGridView_ChiTiet.Rows[i].Cells["ViTriDat"].Value.ToString();
                            hd_ct.LoaiDat = dataGridView_ChiTiet.Rows[i].Cells["LoaiDat"].Value.ToString();
                            hd_ct.TinhTrangDat = dataGridView_ChiTiet.Rows[i].Cells["TinhTrangDat"].Value.ToString();
                            entity.HopDong_ChiTiet.Add(hd_ct);
                            entity.SaveChanges();
                        }
                        MessageBox.Show("Lưu thành công!");
                    }
                }
                catch
                {
                    MessageBox.Show("Có lỗi xảy ra trong quá trình lưu hợp đồng. Vui lòng thao tác lại!");
                }
            }
            else
                if (dataGridView_ChiTiet.RowCount <= 0)
                    MessageBox.Show("Chưa chọn mã vùng!");
                else
                    MessageBox.Show("Chưa nhập đủ thông tin hoặc thông tin sai cấu trúc!");
        }

        private void txt_CMND_A1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_SDT_A1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_CMND_A2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_SDT_A2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_CMND_B1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_SDT_B1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_CMND_B2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_SDT_B2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_SoVu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_TuVu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_DonGiaThue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_UngTruoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btn_Vung_Click(object sender, EventArgs e)
        {
            frmVung frm = new frmVung();
            this.Visible = false;
            frm.Visible = true;
        }

    }
}
