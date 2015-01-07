namespace ThanhThanhCong_test
{
    partial class frmVung
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
            this.dataGridView_Vung = new System.Windows.Forms.DataGridView();
            this.MaVung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenVung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Them = new System.Windows.Forms.Button();
            this.lb_MaVung = new System.Windows.Forms.Label();
            this.lb_TenVung = new System.Windows.Forms.Label();
            this.txt_MaVung = new System.Windows.Forms.TextBox();
            this.txt_TenVung = new System.Windows.Forms.TextBox();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Huy = new System.Windows.Forms.Button();
            this.btn_Luu = new System.Windows.Forms.Button();
            this.btn_Thoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Vung)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Vung
            // 
            this.dataGridView_Vung.AllowUserToAddRows = false;
            this.dataGridView_Vung.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Vung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Vung.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaVung,
            this.TenVung});
            this.dataGridView_Vung.Location = new System.Drawing.Point(12, 37);
            this.dataGridView_Vung.MultiSelect = false;
            this.dataGridView_Vung.Name = "dataGridView_Vung";
            this.dataGridView_Vung.ReadOnly = true;
            this.dataGridView_Vung.RowHeadersVisible = false;
            this.dataGridView_Vung.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Vung.Size = new System.Drawing.Size(254, 161);
            this.dataGridView_Vung.TabIndex = 0;
            this.dataGridView_Vung.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Vung_CellClick);
            // 
            // MaVung
            // 
            this.MaVung.HeaderText = "Mã vùng";
            this.MaVung.Name = "MaVung";
            this.MaVung.ReadOnly = true;
            // 
            // TenVung
            // 
            this.TenVung.HeaderText = "Tên vùng";
            this.TenVung.Name = "TenVung";
            this.TenVung.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Danh sách vùng";
            // 
            // btn_Them
            // 
            this.btn_Them.Location = new System.Drawing.Point(292, 37);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(75, 23);
            this.btn_Them.TabIndex = 2;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // lb_MaVung
            // 
            this.lb_MaVung.AutoSize = true;
            this.lb_MaVung.Location = new System.Drawing.Point(293, 97);
            this.lb_MaVung.Name = "lb_MaVung";
            this.lb_MaVung.Size = new System.Drawing.Size(52, 13);
            this.lb_MaVung.TabIndex = 3;
            this.lb_MaVung.Text = "Mã vùng:";
            // 
            // lb_TenVung
            // 
            this.lb_TenVung.AutoSize = true;
            this.lb_TenVung.Location = new System.Drawing.Point(289, 123);
            this.lb_TenVung.Name = "lb_TenVung";
            this.lb_TenVung.Size = new System.Drawing.Size(56, 13);
            this.lb_TenVung.TabIndex = 4;
            this.lb_TenVung.Text = "Tên vùng:";
            // 
            // txt_MaVung
            // 
            this.txt_MaVung.BackColor = System.Drawing.SystemColors.Window;
            this.txt_MaVung.Location = new System.Drawing.Point(351, 94);
            this.txt_MaVung.MaxLength = 50;
            this.txt_MaVung.Name = "txt_MaVung";
            this.txt_MaVung.ReadOnly = true;
            this.txt_MaVung.Size = new System.Drawing.Size(100, 20);
            this.txt_MaVung.TabIndex = 5;
            // 
            // txt_TenVung
            // 
            this.txt_TenVung.Location = new System.Drawing.Point(351, 120);
            this.txt_TenVung.MaxLength = 50;
            this.txt_TenVung.Name = "txt_TenVung";
            this.txt_TenVung.Size = new System.Drawing.Size(100, 20);
            this.txt_TenVung.TabIndex = 5;
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Location = new System.Drawing.Point(376, 37);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(75, 23);
            this.btn_Xoa.TabIndex = 2;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_Huy
            // 
            this.btn_Huy.Location = new System.Drawing.Point(376, 175);
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(75, 23);
            this.btn_Huy.TabIndex = 6;
            this.btn_Huy.Text = "Hủy";
            this.btn_Huy.UseVisualStyleBackColor = true;
            this.btn_Huy.Click += new System.EventHandler(this.btn_Huy_Click);
            // 
            // btn_Luu
            // 
            this.btn_Luu.Location = new System.Drawing.Point(376, 146);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(75, 23);
            this.btn_Luu.TabIndex = 7;
            this.btn_Luu.Text = "Lưu";
            this.btn_Luu.UseVisualStyleBackColor = true;
            this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.Location = new System.Drawing.Point(296, 216);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(155, 23);
            this.btn_Thoat.TabIndex = 8;
            this.btn_Thoat.Text = "Quay lại trang quản lý";
            this.btn_Thoat.UseVisualStyleBackColor = true;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // frmVung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 261);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_Huy);
            this.Controls.Add(this.btn_Luu);
            this.Controls.Add(this.txt_TenVung);
            this.Controls.Add(this.txt_MaVung);
            this.Controls.Add(this.lb_TenVung);
            this.Controls.Add(this.lb_MaVung);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_Vung);
            this.Name = "frmVung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vùng";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Vung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Vung;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Label lb_MaVung;
        private System.Windows.Forms.Label lb_TenVung;
        private System.Windows.Forms.TextBox txt_MaVung;
        private System.Windows.Forms.TextBox txt_TenVung;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Huy;
        private System.Windows.Forms.Button btn_Luu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaVung;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenVung;
        private System.Windows.Forms.Button btn_Thoat;
    }
}