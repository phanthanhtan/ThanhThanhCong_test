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
                    sum = donGiaThue * DienTich * float.Parse(txt_SoVu.Text.ToString());
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
            catch { check = 0; }
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

        private void btn_in_Click(object sender, EventArgs e)
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
            catch { check = 0; }
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
                    btn_in.Enabled = false;
                    frmHopDong_ChiTiet excel = new frmHopDong_ChiTiet();
                    excel.Export(dataGridView_ChiTiet, "Hop dong thue dat",
                        txt_HoTen_A1.Text, txt_HoTen_A2.Text, txt_HoTen_B1.Text, txt_HoTen_B2.Text,
                        txt_CMND_A1.Text, txt_CMND_A2.Text, txt_CMND_B1.Text, txt_CMND_B2.Text,
                        txt_DiaChi_A1.Text, txt_DiaChi_A2.Text, txt_DiaChi_B1.Text, txt_DiaChi_B2.Text,
                        txt_SDT_A1.Text, txt_SDT_A2.Text, txt_SDT_B1.Text, txt_SDT_B2.Text,
                        txt_MoiQuanHeA.Text, txt_MoiQuanHeB.Text,
                        txt_KiemSoatVien.Text, int.Parse(txt_SoVu.Text), int.Parse(txt_TuVu.Text),
                        txt_DonGiaThue.Text, txt_TongTien.Text, txt_UngTruoc.Text);
                    MessageBox.Show("Hoàn tất in hợp đồng.");
                    btn_in.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("Có lỗi xảy ra trong quá trình in hợp đồng, Vui lòng thao tác lại!");
                    btn_in.Enabled = true;
                }
            }
            else
                if (dataGridView_ChiTiet.RowCount <= 0)
                    MessageBox.Show("Chưa chọn mã vùng!");
                else
                    MessageBox.Show("Chưa nhập đủ thông tin hoặc thông tin sai cấu trúc!");
        }
        public void Export(DataGridView dtGV, String sheetName,
            string hoTen_A1, string hoTen_A2, string hoTen_B1, string hoTen_B2,
            string cMND_A1, string cMND_A2, string cMND_B1, string cMND_B2,
            string diaChi_A1, string diaChi_A2, string diaChi_B1, string diaChi_B2,
            string sDT_A1, string sDT_A2, string sDT_B1, string sDT_B2,
            string moiQuanHeA, string moiQuanHeB,
            string kiemSoatVien, int soVu, int tuVu,
            string donGiaThue, string tongTien, string ungTruoc
            )
        {
            //Tạo các đối tượng Excel
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            //Tạo mới một Excel WorkBook
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = sheetName;

            // Tạo phần đầu nếu muốn
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "I1");
            head.MergeCells = true;
            head.Value2 = "CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM";
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "12";
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range head1 = oSheet.get_Range("A2", "I2");
            head1.MergeCells = true;
            head1.Value2 = "Độc lập - Tự do - Hạnh phúc";
            head1.Font.Bold = true;
            head1.Font.Name = "Times New Roman";
            head1.Font.Size = "12";
            head1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range head2 = oSheet.get_Range("A3", "I3");
            head2.MergeCells = true;
            head2.Value2 = "-----";
            head2.Font.Bold = true;
            head2.Font.Name = "Times New Roman";
            head2.Font.Size = "12";
            head2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range head3 = oSheet.get_Range("A5", "I5");
            head3.MergeCells = true;
            head3.Value2 = "HỢP ĐỒNG THUÊ ĐẤT";
            head3.Font.Bold = true;
            head3.Font.Name = "Times New Roman";
            head3.Font.Size = "14";
            head3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range canCu = oSheet.get_Range("A7", "I7");
            canCu.MergeCells = true;
            canCu.Value2 = "  - Căn cứ Bộ luật Dân sự số 33/2005/QH11;";

            Microsoft.Office.Interop.Excel.Range canCu1 = oSheet.get_Range("A8", "I8");
            canCu1.MergeCells = true;
            canCu1.Value2 = "  - Căn cứ vào nhu cầu và khả năng của 2 bên.";

            Microsoft.Office.Interop.Excel.Range ngay = oSheet.get_Range("A10", "I10");
            ngay.MergeCells = true;
            ngay.Value2 = "  Hôm nay, ngày ... tháng ... năm ...... tại trạm nông vụ số ...... Chúng tôi gồm có:";
            ngay.Font.Italic = true;

    //Bên A ----------------------------------------------------------------------------------
            Microsoft.Office.Interop.Excel.Range benA = oSheet.get_Range("A12", "A12");
            benA.MergeCells = true;
            benA.Value2 = "Bên A:";
            benA.Font.Bold = true;
            benA.Font.Underline = true;
        // A1 ------------------------------------------------------------------------------------
            Microsoft.Office.Interop.Excel.Range benA1_1 = oSheet.get_Range("B12", "F12");
            benA1_1.MergeCells = true;
            benA1_1.Value2 = "Bên cho thuê: " + hoTen_A1;

            Microsoft.Office.Interop.Excel.Range benA1_2 = oSheet.get_Range("G12", "I12");
            benA1_2.MergeCells = true;
            benA1_2.Value2 = "Số CMND: " + cMND_A1;

            Microsoft.Office.Interop.Excel.Range benA1_3 = oSheet.get_Range("B13", "F14");
            benA1_3.MergeCells = true;
            benA1_3.Value2 = "Địa chỉ: " + diaChi_A1;
            benA1_3.WrapText = true;            

            Microsoft.Office.Interop.Excel.Range benA1_4 = oSheet.get_Range("G13", "I13");
            benA1_4.MergeCells = true;
            benA1_4.Value2 = "Điện thoại: " + sDT_A1;
        // A2--------------------------------------------------------------------------------------
            Microsoft.Office.Interop.Excel.Range benA2_1 = oSheet.get_Range("B15", "F15");
            benA2_1.MergeCells = true;
            benA2_1.Value2 = "Họ tên người thừa kế: " + hoTen_A2;

            Microsoft.Office.Interop.Excel.Range benA2_2 = oSheet.get_Range("G15", "I15");
            benA2_2.MergeCells = true;
            benA2_2.Value2 = "Số CMND: " + cMND_A2;

            Microsoft.Office.Interop.Excel.Range benA2_3 = oSheet.get_Range("B16", "I16");
            benA2_3.MergeCells = true;
            benA2_3.Value2 = "Mối quan hệ: " + moiQuanHeA;

            Microsoft.Office.Interop.Excel.Range benA2_4 = oSheet.get_Range("B17", "F18");
            benA2_4.MergeCells = true;
            benA2_4.Value2 = "Địa chỉ: " + diaChi_A2;
            benA2_4.WrapText = true;

            Microsoft.Office.Interop.Excel.Range benA2_5 = oSheet.get_Range("G17", "I17");
            benA2_5.MergeCells = true;
            benA2_5.Value2 = "Điện thoại: " + sDT_A2;
    //Bên B ----------------------------------------------------------------------------------
            Microsoft.Office.Interop.Excel.Range benB = oSheet.get_Range("A19", "A19");
            benB.MergeCells = true;
            benB.Value2 = "Bên B:";
            benB.Font.Bold = true;
            benB.Font.Underline = true;
            // B1 ------------------------------------------------------------------------------------
            Microsoft.Office.Interop.Excel.Range benB1_1 = oSheet.get_Range("B19", "F19");
            benB1_1.MergeCells = true;
            benB1_1.Value2 = "Bên thuê đất: " + hoTen_B1;

            Microsoft.Office.Interop.Excel.Range benB1_2 = oSheet.get_Range("G19", "I19");
            benB1_2.MergeCells = true;
            benB1_2.Value2 = "Số CMND: " + cMND_B1;

            Microsoft.Office.Interop.Excel.Range benB1_3 = oSheet.get_Range("B20", "F21");
            benB1_3.MergeCells = true;
            benB1_3.Value2 = "Địa chỉ: " + diaChi_B1;
            benB1_3.WrapText = true;

            Microsoft.Office.Interop.Excel.Range benB1_4 = oSheet.get_Range("G20", "I20");
            benB1_4.MergeCells = true;
            benB1_4.Value2 = "Điện thoại: " + sDT_B1;
            // B2--------------------------------------------------------------------------------------
            Microsoft.Office.Interop.Excel.Range benB2_1 = oSheet.get_Range("B22", "F22");
            benB2_1.MergeCells = true;
            benB2_1.Value2 = "Người thừa kế hợp đồng: " + hoTen_B2;

            Microsoft.Office.Interop.Excel.Range benB2_2 = oSheet.get_Range("G22", "I22");
            benB2_2.MergeCells = true;
            benB2_2.Value2 = "Số CMND: " + cMND_B2;

            Microsoft.Office.Interop.Excel.Range benB2_3 = oSheet.get_Range("B23", "I23");
            benB2_3.MergeCells = true;
            benB2_3.Value2 = "Mối quan hệ: " + moiQuanHeB;

            Microsoft.Office.Interop.Excel.Range benB2_4 = oSheet.get_Range("B24", "F25");
            benB2_4.MergeCells = true;
            benB2_4.Value2 = "Địa chỉ: " + diaChi_B2;
            benB2_4.WrapText = true;

            Microsoft.Office.Interop.Excel.Range benB2_5 = oSheet.get_Range("G24", "I24");
            benB2_5.MergeCells = true;
            benB2_5.Value2 = "Điện thoại: " + sDT_B2;
    //het ben B

            Microsoft.Office.Interop.Excel.Range ksv = oSheet.get_Range("A26", "I27");
            ksv.MergeCells = true;
            ksv.Value2 = "Và sự chứng kiến của Ông (Bà) " + kiemSoatVien + ". Chức vụ: Kiểm soát viên tại Công ty cổ phần mía đường Thành Thành Công Tây Ninh (TTCS).";
            ksv.WrapText = true;

            Microsoft.Office.Interop.Excel.Range haiBen = oSheet.get_Range("B28", "I28");
            haiBen.MergeCells = true;
            haiBen.Value2 = "Hai bên cùng thống nhất các điều khoản sau đây:";
            haiBen.Font.Bold = true;
            haiBen.Font.Italic = true;
            
    //điều 1-------------------------------------------------------------------------------
            Microsoft.Office.Interop.Excel.Range dieu1_1 = oSheet.get_Range("A29", "I29");
            dieu1_1.MergeCells = true;
            dieu1_1.Value2 = "Điều 1: Bên A đồng ý cho bên B thuê đất với chi tiết như sau:";
            dieu1_1.Font.Bold = true;

            Microsoft.Office.Interop.Excel.Range HAIBEN = oSheet.get_Range("A7", "I29");
            HAIBEN.Font.Name = "Times New Roman";
            HAIBEN.Font.Size = "12";
            HAIBEN.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            HAIBEN.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;

            Microsoft.Office.Interop.Excel.Range dieu1_2 = oSheet.get_Range("B30", "B31");
            dieu1_2.MergeCells = true;
            dieu1_2.Value2 = "Mã vùng";

            Microsoft.Office.Interop.Excel.Range dieu1_3 = oSheet.get_Range("C30", "C31");
            dieu1_3.MergeCells = true;
            dieu1_3.Value2 = "Số thửa";

            Microsoft.Office.Interop.Excel.Range dieu1_4 = oSheet.get_Range("D30", "D31");
            dieu1_4.MergeCells = true;
            dieu1_4.Value2 = "Diện tích (ha)";

            Microsoft.Office.Interop.Excel.Range dieu1_5 = oSheet.get_Range("E30", "F31");
            dieu1_5.MergeCells = true;
            dieu1_5.Value2 = "Ví trí đất";

            Microsoft.Office.Interop.Excel.Range dieu1_6 = oSheet.get_Range("G30", "H31");
            dieu1_6.MergeCells = true;
            dieu1_6.Value2 = "Loại đất (cao/thấp/...)";

            Microsoft.Office.Interop.Excel.Range dieu1_7 = oSheet.get_Range("I30", "I31");
            dieu1_7.MergeCells = true;
            dieu1_7.Value2 = "Tình trạng đất";

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("B30", "I31");
            rowHead.WrapText = true;
            rowHead.Font.Name = "Times New Roman";
            rowHead.Font.Size = "12";
            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            rowHead.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            // Kẻ viền
            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            int row = 32;
            for (int i = 0; i < dtGV.RowCount; i++)
            {
                Microsoft.Office.Interop.Excel.Range col1 = oSheet.get_Range("B" + row, "B" + row);
                col1.MergeCells = true;
                col1.Value2 = dtGV.Rows[i].Cells["MaVung1"].Value.ToString();

                Microsoft.Office.Interop.Excel.Range col2 = oSheet.get_Range("C" + row, "C" + row);
                col2.MergeCells = true;
                col2.Value2 = dtGV.Rows[i].Cells["SoThua"].Value.ToString();

                Microsoft.Office.Interop.Excel.Range col3 = oSheet.get_Range("D" + row, "D" + row);
                col3.MergeCells = true;
                col3.Value2 = dtGV.Rows[i].Cells["DienTich"].Value.ToString();

                Microsoft.Office.Interop.Excel.Range col4 = oSheet.get_Range("E" + row, "F" + row);
                col4.MergeCells = true;
                col4.Value2 = dtGV.Rows[i].Cells["ViTriDat"].Value.ToString();

                Microsoft.Office.Interop.Excel.Range col5 = oSheet.get_Range("G" + row, "H" + row);
                col5.MergeCells = true;
                col5.Value2 = dtGV.Rows[i].Cells["LoaiDat"].Value.ToString();

                Microsoft.Office.Interop.Excel.Range col6 = oSheet.get_Range("I" + row, "I" + row);
                col6.MergeCells = true;
                col6.Value2 = dtGV.Rows[i].Cells["TinhTrangDat"].Value.ToString();

                row++;
            }
            Microsoft.Office.Interop.Excel.Range data = oSheet.get_Range("B32", "I" + (row-1));
            data.Font.Name = "Times New Roman";
            data.Font.Size = "12";
            data.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            // Kẻ viền
            data.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

        //điều 2----------------------------------------------------------------------------------
            int dieu2_start = row;
            Microsoft.Office.Interop.Excel.Range dieu2_1 = oSheet.get_Range("A" + row, "I" + row);
            dieu2_1.MergeCells = true;
            dieu2_1.Value2 = "Điều 2: Mục đích sử dụng";
            dieu2_1.Font.Bold = true;
            row++;

            string _soVu = soVu.ToString();
            if(soVu <10)
                _soVu = "0" + soVu.ToString();
            Microsoft.Office.Interop.Excel.Range dieu2_2 = oSheet.get_Range("A" + row, "I" + (row+1));
            dieu2_2.MergeCells = true;
            dieu2_2.Value2 = "Bên B sẽ sử dụng đất thuê trên để trồng mía cung cấp cho Công ty cổ phần mía đường Thành Thành Công Tây Ninh (TTCS) trong " + _soVu + " vụ thu hoạch liên tiếp, kể từ vụ thu hoạch " + tuVu + "-" + (tuVu+1) + ".";
            dieu2_2.WrapText = true;
            row += 2;

        //điều 3----------------------------------------------------------------------------------
            Microsoft.Office.Interop.Excel.Range dieu3_1 = oSheet.get_Range("A" + row, "I" + row);
            dieu3_1.MergeCells = true;
            dieu3_1.Value2 = "Điều 3: Thời hạn thuê đất";
            dieu3_1.Font.Bold = true;
            row++;

            Microsoft.Office.Interop.Excel.Range dieu3_2 = oSheet.get_Range("A" + row, "I" + row);
            dieu3_2.MergeCells = true;
            dieu3_2.Value2 = _soVu + " vụ, kể từ ngày ký hợp đồng này cho đến khi kết thúc vụ thu hoạch " + (tuVu + soVu - 1) + "-" + (tuVu + soVu) + ".";
            row++;

        //điều 4----------------------------------------------------------------------------------
            Microsoft.Office.Interop.Excel.Range dieu4_1 = oSheet.get_Range("A" + row, "I" + row);
            dieu4_1.MergeCells = true;
            dieu4_1.Value2 = "Điều 4: Đơn giá thuê";
            dieu4_1.Font.Bold = true;
            row++;

            Microsoft.Office.Interop.Excel.Range dieu4_2 = oSheet.get_Range("A" + row, "I" + row);
            dieu4_2.MergeCells = true;
            dieu4_2.Value2 = donGiaThue + "đồng/ha/năm";
            row++;

            Microsoft.Office.Interop.Excel.Range dieu4_3 = oSheet.get_Range("A" + row, "I" + row);
            dieu4_3.MergeCells = true;
            dieu4_3.Value2 = "Tổng số tiền thuê đất: " + tongTien + "đồng.";
            row++;

        //điều 5----------------------------------------------------------------------------------
            Microsoft.Office.Interop.Excel.Range dieu5_1 = oSheet.get_Range("A" + row, "I" + row);
            dieu5_1.MergeCells = true;
            dieu5_1.Value2 = "Điều 5: Phương thức, thời hạn thanh toán";
            dieu5_1.Font.Bold = true;
            row++;

            Microsoft.Office.Interop.Excel.Range dieu5_2 = oSheet.get_Range("A" + row, "I" + (row+1));
            dieu5_2.MergeCells = true;
            dieu5_2.Value2 = "Bên B thanh toán đủ một lần tiền thuê đất cho toàn bộ thời gian thuê đã nêu ở trên ngay vụ trồng đầu tiên. Cụ thể như sau:";
            dieu5_2.WrapText = true;
            row += 2;

            Microsoft.Office.Interop.Excel.Range dieu5_3 = oSheet.get_Range("A" + row, "I" + row);
            dieu5_3.MergeCells = true;
            dieu5_3.Value2 = "1. Bên B sẽ ứng trước cho bên A số tiền là " + ungTruoc + " đồng sau khi ký Hợp đồng này.";
            row++;

            Microsoft.Office.Interop.Excel.Range dieu5_4 = oSheet.get_Range("A" + row, "I" + (row + 1));
            dieu5_4.MergeCells = true;
            dieu5_4.Value2 = "2. Số tiền còn lại bên B sẽ thanh toán hết cho bên A ngay sau khi nhận tiền từ hợp đồng Ứng vốn về ciệc thuê đất trồng mía từ TTCS hoặc bên A nhận trực tiếp tại TTCS.";
            dieu5_4.WrapText = true;
            row += 2;


        //điều 6----------------------------------------------------------------------------------
            Microsoft.Office.Interop.Excel.Range dieu6_1 = oSheet.get_Range("A" + row, "I" + row);
            dieu6_1.MergeCells = true;
            dieu6_1.Value2 = "Điều 6: Quyền và nghĩa vụ của bên A";
            dieu6_1.Font.Bold = true;
            row++;

            Microsoft.Office.Interop.Excel.Range dieu6_2 = oSheet.get_Range("A" + row, "I" + (row + 1));
            dieu6_2.MergeCells = true;
            dieu6_2.Value2 = "1. Chuyển giao cho bên B đủ diện tích đất thuê, đúng vị trí, đúng tình trạng, như đã thỏa thuận tại Điều 1 Hợp đồng này.";
            dieu6_2.WrapText = true;
            row += 2;

            Microsoft.Office.Interop.Excel.Range dieu6_3 = oSheet.get_Range("A" + row, "I" + (row + 1));
            dieu6_3.MergeCells = true;
            dieu6_3.Value2 = "2. Thực hiện các thủ tục và thanh toán cac khoản thuế, phí, lệ phí cho nhà nước cũng như các phí khác trong quá trình cho thuê.";
            dieu6_3.WrapText = true;
            row += 2;

            Microsoft.Office.Interop.Excel.Range dieu6_4 = oSheet.get_Range("A" + row, "I" + (row + 1));
            dieu6_4.MergeCells = true;
            dieu6_4.Value2 = "3. Đảm bảo quyền sử dụng hợp pháp của mình đối với diện tích đất cho thuê, nếu có tranh chấp bên A sẽ phải bồi thường toàn bộ thiệt hại gây ra cho bên B do việc tranh chấp.";
            dieu6_4.WrapText = true;
            row += 2;

            Microsoft.Office.Interop.Excel.Range dieu6_5 = oSheet.get_Range("A" + row, "I" + (row + 3));
            dieu6_5.MergeCells = true;
            dieu6_5.Value2 = "4. Trong thời hạn cho thuê quyền sử dụng đất, nếu bên A chuyển nhượng quyền sử dụng đất cho người khác, bên A phải báo trước cho bên B và TTCS biết. Việc chuyển nhượng này phải được sự nhất trí của bên B và TTCS bằng văn bản. Khi đó các bên cùng thống nhất các nội dung:";
            dieu6_5.WrapText = true;
            row += 4;

            Microsoft.Office.Interop.Excel.Range dieu6_6 = oSheet.get_Range("B" + row, "I" + (row + 2));
            dieu6_6.MergeCells = true;
            dieu6_6.Value2 = "a. Nếu bên nhận chuyển nhượng tiếp tục cho thuê, thì Hợp đồng này vẫn tiếp tục thực hiện và bên nhận chuyển nhượng thực hiện tiếp nghĩa vụ của bên A theo hợp đồng này cho đến hết thời hạn hợp đồng.";
            dieu6_6.WrapText = true;
            row += 3;

            Microsoft.Office.Interop.Excel.Range dieu6_7 = oSheet.get_Range("B" + row, "I" + (row + 2));
            dieu6_7.MergeCells = true;
            dieu6_7.Value2 = "b. Nếu bên nhận chuyển nhượng không thể tiếp tục cho thuê, xem như bên A vi phạm hợp đồng. Khi đó bên A phải thanh toán cho bên B các khoản theo như xác định tại khoản 5, Điều này.";
            dieu6_7.WrapText = true;
            row += 3;

            Microsoft.Office.Interop.Excel.Range dieu6_8 = oSheet.get_Range("A" + row, "I" + (row + 5));
            dieu6_8.MergeCells = true;
            dieu6_8.Value2 = "5. Bên A không được quyền đơn phương chấm dứt hợp đồng. Nếu đơn phương chấm dứt hợp đồng, bên A phải hoàn trả lại cho bên B số tiền thuê đất theo giá thỏa thuận giữa hai bên tùy tình trạng thực tế của đất mía nhưng tối thiểu phải bằng giá thuê theo Hợp đồng này tính trên số năm đã thuê nhưng khôgn thực hiện. Ngoài ra, bên A còn phải bồi thường toàn bộ thiệt hại cho bên B do việc đơn phương chấm dứt hợp đồng của bên A gây ra và chịu phạt vi phạm hợp đồng bằng 50% giá trị hợp đồng.";
            dieu6_8.WrapText = true;
            row += 6;

            Microsoft.Office.Interop.Excel.Range dieu6_9 = oSheet.get_Range("A" + row, "I" + (row + 2));
            dieu6_9.MergeCells = true;
            dieu6_9.Value2 = "Số tiền hoàn lại, tiền phạt vi phạm hợp đồng và tiền bồi thường phải được chi trả thông qua TTCS để bên B hoàn trả số tiền ứng trước và tiền lãi tương ứng trên diện tích vi phạm cho TTCS.";
            dieu6_9.WrapText = true;
            row += 3;

        //điều 7----------------------------------------------------------------------------------
            Microsoft.Office.Interop.Excel.Range dieu7_1 = oSheet.get_Range("A" + row, "I" + row);
            dieu7_1.MergeCells = true;
            dieu7_1.Value2 = "Điều 7: Quyền và nghĩa vụ của bên B";
            dieu7_1.Font.Bold = true;
            row++;

            Microsoft.Office.Interop.Excel.Range dieu7_2 = oSheet.get_Range("A" + row, "I" + row);
            dieu7_2.MergeCells = true;
            dieu7_2.Value2 = "1. Sử dụng đất thuê đúng mục đích, đúng ranh giới và đúng thời hạn thuê.";
            row++;

            Microsoft.Office.Interop.Excel.Range dieu7_3 = oSheet.get_Range("A" + row, "I" + (row + 5));
            dieu7_3.MergeCells = true;
            dieu7_3.Value2 = "2. Diện tích đất cho thuê trong Hợp đồng này được thuê bởi bên B do TTCS đầu tư một phần tiền thuê, do đó nếu bên B không thực hiện đúng trách nhiệm của mình đối với bên cho thuê hoặc vi phạm những thỏa thuận trong các hợp đồng với TTCS thì TTCS có quyền chỉ định người khác tiếp tục thực hiện Hợp đồng này. Khi đó bên A có trách nhiệm ký hợp đồng mới với người được TTCS chỉ định và thực hiện tiếp các nghĩa vụ theo đúng các điều khoản đã ký của Hợp đồng này.";
            dieu7_3.WrapText = true;
            row += 6;

            Microsoft.Office.Interop.Excel.Range dieu7_4 = oSheet.get_Range("A" + row, "I" + row);
            dieu7_4.MergeCells = true;
            dieu7_4.Value2 = "3. Thanh toán đúng hạn và đầy đủ tiền thuê đất cho bên A theo quy định của Hợp đồng.";
            row++;

            Microsoft.Office.Interop.Excel.Range dieu7_5 = oSheet.get_Range("A" + row, "I" + (row + 1));
            dieu7_5.MergeCells = true;
            dieu7_5.Value2 = "4. Không cho người khác thuê lại hoặc sử dụng đất vào mục đích khác theo quy định của Hợp đồng trừ trường hợp được bên A và TTCS đồng ý.";
            dieu7_5.WrapText = true;
            row += 2;

            Microsoft.Office.Interop.Excel.Range dieu7_6 = oSheet.get_Range("A" + row, "I" + row);
            dieu7_6.MergeCells = true;
            dieu7_6.Value2 = "5. Không được hủy hoại, làm giảm sút giá trị sử dụng đất, tài sản gắn liền với đất.";
            row++;

            Microsoft.Office.Interop.Excel.Range dieu7_7 = oSheet.get_Range("A" + row, "I" + (row + 1));
            dieu7_7.MergeCells = true;
            dieu7_7.Value2 = "6. Không được quyền đơn phương chấm dứt hợp đồng, trừ trường hợp nêu tại khoản 2 điều này.";
            dieu7_7.WrapText = true;
            row += 2;

        //điều 8----------------------------------------------------------------------------------
            Microsoft.Office.Interop.Excel.Range dieu8_1 = oSheet.get_Range("A" + row, "I" + row);
            dieu8_1.MergeCells = true;
            dieu8_1.Value2 = "Điều 8: Cam kết chung";
            dieu8_1.Font.Bold = true;
            row++;

            Microsoft.Office.Interop.Excel.Range dieu8_2 = oSheet.get_Range("A" + row, "I" + (row + 2));
            dieu8_2.MergeCells = true;
            dieu8_2.Value2 = "Hai bên cam kết thực hiện theo đúng những điều khoản đã ghi trong Hợp đồng. Trong thời gian cho thuê nếu xảy ra tranh chấp hai bên tích cực bàn bạc tìm cách giải quyết. Trường hợp không giải quyết được mới đua ra Tòa án có thẩm quyền giải quyết.";
            dieu8_2.WrapText = true;
            row += 3;

            Microsoft.Office.Interop.Excel.Range dieu8_3 = oSheet.get_Range("A" + row, "I" + (row + 1));
            dieu8_3.MergeCells = true;
            dieu8_3.Value2 = "Hợp đồng này lập thành 04 (bốn) bản có giá trị pháp lý như nhau, bên A giữ 01 (một) bản bà bên B giữ 03 (ba) bản.";
            dieu8_3.Font.Italic = true;
            dieu8_3.WrapText = true;
            row += 2;

            Microsoft.Office.Interop.Excel.Range dieu2dieu8 = oSheet.get_Range("A" + dieu2_start, "I" + (row-1));
            dieu2dieu8.Font.Name = "Times New Roman";
            dieu2dieu8.Font.Size = "12";
            dieu2dieu8.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            dieu2dieu8.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
        //---------------------------------------------------------------------------------
            Microsoft.Office.Interop.Excel.Range UBND = oSheet.get_Range("A" + row, "I" + row);
            UBND.MergeCells = true;
            UBND.Value2 = "Chứng thực của UBND xã .....................................";
            UBND.Font.Bold = true;
            UBND.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            UBND.Font.Name = "Times New Roman";
            UBND.Font.Size = "12";
            row += 7;

            Microsoft.Office.Interop.Excel.Range final1_1 = oSheet.get_Range("A" + row, "D" + row);
            final1_1.MergeCells = true;
            final1_1.Value2 = "BÊN A";

            Microsoft.Office.Interop.Excel.Range final1_2 = oSheet.get_Range("E" + row, "F" + row);
            final1_2.MergeCells = true;
            final1_2.Value2 = "ĐẠI DIỆN SBT";

            Microsoft.Office.Interop.Excel.Range final1_3 = oSheet.get_Range("G" + row, "I" + row);
            final1_3.MergeCells = true;
            final1_3.Value2 = "BÊN B";

            Microsoft.Office.Interop.Excel.Range final1 = oSheet.get_Range("A" + row, "I" + row);
            final1.Font.Bold = true;
            final1.Font.Underline = true;
            final1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            final1.Font.Name = "Times New Roman";
            final1.Font.Size = "12";
            row++;

            Microsoft.Office.Interop.Excel.Range final2_1 = oSheet.get_Range("A" + row, "D" + row);
            final2_1.MergeCells = true;
            final2_1.Value2 = "Người cho thuê      Người thừa kế";

            Microsoft.Office.Interop.Excel.Range final2_2 = oSheet.get_Range("E" + row, "F" + row);
            final2_2.MergeCells = true;
            final2_2.Value2 = "Kiếm soát viên";

            Microsoft.Office.Interop.Excel.Range final2_3 = oSheet.get_Range("G" + row, "I" + row);
            final2_3.MergeCells = true;
            final2_3.Value2 = "Người thuê     Người thừa kế";

            Microsoft.Office.Interop.Excel.Range final2 = oSheet.get_Range("A" + row, "I" + row);
            final2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            final2.Font.Name = "Times New Roman";
            final2.Font.Size = "12";
        }

    }
}
