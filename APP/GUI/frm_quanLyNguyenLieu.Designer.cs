namespace GUI
{
    partial class frm_quanLyNguyenLieu
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
            this.themXoaSuaNguyenLieu = new UC.ThemXoaSua();
            this.label10 = new System.Windows.Forms.Label();
            this.dgv_dsNguyenLieu = new System.Windows.Forms.DataGridView();
            this.txtMoTaNguyenLieu = new System.Windows.Forms.TextBox();
            this.txtMaNguyenLieu = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtDanhGiaChatLuongNguyenLieu = new System.Windows.Forms.TextBox();
            this.txtTenNguyenLieu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsNguyenLieu)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // themXoaSuaNguyenLieu
            // 
            this.themXoaSuaNguyenLieu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.themXoaSuaNguyenLieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.themXoaSuaNguyenLieu.Location = new System.Drawing.Point(19, 352);
            this.themXoaSuaNguyenLieu.Margin = new System.Windows.Forms.Padding(6);
            this.themXoaSuaNguyenLieu.Name = "themXoaSuaNguyenLieu";
            this.themXoaSuaNguyenLieu.Size = new System.Drawing.Size(414, 69);
            this.themXoaSuaNguyenLieu.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label10.Location = new System.Drawing.Point(15, 320);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(170, 20);
            this.label10.TabIndex = 25;
            this.label10.Text = "Đánh giá chất lượng";
            // 
            // dgv_dsNguyenLieu
            // 
            this.dgv_dsNguyenLieu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_dsNguyenLieu.BackgroundColor = System.Drawing.Color.White;
            this.dgv_dsNguyenLieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dsNguyenLieu.Location = new System.Drawing.Point(4, 430);
            this.dgv_dsNguyenLieu.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgv_dsNguyenLieu.Name = "dgv_dsNguyenLieu";
            this.dgv_dsNguyenLieu.Size = new System.Drawing.Size(769, 399);
            this.dgv_dsNguyenLieu.TabIndex = 1;
            // 
            // txtMoTaNguyenLieu
            // 
            this.txtMoTaNguyenLieu.Location = new System.Drawing.Point(75, 108);
            this.txtMoTaNguyenLieu.Multiline = true;
            this.txtMoTaNguyenLieu.Name = "txtMoTaNguyenLieu";
            this.txtMoTaNguyenLieu.Size = new System.Drawing.Size(423, 192);
            this.txtMoTaNguyenLieu.TabIndex = 24;
            // 
            // txtMaNguyenLieu
            // 
            this.txtMaNguyenLieu.Enabled = false;
            this.txtMaNguyenLieu.Location = new System.Drawing.Point(196, 22);
            this.txtMaNguyenLieu.Name = "txtMaNguyenLieu";
            this.txtMaNguyenLieu.Size = new System.Drawing.Size(302, 26);
            this.txtMaNguyenLieu.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label11.Location = new System.Drawing.Point(15, 114);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 20);
            this.label11.TabIndex = 23;
            this.label11.Text = "Mô tả";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label13.Location = new System.Drawing.Point(15, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(129, 20);
            this.label13.TabIndex = 19;
            this.label13.Text = "Mã nguyên liệu";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label12.Location = new System.Drawing.Point(15, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(135, 20);
            this.label12.TabIndex = 21;
            this.label12.Text = "Tên nguyên liệu";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtDanhGiaChatLuongNguyenLieu);
            this.groupBox3.Controls.Add(this.themXoaSuaNguyenLieu);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.dgv_dsNguyenLieu);
            this.groupBox3.Controls.Add(this.txtMoTaNguyenLieu);
            this.groupBox3.Controls.Add(this.txtMaNguyenLieu);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtTenNguyenLieu);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(5, 64);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Size = new System.Drawing.Size(777, 832);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chi Tiết Thành Phần Nguyên Liệu";
            // 
            // txtDanhGiaChatLuongNguyenLieu
            // 
            this.txtDanhGiaChatLuongNguyenLieu.Location = new System.Drawing.Point(196, 317);
            this.txtDanhGiaChatLuongNguyenLieu.Name = "txtDanhGiaChatLuongNguyenLieu";
            this.txtDanhGiaChatLuongNguyenLieu.Size = new System.Drawing.Size(302, 26);
            this.txtDanhGiaChatLuongNguyenLieu.TabIndex = 28;
            // 
            // txtTenNguyenLieu
            // 
            this.txtTenNguyenLieu.Location = new System.Drawing.Point(196, 65);
            this.txtTenNguyenLieu.Name = "txtTenNguyenLieu";
            this.txtTenNguyenLieu.Size = new System.Drawing.Size(302, 26);
            this.txtTenNguyenLieu.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1574, 61);
            this.label1.TabIndex = 6;
            this.label1.Text = "Quản lý nguyên liệu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frm_quanLyNguyenLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1574, 920);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label1);
            this.Name = "frm_quanLyNguyenLieu";
            this.Text = "frm_quanLyNguyenLieu";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsNguyenLieu)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private UC.ThemXoaSua themXoaSuaNguyenLieu;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgv_dsNguyenLieu;
        private System.Windows.Forms.TextBox txtMoTaNguyenLieu;
        private System.Windows.Forms.TextBox txtMaNguyenLieu;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtDanhGiaChatLuongNguyenLieu;
        private System.Windows.Forms.TextBox txtTenNguyenLieu;
        private System.Windows.Forms.Label label1;
    }
}