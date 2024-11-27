namespace GUI
{
    partial class frm_quanLyKhoHang
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_dsSanPham = new System.Windows.Forms.DataGridView();
            this.dtpNgayPhatHanh = new System.Windows.Forms.DateTimePicker();
            this.txtMucDoAnhHuongNguyenLieu = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSoLuongTon = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDanhMuc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenSanPham = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaSanPham = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPhanTramNguyenLieu = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dgv_ChiTietThanhPhan = new System.Windows.Forms.DataGridView();
            this.txtMoTaNguyenLieu = new System.Windows.Forms.TextBox();
            this.txtMaNguyenLieu = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTenNguyenLieu = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDanhGiaChatLuongNguyenLieu = new System.Windows.Forms.TextBox();
            this.themXoaSuaCTTP = new UC.ThemXoaSua();
            this.themXoaSuaSanPham = new UC.ThemXoaSua();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsSanPham)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ChiTietThanhPhan)).BeginInit();
            this.SuspendLayout();
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
            this.label1.TabIndex = 2;
            this.label1.Text = "Quản lý kho hàng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.dtpNgayPhatHanh);
            this.groupBox1.Controls.Add(this.txtMucDoAnhHuongNguyenLieu);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtSoLuongTon);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtDanhMuc);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtGia);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtMoTa);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtTenSanPham);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMaSanPham);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.themXoaSuaSanPham);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 64);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(922, 844);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sản phẩm";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgv_dsSanPham);
            this.groupBox2.Location = new System.Drawing.Point(7, 417);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(908, 343);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách sản phẩm";
            // 
            // dgv_dsSanPham
            // 
            this.dgv_dsSanPham.BackgroundColor = System.Drawing.Color.White;
            this.dgv_dsSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dsSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_dsSanPham.Location = new System.Drawing.Point(3, 22);
            this.dgv_dsSanPham.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgv_dsSanPham.Name = "dgv_dsSanPham";
            this.dgv_dsSanPham.Size = new System.Drawing.Size(902, 318);
            this.dgv_dsSanPham.TabIndex = 1;
            // 
            // dtpNgayPhatHanh
            // 
            this.dtpNgayPhatHanh.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpNgayPhatHanh.Location = new System.Drawing.Point(607, 154);
            this.dtpNgayPhatHanh.Name = "dtpNgayPhatHanh";
            this.dtpNgayPhatHanh.Size = new System.Drawing.Size(302, 26);
            this.dtpNgayPhatHanh.TabIndex = 18;
            // 
            // txtMucDoAnhHuongNguyenLieu
            // 
            this.txtMucDoAnhHuongNguyenLieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMucDoAnhHuongNguyenLieu.Location = new System.Drawing.Point(737, 347);
            this.txtMucDoAnhHuongNguyenLieu.Name = "txtMucDoAnhHuongNguyenLieu";
            this.txtMucDoAnhHuongNguyenLieu.Size = new System.Drawing.Size(178, 26);
            this.txtMucDoAnhHuongNguyenLieu.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label9.Location = new System.Drawing.Point(478, 350);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(253, 20);
            this.label9.TabIndex = 16;
            this.label9.Text = "Mức độ ảnh hưởng nguyên liệu";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label8.Location = new System.Drawing.Point(472, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Ngày phát hành";
            // 
            // txtSoLuongTon
            // 
            this.txtSoLuongTon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSoLuongTon.Location = new System.Drawing.Point(607, 109);
            this.txtSoLuongTon.Name = "txtSoLuongTon";
            this.txtSoLuongTon.Size = new System.Drawing.Size(302, 26);
            this.txtSoLuongTon.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label7.Location = new System.Drawing.Point(472, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Số lượng tồn";
            // 
            // txtDanhMuc
            // 
            this.txtDanhMuc.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDanhMuc.Location = new System.Drawing.Point(607, 66);
            this.txtDanhMuc.Name = "txtDanhMuc";
            this.txtDanhMuc.Size = new System.Drawing.Size(302, 26);
            this.txtDanhMuc.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label6.Location = new System.Drawing.Point(472, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Danh mục";
            // 
            // txtGia
            // 
            this.txtGia.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtGia.Location = new System.Drawing.Point(607, 23);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(302, 26);
            this.txtGia.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label5.Location = new System.Drawing.Point(472, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Giá";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMoTa.Location = new System.Drawing.Point(74, 87);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(377, 236);
            this.txtMoTa.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label4.Location = new System.Drawing.Point(14, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mô tả";
            // 
            // txtTenSanPham
            // 
            this.txtTenSanPham.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTenSanPham.Location = new System.Drawing.Point(149, 55);
            this.txtTenSanPham.Name = "txtTenSanPham";
            this.txtTenSanPham.Size = new System.Drawing.Size(302, 26);
            this.txtTenSanPham.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label3.Location = new System.Drawing.Point(14, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tên sản phẩm";
            // 
            // txtMaSanPham
            // 
            this.txtMaSanPham.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMaSanPham.Location = new System.Drawing.Point(149, 23);
            this.txtMaSanPham.Name = "txtMaSanPham";
            this.txtMaSanPham.Size = new System.Drawing.Size(302, 26);
            this.txtMaSanPham.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label2.Location = new System.Drawing.Point(14, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã sản phẩm";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtDanhGiaChatLuongNguyenLieu);
            this.groupBox3.Controls.Add(this.txtPhanTramNguyenLieu);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.themXoaSuaCTTP);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.dgv_ChiTietThanhPhan);
            this.groupBox3.Controls.Add(this.txtMoTaNguyenLieu);
            this.groupBox3.Controls.Add(this.txtMaNguyenLieu);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtTenNguyenLieu);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(946, 73);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Size = new System.Drawing.Size(624, 832);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Nguyên liệu";
            // 
            // txtPhanTramNguyenLieu
            // 
            this.txtPhanTramNguyenLieu.Location = new System.Drawing.Point(196, 315);
            this.txtPhanTramNguyenLieu.Name = "txtPhanTramNguyenLieu";
            this.txtPhanTramNguyenLieu.Size = new System.Drawing.Size(302, 26);
            this.txtPhanTramNguyenLieu.TabIndex = 28;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label14.Location = new System.Drawing.Point(15, 321);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 20);
            this.label14.TabIndex = 27;
            this.label14.Text = "Phần trăm";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label10.Location = new System.Drawing.Point(15, 272);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(170, 20);
            this.label10.TabIndex = 25;
            this.label10.Text = "Đánh giá chất lượng";
            // 
            // dgv_ChiTietThanhPhan
            // 
            this.dgv_ChiTietThanhPhan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ChiTietThanhPhan.BackgroundColor = System.Drawing.Color.White;
            this.dgv_ChiTietThanhPhan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ChiTietThanhPhan.Location = new System.Drawing.Point(4, 430);
            this.dgv_ChiTietThanhPhan.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgv_ChiTietThanhPhan.Name = "dgv_ChiTietThanhPhan";
            this.dgv_ChiTietThanhPhan.Size = new System.Drawing.Size(616, 399);
            this.dgv_ChiTietThanhPhan.TabIndex = 1;
            // 
            // txtMoTaNguyenLieu
            // 
            this.txtMoTaNguyenLieu.Enabled = false;
            this.txtMoTaNguyenLieu.Location = new System.Drawing.Point(75, 108);
            this.txtMoTaNguyenLieu.Multiline = true;
            this.txtMoTaNguyenLieu.Name = "txtMoTaNguyenLieu";
            this.txtMoTaNguyenLieu.Size = new System.Drawing.Size(423, 155);
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
            // txtTenNguyenLieu
            // 
            this.txtTenNguyenLieu.Enabled = false;
            this.txtTenNguyenLieu.Location = new System.Drawing.Point(196, 65);
            this.txtTenNguyenLieu.Name = "txtTenNguyenLieu";
            this.txtTenNguyenLieu.Size = new System.Drawing.Size(302, 26);
            this.txtTenNguyenLieu.TabIndex = 22;
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
            // txtDanhGiaChatLuongNguyenLieu
            // 
            this.txtDanhGiaChatLuongNguyenLieu.Enabled = false;
            this.txtDanhGiaChatLuongNguyenLieu.Location = new System.Drawing.Point(196, 269);
            this.txtDanhGiaChatLuongNguyenLieu.Name = "txtDanhGiaChatLuongNguyenLieu";
            this.txtDanhGiaChatLuongNguyenLieu.Size = new System.Drawing.Size(302, 26);
            this.txtDanhGiaChatLuongNguyenLieu.TabIndex = 28;
            // 
            // themXoaSuaCTTP
            // 
            this.themXoaSuaCTTP.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.themXoaSuaCTTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.themXoaSuaCTTP.Location = new System.Drawing.Point(4, 352);
            this.themXoaSuaCTTP.Margin = new System.Windows.Forms.Padding(6);
            this.themXoaSuaCTTP.Name = "themXoaSuaCTTP";
            this.themXoaSuaCTTP.Size = new System.Drawing.Size(414, 69);
            this.themXoaSuaCTTP.TabIndex = 2;
            // 
            // themXoaSuaSanPham
            // 
            this.themXoaSuaSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.themXoaSuaSanPham.Location = new System.Drawing.Point(10, 315);
            this.themXoaSuaSanPham.Margin = new System.Windows.Forms.Padding(9);
            this.themXoaSuaSanPham.Name = "themXoaSuaSanPham";
            this.themXoaSuaSanPham.Size = new System.Drawing.Size(418, 83);
            this.themXoaSuaSanPham.TabIndex = 1;
            // 
            // frm_quanLyKhoHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1574, 920);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frm_quanLyKhoHang";
            this.Text = "frm_khoHang";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsSanPham)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ChiTietThanhPhan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private UC.ThemXoaSua themXoaSuaSanPham;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_ChiTietThanhPhan;
        private UC.ThemXoaSua themXoaSuaCTTP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaSanPham;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTenSanPham;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSoLuongTon;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDanhMuc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpNgayPhatHanh;
        private System.Windows.Forms.TextBox txtMucDoAnhHuongNguyenLieu;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMoTaNguyenLieu;
        private System.Windows.Forms.TextBox txtMaNguyenLieu;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTenNguyenLieu;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPhanTramNguyenLieu;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgv_dsSanPham;
        private System.Windows.Forms.TextBox txtDanhGiaChatLuongNguyenLieu;
    }
}