namespace ThanhThanhCong_test
{
    partial class frmHopDong_in_Main
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
            this.btn_Xem_MaHopDong = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_MaHopDong = new System.Windows.Forms.TextBox();
            this.btn_Xem_All = new System.Windows.Forms.Button();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Xem_MaHopDong
            // 
            this.btn_Xem_MaHopDong.Location = new System.Drawing.Point(81, 76);
            this.btn_Xem_MaHopDong.Name = "btn_Xem_MaHopDong";
            this.btn_Xem_MaHopDong.Size = new System.Drawing.Size(138, 23);
            this.btn_Xem_MaHopDong.TabIndex = 0;
            this.btn_Xem_MaHopDong.Text = "Xem theo mã HĐ";
            this.btn_Xem_MaHopDong.UseVisualStyleBackColor = true;
            this.btn_Xem_MaHopDong.Click += new System.EventHandler(this.btn_Xem_MaHopDong_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mã HĐ:";
            // 
            // txt_MaHopDong
            // 
            this.txt_MaHopDong.Location = new System.Drawing.Point(119, 50);
            this.txt_MaHopDong.Name = "txt_MaHopDong";
            this.txt_MaHopDong.Size = new System.Drawing.Size(100, 20);
            this.txt_MaHopDong.TabIndex = 4;
            this.txt_MaHopDong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_MaHopDong_KeyPress);
            // 
            // btn_Xem_All
            // 
            this.btn_Xem_All.Location = new System.Drawing.Point(81, 121);
            this.btn_Xem_All.Name = "btn_Xem_All";
            this.btn_Xem_All.Size = new System.Drawing.Size(138, 23);
            this.btn_Xem_All.TabIndex = 5;
            this.btn_Xem_All.Text = "Xem tất cả HĐ";
            this.btn_Xem_All.UseVisualStyleBackColor = true;
            this.btn_Xem_All.Click += new System.EventHandler(this.btn_Xem_All_Click);
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.Location = new System.Drawing.Point(81, 168);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(138, 23);
            this.btn_Thoat.TabIndex = 6;
            this.btn_Thoat.Text = "Quay lại trang quản lý";
            this.btn_Thoat.UseVisualStyleBackColor = true;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // frmHopDong_in_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_Xem_All);
            this.Controls.Add(this.txt_MaHopDong);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Xem_MaHopDong);
            this.Name = "frmHopDong_in_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hợp đồng - Số lần in";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Xem_MaHopDong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_MaHopDong;
        private System.Windows.Forms.Button btn_Xem_All;
        private System.Windows.Forms.Button btn_Thoat;
    }
}