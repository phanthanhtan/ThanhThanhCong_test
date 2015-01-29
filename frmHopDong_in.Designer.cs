namespace ThanhThanhCong_test
{
    partial class frmHopDong_in
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
            this.btn_DanhSachHopDong = new System.Windows.Forms.Button();
            this.dataGridView_HopDong_in = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_HopDong_in)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_DanhSachHopDong
            // 
            this.btn_DanhSachHopDong.Location = new System.Drawing.Point(197, 238);
            this.btn_DanhSachHopDong.Name = "btn_DanhSachHopDong";
            this.btn_DanhSachHopDong.Size = new System.Drawing.Size(165, 23);
            this.btn_DanhSachHopDong.TabIndex = 82;
            this.btn_DanhSachHopDong.Text = "Danh sách hợp đồng";
            this.btn_DanhSachHopDong.UseVisualStyleBackColor = true;
            this.btn_DanhSachHopDong.Click += new System.EventHandler(this.btn_DanhSachHopDong_Click);
            // 
            // dataGridView_HopDong_in
            // 
            this.dataGridView_HopDong_in.AllowUserToAddRows = false;
            this.dataGridView_HopDong_in.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_HopDong_in.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_HopDong_in.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Time});
            this.dataGridView_HopDong_in.Location = new System.Drawing.Point(15, 25);
            this.dataGridView_HopDong_in.Name = "dataGridView_HopDong_in";
            this.dataGridView_HopDong_in.ReadOnly = true;
            this.dataGridView_HopDong_in.RowHeadersVisible = false;
            this.dataGridView_HopDong_in.Size = new System.Drawing.Size(347, 207);
            this.dataGridView_HopDong_in.TabIndex = 83;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 84;
            this.label1.Text = "Mã hợp đồng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 84;
            this.label2.Text = "label1";
            // 
            // ID
            // 
            this.ID.HeaderText = "Tên đăng nhập";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Time
            // 
            this.Time.HeaderText = "Thời gian in";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            // 
            // frmHopDong_in
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 273);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_HopDong_in);
            this.Controls.Add(this.btn_DanhSachHopDong);
            this.Name = "frmHopDong_in";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hợp đồng - Số lượng in";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_HopDong_in)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_DanhSachHopDong;
        private System.Windows.Forms.DataGridView dataGridView_HopDong_in;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;

    }
}