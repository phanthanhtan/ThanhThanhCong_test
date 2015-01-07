namespace ThanhThanhCong_test
{
    partial class Main
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
            this.btn_Them = new System.Windows.Forms.Button();
            this.btn_DanhSach = new System.Windows.Forms.Button();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.btn_Vung = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Them
            // 
            this.btn_Them.Location = new System.Drawing.Point(72, 50);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(139, 23);
            this.btn_Them.TabIndex = 0;
            this.btn_Them.Text = "Tạo mới hợp đồng";
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // btn_DanhSach
            // 
            this.btn_DanhSach.Location = new System.Drawing.Point(72, 94);
            this.btn_DanhSach.Name = "btn_DanhSach";
            this.btn_DanhSach.Size = new System.Drawing.Size(139, 23);
            this.btn_DanhSach.TabIndex = 1;
            this.btn_DanhSach.Text = "Danh sách hợp đồng";
            this.btn_DanhSach.UseVisualStyleBackColor = true;
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.Location = new System.Drawing.Point(72, 182);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(139, 23);
            this.btn_Thoat.TabIndex = 2;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.UseVisualStyleBackColor = true;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // btn_Vung
            // 
            this.btn_Vung.Location = new System.Drawing.Point(72, 140);
            this.btn_Vung.Name = "btn_Vung";
            this.btn_Vung.Size = new System.Drawing.Size(139, 23);
            this.btn_Vung.TabIndex = 3;
            this.btn_Vung.Text = "Vùng";
            this.btn_Vung.UseVisualStyleBackColor = true;
            this.btn_Vung.Click += new System.EventHandler(this.btn_Vung_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btn_Vung);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_DanhSach);
            this.Controls.Add(this.btn_Them);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý - Hợp đồng thuê đất";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Button btn_DanhSach;
        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.Button btn_Vung;
    }
}