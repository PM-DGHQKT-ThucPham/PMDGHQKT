namespace GUI
{
    partial class frm_quanLyPhanHoiKhachHang
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_DsPhanHoiKhachHang = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLocXepHang = new System.Windows.Forms.Button();
            this.btnLoc = new System.Windows.Forms.Button();
            this.dtpNgayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.cbbXepHang = new System.Windows.Forms.ComboBox();
            this.cbbSanPham = new System.Windows.Forms.ComboBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblSoLuongDanhGia = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lblDiemXepHangTrungBinh = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DsPhanHoiKhachHang)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1528, 53);
            this.label1.TabIndex = 2;
            this.label1.Text = "Phản Hồi Khách Hàng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_DsPhanHoiKhachHang);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(9)))), ((int)(((byte)(176)))));
            this.groupBox1.Location = new System.Drawing.Point(0, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1528, 740);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // dgv_DsPhanHoiKhachHang
            // 
            this.dgv_DsPhanHoiKhachHang.BackgroundColor = System.Drawing.Color.White;
            this.dgv_DsPhanHoiKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DsPhanHoiKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_DsPhanHoiKhachHang.Location = new System.Drawing.Point(3, 176);
            this.dgv_DsPhanHoiKhachHang.Name = "dgv_DsPhanHoiKhachHang";
            this.dgv_DsPhanHoiKhachHang.Size = new System.Drawing.Size(1522, 561);
            this.dgv_DsPhanHoiKhachHang.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLocXepHang);
            this.groupBox2.Controls.Add(this.btnLoc);
            this.groupBox2.Controls.Add(this.dtpNgayKetThuc);
            this.groupBox2.Controls.Add(this.dtpNgayBatDau);
            this.groupBox2.Controls.Add(this.cbbXepHang);
            this.groupBox2.Controls.Add(this.cbbSanPham);
            this.groupBox2.Controls.Add(this.labelControl2);
            this.groupBox2.Controls.Add(this.lblDiemXepHangTrungBinh);
            this.groupBox2.Controls.Add(this.lblSoLuongDanhGia);
            this.groupBox2.Controls.Add(this.labelControl5);
            this.groupBox2.Controls.Add(this.labelControl4);
            this.groupBox2.Controls.Add(this.labelControl3);
            this.groupBox2.Controls.Add(this.labelControl1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1522, 154);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // btnLocXepHang
            // 
            this.btnLocXepHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(9)))), ((int)(((byte)(176)))));
            this.btnLocXepHang.ForeColor = System.Drawing.Color.White;
            this.btnLocXepHang.Location = new System.Drawing.Point(374, 90);
            this.btnLocXepHang.Name = "btnLocXepHang";
            this.btnLocXepHang.Size = new System.Drawing.Size(211, 43);
            this.btnLocXepHang.TabIndex = 5;
            this.btnLocXepHang.Text = "Lọc xếp hạng";
            this.btnLocXepHang.UseVisualStyleBackColor = false;
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(9)))), ((int)(((byte)(176)))));
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(1098, 10);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(71, 43);
            this.btnLoc.TabIndex = 5;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = false;
            // 
            // dtpNgayKetThuc
            // 
            this.dtpNgayKetThuc.Location = new System.Drawing.Point(766, 20);
            this.dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            this.dtpNgayKetThuc.Size = new System.Drawing.Size(294, 26);
            this.dtpNgayKetThuc.TabIndex = 4;
            // 
            // dtpNgayBatDau
            // 
            this.dtpNgayBatDau.Location = new System.Drawing.Point(374, 20);
            this.dtpNgayBatDau.Name = "dtpNgayBatDau";
            this.dtpNgayBatDau.Size = new System.Drawing.Size(294, 26);
            this.dtpNgayBatDau.TabIndex = 4;
            // 
            // cbbXepHang
            // 
            this.cbbXepHang.FormattingEnabled = true;
            this.cbbXepHang.Location = new System.Drawing.Point(109, 98);
            this.cbbXepHang.Name = "cbbXepHang";
            this.cbbXepHang.Size = new System.Drawing.Size(221, 28);
            this.cbbXepHang.TabIndex = 3;
            // 
            // cbbSanPham
            // 
            this.cbbSanPham.FormattingEnabled = true;
            this.cbbSanPham.Location = new System.Drawing.Point(109, 18);
            this.cbbSanPham.Name = "cbbSanPham";
            this.cbbSanPham.Size = new System.Drawing.Size(221, 28);
            this.cbbSanPham.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(700, 25);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(33, 20);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Đến";
            // 
            // lblSoLuongDanhGia
            // 
            this.lblSoLuongDanhGia.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuongDanhGia.Appearance.Options.UseFont = true;
            this.lblSoLuongDanhGia.Location = new System.Drawing.Point(863, 101);
            this.lblSoLuongDanhGia.Name = "lblSoLuongDanhGia";
            this.lblSoLuongDanhGia.Size = new System.Drawing.Size(5, 20);
            this.lblSoLuongDanhGia.TabIndex = 2;
            this.lblSoLuongDanhGia.Text = ":";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(700, 101);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(145, 20);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "Số lượng đánh giá";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(2, 101);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(77, 20);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Xếp hạng";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(3, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(81, 20);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Sản phẩm";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(1190, 21);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(205, 20);
            this.labelControl5.TabIndex = 2;
            this.labelControl5.Text = "Điểm xếp hạng trung bình";
            // 
            // lblDiemXepHangTrungBinh
            // 
            this.lblDiemXepHangTrungBinh.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiemXepHangTrungBinh.Appearance.Options.UseFont = true;
            this.lblDiemXepHangTrungBinh.Location = new System.Drawing.Point(1414, 20);
            this.lblDiemXepHangTrungBinh.Name = "lblDiemXepHangTrungBinh";
            this.lblDiemXepHangTrungBinh.Size = new System.Drawing.Size(5, 20);
            this.lblDiemXepHangTrungBinh.TabIndex = 2;
            this.lblDiemXepHangTrungBinh.Text = ":";
            // 
            // frm_quanLyPhanHoiKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1528, 793);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frm_quanLyPhanHoiKhachHang";
            this.Text = "frm_quanLyPhanHoiKhachHang";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DsPhanHoiKhachHang)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_DsPhanHoiKhachHang;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbbSanPham;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.DateTimePicker dtpNgayKetThuc;
        private System.Windows.Forms.DateTimePicker dtpNgayBatDau;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.Button btnLocXepHang;
        private System.Windows.Forms.ComboBox cbbXepHang;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lblSoLuongDanhGia;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl lblDiemXepHangTrungBinh;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}