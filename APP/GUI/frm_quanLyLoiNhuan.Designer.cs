﻿namespace GUI
{
    partial class frm_quanLyLoiNhuan
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
            this.themXoaSuaChiPhi = new UC.ThemXoaSua();
            this.label5 = new System.Windows.Forms.Label();
            this.cbo_sanPham = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_timKiem = new System.Windows.Forms.Button();
            this.themXoaSuaCP = new UC.ThemXoaSua();
            this.dgv_dsDoanhThu = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_dsLoiNhuan = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgv_dsChiPhi = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_thoiGian = new System.Windows.Forms.DateTimePicker();
            this.txt_maLoiNhuan = new System.Windows.Forms.TextBox();
            this.txt_moTaLoaiChiPhi = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_loiNhuanGop = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_loiNhuanRong = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_tiLeLoiNhuanRong = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_tiLeLoiNhuanGop = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsDoanhThu)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsLoiNhuan)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsChiPhi)).BeginInit();
            this.SuspendLayout();
            // 
            // themXoaSuaChiPhi
            // 
            this.themXoaSuaChiPhi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.themXoaSuaChiPhi.Location = new System.Drawing.Point(186, 154);
            this.themXoaSuaChiPhi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.themXoaSuaChiPhi.Name = "themXoaSuaChiPhi";
            this.themXoaSuaChiPhi.Size = new System.Drawing.Size(479, 80);
            this.themXoaSuaChiPhi.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label5.Location = new System.Drawing.Point(16, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "Sản phẩm";
            // 
            // cbo_sanPham
            // 
            this.cbo_sanPham.FormattingEnabled = true;
            this.cbo_sanPham.Location = new System.Drawing.Point(148, 28);
            this.cbo_sanPham.Name = "cbo_sanPham";
            this.cbo_sanPham.Size = new System.Drawing.Size(222, 28);
            this.cbo_sanPham.TabIndex = 10;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.dgv_dsChiPhi);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(831, 81);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(668, 443);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thông tin chi phí";
            // 
            // btn_timKiem
            // 
            this.btn_timKiem.BackgroundImage = global::GUI.Properties.Resources.icons8_find_35;
            this.btn_timKiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_timKiem.Location = new System.Drawing.Point(749, 23);
            this.btn_timKiem.Name = "btn_timKiem";
            this.btn_timKiem.Size = new System.Drawing.Size(51, 40);
            this.btn_timKiem.TabIndex = 8;
            this.btn_timKiem.UseVisualStyleBackColor = true;
            // 
            // themXoaSuaCP
            // 
            this.themXoaSuaCP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.themXoaSuaCP.Location = new System.Drawing.Point(124, 165);
            this.themXoaSuaCP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.themXoaSuaCP.Name = "themXoaSuaCP";
            this.themXoaSuaCP.Size = new System.Drawing.Size(412, 76);
            this.themXoaSuaCP.TabIndex = 27;
            // 
            // dgv_dsDoanhThu
            // 
            this.dgv_dsDoanhThu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_dsDoanhThu.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv_dsDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dsDoanhThu.Location = new System.Drawing.Point(7, 26);
            this.dgv_dsDoanhThu.Name = "dgv_dsDoanhThu";
            this.dgv_dsDoanhThu.Size = new System.Drawing.Size(662, 241);
            this.dgv_dsDoanhThu.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgv_dsDoanhThu);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(824, 524);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(675, 273);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin doanh thu";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_tiLeLoiNhuanRong);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txt_tiLeLoiNhuanGop);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txt_loiNhuanRong);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dtp_thoiGian);
            this.groupBox2.Controls.Add(this.txt_maLoiNhuan);
            this.groupBox2.Controls.Add(this.txt_moTaLoaiChiPhi);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txt_loiNhuanGop);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btn_timKiem);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbo_sanPham);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(806, 242);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm thông tin doanh thu";
            // 
            // dgv_dsLoiNhuan
            // 
            this.dgv_dsLoiNhuan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_dsLoiNhuan.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv_dsLoiNhuan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dsLoiNhuan.Location = new System.Drawing.Point(7, 26);
            this.dgv_dsLoiNhuan.Name = "dgv_dsLoiNhuan";
            this.dgv_dsLoiNhuan.Size = new System.Drawing.Size(793, 435);
            this.dgv_dsLoiNhuan.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.dgv_dsLoiNhuan);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 330);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(806, 467);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách lợi nhuận";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1511, 53);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tính toán lợi nhuận ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_dsChiPhi
            // 
            this.dgv_dsChiPhi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_dsChiPhi.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv_dsChiPhi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dsChiPhi.Location = new System.Drawing.Point(6, 19);
            this.dgv_dsChiPhi.Name = "dgv_dsChiPhi";
            this.dgv_dsChiPhi.Size = new System.Drawing.Size(656, 418);
            this.dgv_dsChiPhi.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label1.Location = new System.Drawing.Point(384, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 36;
            this.label1.Text = "Thời gian";
            // 
            // dtp_thoiGian
            // 
            this.dtp_thoiGian.Location = new System.Drawing.Point(479, 28);
            this.dtp_thoiGian.Name = "dtp_thoiGian";
            this.dtp_thoiGian.Size = new System.Drawing.Size(264, 26);
            this.dtp_thoiGian.TabIndex = 29;
            // 
            // txt_maLoiNhuan
            // 
            this.txt_maLoiNhuan.BackColor = System.Drawing.Color.White;
            this.txt_maLoiNhuan.Enabled = false;
            this.txt_maLoiNhuan.Location = new System.Drawing.Point(148, 70);
            this.txt_maLoiNhuan.Name = "txt_maLoiNhuan";
            this.txt_maLoiNhuan.Size = new System.Drawing.Size(222, 26);
            this.txt_maLoiNhuan.TabIndex = 30;
            // 
            // txt_moTaLoaiChiPhi
            // 
            this.txt_moTaLoaiChiPhi.BackColor = System.Drawing.Color.White;
            this.txt_moTaLoaiChiPhi.Location = new System.Drawing.Point(479, 70);
            this.txt_moTaLoaiChiPhi.Multiline = true;
            this.txt_moTaLoaiChiPhi.Name = "txt_moTaLoaiChiPhi";
            this.txt_moTaLoaiChiPhi.Size = new System.Drawing.Size(264, 112);
            this.txt_moTaLoaiChiPhi.TabIndex = 34;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label11.Location = new System.Drawing.Point(384, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 20);
            this.label11.TabIndex = 35;
            this.label11.Text = "Mô tả";
            // 
            // txt_loiNhuanGop
            // 
            this.txt_loiNhuanGop.BackColor = System.Drawing.Color.White;
            this.txt_loiNhuanGop.Location = new System.Drawing.Point(148, 112);
            this.txt_loiNhuanGop.Name = "txt_loiNhuanGop";
            this.txt_loiNhuanGop.Size = new System.Drawing.Size(222, 26);
            this.txt_loiNhuanGop.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label2.Location = new System.Drawing.Point(16, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 20);
            this.label2.TabIndex = 33;
            this.label2.Text = "Lợi nhuận gộp";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label4.Location = new System.Drawing.Point(16, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 20);
            this.label4.TabIndex = 31;
            this.label4.Text = "Mã lợi nhuận";
            // 
            // txt_loiNhuanRong
            // 
            this.txt_loiNhuanRong.BackColor = System.Drawing.Color.White;
            this.txt_loiNhuanRong.Location = new System.Drawing.Point(148, 159);
            this.txt_loiNhuanRong.Name = "txt_loiNhuanRong";
            this.txt_loiNhuanRong.Size = new System.Drawing.Size(222, 26);
            this.txt_loiNhuanRong.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label3.Location = new System.Drawing.Point(16, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 20);
            this.label3.TabIndex = 38;
            this.label3.Text = "Lợi nhuận ròng";
            // 
            // txt_tiLeLoiNhuanRong
            // 
            this.txt_tiLeLoiNhuanRong.BackColor = System.Drawing.Color.White;
            this.txt_tiLeLoiNhuanRong.Location = new System.Drawing.Point(556, 207);
            this.txt_tiLeLoiNhuanRong.Name = "txt_tiLeLoiNhuanRong";
            this.txt_tiLeLoiNhuanRong.Size = new System.Drawing.Size(187, 26);
            this.txt_tiLeLoiNhuanRong.TabIndex = 41;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label7.Location = new System.Drawing.Point(389, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 20);
            this.label7.TabIndex = 42;
            this.label7.Text = "Tỉ lệ lợi nhuận ròng";
            // 
            // txt_tiLeLoiNhuanGop
            // 
            this.txt_tiLeLoiNhuanGop.BackColor = System.Drawing.Color.White;
            this.txt_tiLeLoiNhuanGop.Location = new System.Drawing.Point(177, 206);
            this.txt_tiLeLoiNhuanGop.Name = "txt_tiLeLoiNhuanGop";
            this.txt_tiLeLoiNhuanGop.Size = new System.Drawing.Size(193, 26);
            this.txt_tiLeLoiNhuanGop.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label8.Location = new System.Drawing.Point(16, 209);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 20);
            this.label8.TabIndex = 40;
            this.label8.Text = "Tỉ lệ lợi nhuận gộp";
            // 
            // frm_quanLyLoiNhuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1511, 810);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Name = "frm_quanLyLoiNhuan";
            this.Text = "frm_quanLyLoiNhuan";
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsDoanhThu)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsLoiNhuan)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsChiPhi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private UC.ThemXoaSua themXoaSuaChiPhi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbo_sanPham;
        private System.Windows.Forms.GroupBox groupBox4;
        private UC.ThemXoaSua themXoaSuaCP;
        private System.Windows.Forms.Button btn_timKiem;
        private System.Windows.Forms.DataGridView dgv_dsDoanhThu;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgv_dsLoiNhuan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgv_dsChiPhi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_thoiGian;
        private System.Windows.Forms.TextBox txt_maLoiNhuan;
        private System.Windows.Forms.TextBox txt_moTaLoaiChiPhi;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_loiNhuanGop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_loiNhuanRong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_tiLeLoiNhuanRong;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_tiLeLoiNhuanGop;
        private System.Windows.Forms.Label label8;
    }
}