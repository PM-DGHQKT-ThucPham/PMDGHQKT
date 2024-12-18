﻿namespace GUI
{
    partial class frm_quanLyHieuSuat
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
            this.dgvHieuSuat = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.themXoaSua = new UC.ThemXoaSua();
            this.btnXemThietKe = new System.Windows.Forms.Button();
            this.txtMucDoAnhHuong = new System.Windows.Forms.TextBox();
            this.txtDanhGiaTocDo = new System.Windows.Forms.TextBox();
            this.txtDanhGiaChucNang = new System.Windows.Forms.TextBox();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.txtMaHieuSuat = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSanPham = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHieuSuat)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvHieuSuat
            // 
            this.dgvHieuSuat.BackgroundColor = System.Drawing.Color.White;
            this.dgvHieuSuat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHieuSuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHieuSuat.Location = new System.Drawing.Point(3, 22);
            this.dgvHieuSuat.Name = "dgvHieuSuat";
            this.dgvHieuSuat.Size = new System.Drawing.Size(1261, 324);
            this.dgvHieuSuat.TabIndex = 0;
            this.dgvHieuSuat.SelectionChanged += new System.EventHandler(this.dgvHieuSuat_SelectionChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvHieuSuat);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(12, 452);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1267, 349);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách tiêu chí đánh giá hiệu quả của sản phẩm";
            // 
            // themXoaSua
            // 
            this.themXoaSua.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.themXoaSua.AutoSize = true;
            this.themXoaSua.Location = new System.Drawing.Point(374, 238);
            this.themXoaSua.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.themXoaSua.Name = "themXoaSua";
            this.themXoaSua.Size = new System.Drawing.Size(518, 112);
            this.themXoaSua.TabIndex = 11;
            this.themXoaSua.XoaClicked += new System.EventHandler(this.themXoaSua_XoaClicked);
            this.themXoaSua.SuaClicked += new System.EventHandler(this.themXoaSua_SuaClicked);
            this.themXoaSua.LuuClicked += new System.EventHandler(this.themXoaSua_LuuClicked);
            this.themXoaSua.HuyThemClicked += new System.EventHandler(this.themXoaSua_HuyThemClicked);
            // 
            // btnXemThietKe
            // 
            this.btnXemThietKe.AutoSize = true;
            this.btnXemThietKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemThietKe.Location = new System.Drawing.Point(113, 90);
            this.btnXemThietKe.Name = "btnXemThietKe";
            this.btnXemThietKe.Size = new System.Drawing.Size(129, 30);
            this.btnXemThietKe.TabIndex = 12;
            this.btnXemThietKe.Text = "Xem hiệu quả";
            this.btnXemThietKe.UseVisualStyleBackColor = true;
            // 
            // txtMucDoAnhHuong
            // 
            this.txtMucDoAnhHuong.Location = new System.Drawing.Point(556, 184);
            this.txtMucDoAnhHuong.Name = "txtMucDoAnhHuong";
            this.txtMucDoAnhHuong.Size = new System.Drawing.Size(100, 26);
            this.txtMucDoAnhHuong.TabIndex = 3;
            this.txtMucDoAnhHuong.TextChanged += new System.EventHandler(this.txtDanhGiaChucNang_TextChanged);
            this.txtMucDoAnhHuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhGiaChucNang_KeyPress);
            // 
            // txtDanhGiaTocDo
            // 
            this.txtDanhGiaTocDo.Location = new System.Drawing.Point(556, 129);
            this.txtDanhGiaTocDo.Name = "txtDanhGiaTocDo";
            this.txtDanhGiaTocDo.Size = new System.Drawing.Size(100, 26);
            this.txtDanhGiaTocDo.TabIndex = 2;
            this.txtDanhGiaTocDo.TextChanged += new System.EventHandler(this.txtDanhGiaChucNang_TextChanged);
            this.txtDanhGiaTocDo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhGiaChucNang_KeyPress);
            // 
            // txtDanhGiaChucNang
            // 
            this.txtDanhGiaChucNang.Location = new System.Drawing.Point(556, 74);
            this.txtDanhGiaChucNang.Name = "txtDanhGiaChucNang";
            this.txtDanhGiaChucNang.Size = new System.Drawing.Size(100, 26);
            this.txtDanhGiaChucNang.TabIndex = 1;
            this.txtDanhGiaChucNang.TextChanged += new System.EventHandler(this.txtDanhGiaChucNang_TextChanged);
            this.txtDanhGiaChucNang.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhGiaChucNang_KeyPress);
            // 
            // txtMoTa
            // 
            this.txtMoTa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMoTa.Location = new System.Drawing.Point(781, 19);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(480, 191);
            this.txtMoTa.TabIndex = 4;
            // 
            // txtMaHieuSuat
            // 
            this.txtMaHieuSuat.Enabled = false;
            this.txtMaHieuSuat.Location = new System.Drawing.Point(556, 19);
            this.txtMaHieuSuat.Name = "txtMaHieuSuat";
            this.txtMaHieuSuat.Size = new System.Drawing.Size(100, 26);
            this.txtMaHieuSuat.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(726, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Mô tả";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(384, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Mức độ ảnh hưởng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(384, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Đánh giá tốc độ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(384, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Đánh giá chức năng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(384, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mã hiệu suất";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Chọn sản phẩm";
            // 
            // cboSanPham
            // 
            this.cboSanPham.FormattingEnabled = true;
            this.cboSanPham.Location = new System.Drawing.Point(10, 45);
            this.cboSanPham.Name = "cboSanPham";
            this.cboSanPham.Size = new System.Drawing.Size(314, 28);
            this.cboSanPham.TabIndex = 13;
            this.cboSanPham.SelectedIndexChanged += new System.EventHandler(this.cboSanPham_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.themXoaSua);
            this.groupBox1.Controls.Add(this.btnXemThietKe);
            this.groupBox1.Controls.Add(this.txtMucDoAnhHuong);
            this.groupBox1.Controls.Add(this.txtDanhGiaTocDo);
            this.groupBox1.Controls.Add(this.txtDanhGiaChucNang);
            this.groupBox1.Controls.Add(this.txtMoTa);
            this.groupBox1.Controls.Add(this.txtMaHieuSuat);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboSanPham);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(12, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1267, 384);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chi tiết";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1291, 53);
            this.label1.TabIndex = 4;
            this.label1.Text = "QUẢN LÝ TIÊU CHÍ HIỆU SUẤT";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frm_quanLyHieuSuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1291, 807);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frm_quanLyHieuSuat";
            this.Text = "frm_quanLyHieuSuat";
            this.Load += new System.EventHandler(this.frm_quanLyHieuSuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHieuSuat)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHieuSuat;
        private System.Windows.Forms.GroupBox groupBox2;
        private UC.ThemXoaSua themXoaSua;
        private System.Windows.Forms.Button btnXemThietKe;
        private System.Windows.Forms.TextBox txtMucDoAnhHuong;
        private System.Windows.Forms.TextBox txtDanhGiaTocDo;
        private System.Windows.Forms.TextBox txtDanhGiaChucNang;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.TextBox txtMaHieuSuat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboSanPham;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
    }
}