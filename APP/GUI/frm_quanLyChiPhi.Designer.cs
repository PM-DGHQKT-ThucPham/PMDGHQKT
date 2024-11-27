namespace GUI
{
    partial class frm_quanLyChiPhi
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
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_dsLoaiChiPhi = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_khoiPhuc = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.themXoaSuaChiPhi = new UC.ThemXoaSua();
            this.txt_maLoaiChiPhi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_moTaLoaiChiPhi = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_tongTien = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_tenLoaiChiPhi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbo_sanPham = new System.Windows.Forms.ComboBox();
            this.btn_timKiem = new System.Windows.Forms.Button();
            this.txt_timKiem = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_dsChiPhi = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.themXoaSuaCP = new UC.ThemXoaSua();
            this.cbo_loaiChiPhi = new System.Windows.Forms.ComboBox();
            this.cbp_chucNang = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtp_thoiGian = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_soTien = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_moTaChiPhi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_maChiPhi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsLoaiChiPhi)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsChiPhi)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
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
            this.label6.TabIndex = 6;
            this.label6.Text = "Quản lý chi phí";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.dgv_dsLoaiChiPhi);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 316);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(806, 467);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách loại chi phí";
            // 
            // dgv_dsLoaiChiPhi
            // 
            this.dgv_dsLoaiChiPhi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_dsLoaiChiPhi.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv_dsLoaiChiPhi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dsLoaiChiPhi.Location = new System.Drawing.Point(7, 26);
            this.dgv_dsLoaiChiPhi.Name = "dgv_dsLoaiChiPhi";
            this.dgv_dsLoaiChiPhi.Size = new System.Drawing.Size(793, 435);
            this.dgv_dsLoaiChiPhi.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_khoiPhuc);
            this.groupBox2.Controls.Add(this.btn_clear);
            this.groupBox2.Controls.Add(this.themXoaSuaChiPhi);
            this.groupBox2.Controls.Add(this.txt_maLoaiChiPhi);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_moTaLoaiChiPhi);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txt_tongTien);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txt_tenLoaiChiPhi);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cbo_sanPham);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(806, 242);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm thông tin doanh thu";
            // 
            // btn_khoiPhuc
            // 
            this.btn_khoiPhuc.BackgroundImage = global::GUI.Properties.Resources.icons8_load_32;
            this.btn_khoiPhuc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_khoiPhuc.Location = new System.Drawing.Point(672, 175);
            this.btn_khoiPhuc.Name = "btn_khoiPhuc";
            this.btn_khoiPhuc.Size = new System.Drawing.Size(54, 50);
            this.btn_khoiPhuc.TabIndex = 27;
            this.btn_khoiPhuc.UseVisualStyleBackColor = true;
            // 
            // btn_clear
            // 
            this.btn_clear.BackgroundImage = global::GUI.Properties.Resources.icons8_clear_32;
            this.btn_clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_clear.Location = new System.Drawing.Point(428, 113);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(51, 40);
            this.btn_clear.TabIndex = 26;
            this.btn_clear.UseVisualStyleBackColor = true;
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
            // txt_maLoaiChiPhi
            // 
            this.txt_maLoaiChiPhi.BackColor = System.Drawing.Color.White;
            this.txt_maLoaiChiPhi.Enabled = false;
            this.txt_maLoaiChiPhi.Location = new System.Drawing.Point(149, 24);
            this.txt_maLoaiChiPhi.Name = "txt_maLoaiChiPhi";
            this.txt_maLoaiChiPhi.Size = new System.Drawing.Size(253, 26);
            this.txt_maLoaiChiPhi.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label5.Location = new System.Drawing.Point(441, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "Sản phẩm";
            // 
            // txt_moTaLoaiChiPhi
            // 
            this.txt_moTaLoaiChiPhi.BackColor = System.Drawing.Color.White;
            this.txt_moTaLoaiChiPhi.Location = new System.Drawing.Point(149, 66);
            this.txt_moTaLoaiChiPhi.Multiline = true;
            this.txt_moTaLoaiChiPhi.Name = "txt_moTaLoaiChiPhi";
            this.txt_moTaLoaiChiPhi.Size = new System.Drawing.Size(253, 48);
            this.txt_moTaLoaiChiPhi.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label11.Location = new System.Drawing.Point(17, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 20);
            this.label11.TabIndex = 24;
            this.label11.Text = "Mô tả";
            // 
            // txt_tongTien
            // 
            this.txt_tongTien.BackColor = System.Drawing.Color.White;
            this.txt_tongTien.Location = new System.Drawing.Point(149, 120);
            this.txt_tongTien.Name = "txt_tongTien";
            this.txt_tongTien.Size = new System.Drawing.Size(253, 26);
            this.txt_tongTien.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label2.Location = new System.Drawing.Point(17, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Tổng tiền";
            // 
            // txt_tenLoaiChiPhi
            // 
            this.txt_tenLoaiChiPhi.BackColor = System.Drawing.Color.White;
            this.txt_tenLoaiChiPhi.Location = new System.Drawing.Point(540, 24);
            this.txt_tenLoaiChiPhi.Name = "txt_tenLoaiChiPhi";
            this.txt_tenLoaiChiPhi.Size = new System.Drawing.Size(253, 26);
            this.txt_tenLoaiChiPhi.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label3.Location = new System.Drawing.Point(441, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Tên loại";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label4.Location = new System.Drawing.Point(17, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Mã loại chi phí";
            // 
            // cbo_sanPham
            // 
            this.cbo_sanPham.FormattingEnabled = true;
            this.cbo_sanPham.Location = new System.Drawing.Point(540, 66);
            this.cbo_sanPham.Name = "cbo_sanPham";
            this.cbo_sanPham.Size = new System.Drawing.Size(253, 28);
            this.cbo_sanPham.TabIndex = 10;
            // 
            // btn_timKiem
            // 
            this.btn_timKiem.BackgroundImage = global::GUI.Properties.Resources.icons8_find_35;
            this.btn_timKiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_timKiem.Location = new System.Drawing.Point(611, 127);
            this.btn_timKiem.Name = "btn_timKiem";
            this.btn_timKiem.Size = new System.Drawing.Size(51, 40);
            this.btn_timKiem.TabIndex = 8;
            this.btn_timKiem.UseVisualStyleBackColor = true;
            // 
            // txt_timKiem
            // 
            this.txt_timKiem.Location = new System.Drawing.Point(428, 132);
            this.txt_timKiem.Name = "txt_timKiem";
            this.txt_timKiem.Size = new System.Drawing.Size(177, 26);
            this.txt_timKiem.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgv_dsChiPhi);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(824, 316);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(675, 467);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách chi phí";
            // 
            // dgv_dsChiPhi
            // 
            this.dgv_dsChiPhi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_dsChiPhi.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv_dsChiPhi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dsChiPhi.Location = new System.Drawing.Point(7, 26);
            this.dgv_dsChiPhi.Name = "dgv_dsChiPhi";
            this.dgv_dsChiPhi.Size = new System.Drawing.Size(662, 435);
            this.dgv_dsChiPhi.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.themXoaSuaCP);
            this.groupBox4.Controls.Add(this.cbo_loaiChiPhi);
            this.groupBox4.Controls.Add(this.cbp_chucNang);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.dtp_thoiGian);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.txt_soTien);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txt_moTaChiPhi);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.txt_maChiPhi);
            this.groupBox4.Controls.Add(this.btn_timKiem);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.txt_timKiem);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(831, 67);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(668, 243);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thông tin chi phí";
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
            // cbo_loaiChiPhi
            // 
            this.cbo_loaiChiPhi.FormattingEnabled = true;
            this.cbo_loaiChiPhi.Location = new System.Drawing.Point(165, 132);
            this.cbo_loaiChiPhi.Name = "cbo_loaiChiPhi";
            this.cbo_loaiChiPhi.Size = new System.Drawing.Size(253, 28);
            this.cbo_loaiChiPhi.TabIndex = 27;
            // 
            // cbp_chucNang
            // 
            this.cbp_chucNang.FormattingEnabled = true;
            this.cbp_chucNang.Location = new System.Drawing.Point(428, 99);
            this.cbp_chucNang.Name = "cbp_chucNang";
            this.cbp_chucNang.Size = new System.Drawing.Size(177, 28);
            this.cbp_chucNang.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label10.Location = new System.Drawing.Point(424, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 20);
            this.label10.TabIndex = 12;
            this.label10.Text = "Thời gian";
            // 
            // dtp_thoiGian
            // 
            this.dtp_thoiGian.Location = new System.Drawing.Point(433, 59);
            this.dtp_thoiGian.Name = "dtp_thoiGian";
            this.dtp_thoiGian.Size = new System.Drawing.Size(241, 26);
            this.dtp_thoiGian.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label9.Location = new System.Drawing.Point(33, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "Mã loại chi phí";
            // 
            // txt_soTien
            // 
            this.txt_soTien.BackColor = System.Drawing.Color.White;
            this.txt_soTien.Location = new System.Drawing.Point(165, 96);
            this.txt_soTien.Name = "txt_soTien";
            this.txt_soTien.Size = new System.Drawing.Size(253, 26);
            this.txt_soTien.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label8.Location = new System.Drawing.Point(33, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Số tiền";
            // 
            // txt_moTaChiPhi
            // 
            this.txt_moTaChiPhi.BackColor = System.Drawing.Color.White;
            this.txt_moTaChiPhi.Location = new System.Drawing.Point(165, 59);
            this.txt_moTaChiPhi.Name = "txt_moTaChiPhi";
            this.txt_moTaChiPhi.Size = new System.Drawing.Size(253, 26);
            this.txt_moTaChiPhi.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label7.Location = new System.Drawing.Point(33, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Mô tả";
            // 
            // txt_maChiPhi
            // 
            this.txt_maChiPhi.BackColor = System.Drawing.Color.White;
            this.txt_maChiPhi.Enabled = false;
            this.txt_maChiPhi.Location = new System.Drawing.Point(165, 25);
            this.txt_maChiPhi.Name = "txt_maChiPhi";
            this.txt_maChiPhi.Size = new System.Drawing.Size(253, 26);
            this.txt_maChiPhi.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label1.Location = new System.Drawing.Point(33, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Mã chi phí";
            // 
            // frm_quanLyChiPhi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1511, 810);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label6);
            this.Name = "frm_quanLyChiPhi";
            this.Text = "frm_quanLyChiPhi";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsLoaiChiPhi)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsChiPhi)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_dsLoaiChiPhi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbo_sanPham;
        private System.Windows.Forms.Button btn_timKiem;
        private System.Windows.Forms.TextBox txt_timKiem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_dsChiPhi;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txt_maChiPhi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_maLoaiChiPhi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_soTien;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_moTaChiPhi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtp_thoiGian;
        private System.Windows.Forms.TextBox txt_moTaLoaiChiPhi;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_tongTien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_tenLoaiChiPhi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbp_chucNang;
        private System.Windows.Forms.Label label5;
        private UC.ThemXoaSua themXoaSuaChiPhi;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.ComboBox cbo_loaiChiPhi;
        private UC.ThemXoaSua themXoaSuaCP;
        private System.Windows.Forms.Button btn_khoiPhuc;
    }
}