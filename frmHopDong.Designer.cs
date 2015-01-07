namespace ThanhThanhCong_test
{
    partial class frmHopDong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.dataGridView_HopDong = new System.Windows.Forms.DataGridView();
            this.btn_Them = new System.Windows.Forms.Button();
            this.btn_ChiTiet = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.MaHopDong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen_A1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen_B1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TuVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGiaThue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UngTruoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_HopDong)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.Location = new System.Drawing.Point(841, 355);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(155, 23);
            this.btn_Thoat.TabIndex = 9;
            this.btn_Thoat.Text = "Quay lại trang quản lý";
            this.btn_Thoat.UseVisualStyleBackColor = true;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // dataGridView_HopDong
            // 
            this.dataGridView_HopDong.AllowUserToAddRows = false;
            this.dataGridView_HopDong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_HopDong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_HopDong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHopDong,
            this.HoTen_A1,
            this.HoTen_B1,
            this.SoVu,
            this.TuVu,
            this.DonGiaThue,
            this.TongTien,
            this.UngTruoc});
            this.dataGridView_HopDong.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_HopDong.MultiSelect = false;
            this.dataGridView_HopDong.Name = "dataGridView_HopDong";
            this.dataGridView_HopDong.ReadOnly = true;
            this.dataGridView_HopDong.RowHeadersVisible = false;
            this.dataGridView_HopDong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_HopDong.Size = new System.Drawing.Size(984, 337);
            this.dataGridView_HopDong.TabIndex = 10;
            // 
            // btn_Them
            // 
            this.btn_Them.Location = new System.Drawing.Point(598, 355);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(75, 23);
            this.btn_Them.TabIndex = 11;
            this.btn_Them.Text = "Tạo mới";
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // btn_ChiTiet
            // 
            this.btn_ChiTiet.Location = new System.Drawing.Point(679, 355);
            this.btn_ChiTiet.Name = "btn_ChiTiet";
            this.btn_ChiTiet.Size = new System.Drawing.Size(75, 23);
            this.btn_ChiTiet.TabIndex = 12;
            this.btn_ChiTiet.Text = "Chi tiết";
            this.btn_ChiTiet.UseVisualStyleBackColor = true;
            this.btn_ChiTiet.Click += new System.EventHandler(this.btn_ChiTiet_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Location = new System.Drawing.Point(760, 355);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(75, 23);
            this.btn_Xoa.TabIndex = 13;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.UseVisualStyleBackColor = true;
            // 
            // MaHopDong
            // 
            this.MaHopDong.HeaderText = "Mã hợp đồng";
            this.MaHopDong.Name = "MaHopDong";
            this.MaHopDong.ReadOnly = true;
            // 
            // HoTen_A1
            // 
            this.HoTen_A1.HeaderText = "Bên cho thuê";
            this.HoTen_A1.Name = "HoTen_A1";
            this.HoTen_A1.ReadOnly = true;
            // 
            // HoTen_B1
            // 
            this.HoTen_B1.HeaderText = "Bên thuê đất";
            this.HoTen_B1.Name = "HoTen_B1";
            this.HoTen_B1.ReadOnly = true;
            // 
            // SoVu
            // 
            this.SoVu.HeaderText = "Số vụ";
            this.SoVu.Name = "SoVu";
            this.SoVu.ReadOnly = true;
            // 
            // TuVu
            // 
            this.TuVu.HeaderText = "Từ vụ";
            this.TuVu.Name = "TuVu";
            this.TuVu.ReadOnly = true;
            // 
            // DonGiaThue
            // 
            this.DonGiaThue.HeaderText = "Đơn giá thuê";
            this.DonGiaThue.Name = "DonGiaThue";
            this.DonGiaThue.ReadOnly = true;
            // 
            // TongTien
            // 
            this.TongTien.HeaderText = "Tổng tiền";
            this.TongTien.Name = "TongTien";
            this.TongTien.ReadOnly = true;
            // 
            // UngTruoc
            // 
            this.UngTruoc.HeaderText = "Ứng trước";
            this.UngTruoc.Name = "UngTruoc";
            this.UngTruoc.ReadOnly = true;
            // 
            // frmHopDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 395);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_ChiTiet);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.dataGridView_HopDong);
            this.Controls.Add(this.btn_Thoat);
            this.Name = "frmHopDong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách hợp đồng";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_HopDong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.DataGridView dataGridView_HopDong;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Button btn_ChiTiet;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHopDong;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen_A1;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen_B1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TuVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGiaThue;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn UngTruoc;
    }
}