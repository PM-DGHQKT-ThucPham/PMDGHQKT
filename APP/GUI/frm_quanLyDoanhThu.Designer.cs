namespace GUI
{
    partial class frm_quanLyDoanhThu
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
            this.dgv_dsLoaiDoanhThu = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_dsDoanhThu = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_khoiPhuc = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.themXoaSuaDoanhThu = new UC.ThemXoaSua();
            this.txt_maLoaiDoanhThu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_moTaLoaiDoanhThu = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_tongTienDoanhThu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_tenLoaiDoanhThu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbo_sanPham = new System.Windows.Forms.ComboBox();
            this.themXoaSuaDT = new UC.ThemXoaSua();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbo_loaiDoanhThu = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtp_thoiGianDoanhThu = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_soTienDoanhThu = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_moTaDoanhThu = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_maDoanhThu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_tongTienLoaiDoanhThu = new System.Windows.Forms.Label();
            this.txt_ttDoanhThu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsLoaiDoanhThu)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsDoanhThu)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.label6.Size = new System.Drawing.Size(1668, 53);
            this.label6.TabIndex = 16;
            this.label6.Text = "Quản lý doanh thu";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_dsLoaiDoanhThu
            // 
            this.dgv_dsLoaiDoanhThu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_dsLoaiDoanhThu.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv_dsLoaiDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dsLoaiDoanhThu.Location = new System.Drawing.Point(7, 63);
            this.dgv_dsLoaiDoanhThu.Name = "dgv_dsLoaiDoanhThu";
            this.dgv_dsLoaiDoanhThu.Size = new System.Drawing.Size(793, 447);
            this.dgv_dsLoaiDoanhThu.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txt_ttDoanhThu);
            this.groupBox3.Controls.Add(this.dgv_dsDoanhThu);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(824, 314);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(832, 517);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách doanh thu";
            // 
            // dgv_dsDoanhThu
            // 
            this.dgv_dsDoanhThu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_dsDoanhThu.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv_dsDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dsDoanhThu.Location = new System.Drawing.Point(7, 63);
            this.dgv_dsDoanhThu.Name = "dgv_dsDoanhThu";
            this.dgv_dsDoanhThu.Size = new System.Drawing.Size(819, 448);
            this.dgv_dsDoanhThu.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_khoiPhuc);
            this.groupBox2.Controls.Add(this.btn_clear);
            this.groupBox2.Controls.Add(this.themXoaSuaDoanhThu);
            this.groupBox2.Controls.Add(this.txt_maLoaiDoanhThu);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_moTaLoaiDoanhThu);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txt_tongTienDoanhThu);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txt_tenLoaiDoanhThu);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cbo_sanPham);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(5, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(806, 242);
            this.groupBox2.TabIndex = 19;
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
            // themXoaSuaDoanhThu
            // 
            this.themXoaSuaDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.themXoaSuaDoanhThu.Location = new System.Drawing.Point(186, 154);
            this.themXoaSuaDoanhThu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.themXoaSuaDoanhThu.Name = "themXoaSuaDoanhThu";
            this.themXoaSuaDoanhThu.Size = new System.Drawing.Size(479, 80);
            this.themXoaSuaDoanhThu.TabIndex = 26;
            // 
            // txt_maLoaiDoanhThu
            // 
            this.txt_maLoaiDoanhThu.BackColor = System.Drawing.Color.White;
            this.txt_maLoaiDoanhThu.Enabled = false;
            this.txt_maLoaiDoanhThu.Location = new System.Drawing.Point(175, 24);
            this.txt_maLoaiDoanhThu.Name = "txt_maLoaiDoanhThu";
            this.txt_maLoaiDoanhThu.Size = new System.Drawing.Size(227, 26);
            this.txt_maLoaiDoanhThu.TabIndex = 17;
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
            // txt_moTaLoaiDoanhThu
            // 
            this.txt_moTaLoaiDoanhThu.BackColor = System.Drawing.Color.White;
            this.txt_moTaLoaiDoanhThu.Location = new System.Drawing.Point(175, 66);
            this.txt_moTaLoaiDoanhThu.Multiline = true;
            this.txt_moTaLoaiDoanhThu.Name = "txt_moTaLoaiDoanhThu";
            this.txt_moTaLoaiDoanhThu.Size = new System.Drawing.Size(227, 48);
            this.txt_moTaLoaiDoanhThu.TabIndex = 23;
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
            // txt_tongTienDoanhThu
            // 
            this.txt_tongTienDoanhThu.BackColor = System.Drawing.Color.White;
            this.txt_tongTienDoanhThu.Location = new System.Drawing.Point(175, 120);
            this.txt_tongTienDoanhThu.Name = "txt_tongTienDoanhThu";
            this.txt_tongTienDoanhThu.Size = new System.Drawing.Size(227, 26);
            this.txt_tongTienDoanhThu.TabIndex = 21;
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
            // txt_tenLoaiDoanhThu
            // 
            this.txt_tenLoaiDoanhThu.BackColor = System.Drawing.Color.White;
            this.txt_tenLoaiDoanhThu.Location = new System.Drawing.Point(540, 24);
            this.txt_tenLoaiDoanhThu.Name = "txt_tenLoaiDoanhThu";
            this.txt_tenLoaiDoanhThu.Size = new System.Drawing.Size(253, 26);
            this.txt_tenLoaiDoanhThu.TabIndex = 19;
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
            this.label4.Size = new System.Drawing.Size(152, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Mã loại doanh thu";
            // 
            // cbo_sanPham
            // 
            this.cbo_sanPham.FormattingEnabled = true;
            this.cbo_sanPham.Location = new System.Drawing.Point(540, 66);
            this.cbo_sanPham.Name = "cbo_sanPham";
            this.cbo_sanPham.Size = new System.Drawing.Size(253, 28);
            this.cbo_sanPham.TabIndex = 10;
            // 
            // themXoaSuaDT
            // 
            this.themXoaSuaDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.themXoaSuaDT.Location = new System.Drawing.Point(124, 165);
            this.themXoaSuaDT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.themXoaSuaDT.Name = "themXoaSuaDT";
            this.themXoaSuaDT.Size = new System.Drawing.Size(412, 76);
            this.themXoaSuaDT.TabIndex = 27;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.themXoaSuaDT);
            this.groupBox4.Controls.Add(this.cbo_loaiDoanhThu);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.dtp_thoiGianDoanhThu);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.txt_soTienDoanhThu);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txt_moTaDoanhThu);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.txt_maDoanhThu);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(824, 66);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(826, 243);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thông tin  doanh thu";
            // 
            // cbo_loaiDoanhThu
            // 
            this.cbo_loaiDoanhThu.FormattingEnabled = true;
            this.cbo_loaiDoanhThu.Location = new System.Drawing.Point(184, 132);
            this.cbo_loaiDoanhThu.Name = "cbo_loaiDoanhThu";
            this.cbo_loaiDoanhThu.Size = new System.Drawing.Size(234, 28);
            this.cbo_loaiDoanhThu.TabIndex = 27;
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
            // dtp_thoiGianDoanhThu
            // 
            this.dtp_thoiGianDoanhThu.Location = new System.Drawing.Point(433, 59);
            this.dtp_thoiGianDoanhThu.Name = "dtp_thoiGianDoanhThu";
            this.dtp_thoiGianDoanhThu.Size = new System.Drawing.Size(241, 26);
            this.dtp_thoiGianDoanhThu.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label9.Location = new System.Drawing.Point(33, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "Mã loại doanh thu";
            // 
            // txt_soTienDoanhThu
            // 
            this.txt_soTienDoanhThu.BackColor = System.Drawing.Color.White;
            this.txt_soTienDoanhThu.Location = new System.Drawing.Point(184, 96);
            this.txt_soTienDoanhThu.Name = "txt_soTienDoanhThu";
            this.txt_soTienDoanhThu.Size = new System.Drawing.Size(234, 26);
            this.txt_soTienDoanhThu.TabIndex = 15;
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
            // txt_moTaDoanhThu
            // 
            this.txt_moTaDoanhThu.BackColor = System.Drawing.Color.White;
            this.txt_moTaDoanhThu.Location = new System.Drawing.Point(184, 59);
            this.txt_moTaDoanhThu.Name = "txt_moTaDoanhThu";
            this.txt_moTaDoanhThu.Size = new System.Drawing.Size(234, 26);
            this.txt_moTaDoanhThu.TabIndex = 13;
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
            // txt_maDoanhThu
            // 
            this.txt_maDoanhThu.BackColor = System.Drawing.Color.White;
            this.txt_maDoanhThu.Enabled = false;
            this.txt_maDoanhThu.Location = new System.Drawing.Point(184, 25);
            this.txt_maDoanhThu.Name = "txt_maDoanhThu";
            this.txt_maDoanhThu.Size = new System.Drawing.Size(234, 26);
            this.txt_maDoanhThu.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label1.Location = new System.Drawing.Point(33, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Mã doanh thu";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.txt_tongTienLoaiDoanhThu);
            this.groupBox1.Controls.Add(this.dgv_dsLoaiDoanhThu);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 314);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(806, 516);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách loại doanh thu";
            // 
            // txt_tongTienLoaiDoanhThu
            // 
            this.txt_tongTienLoaiDoanhThu.AutoSize = true;
            this.txt_tongTienLoaiDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tongTienLoaiDoanhThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.txt_tongTienLoaiDoanhThu.Location = new System.Drawing.Point(7, 31);
            this.txt_tongTienLoaiDoanhThu.Name = "txt_tongTienLoaiDoanhThu";
            this.txt_tongTienLoaiDoanhThu.Size = new System.Drawing.Size(84, 20);
            this.txt_tongTienLoaiDoanhThu.TabIndex = 28;
            this.txt_tongTienLoaiDoanhThu.Text = "Tổng tiền";
            // 
            // txt_ttDoanhThu
            // 
            this.txt_ttDoanhThu.AutoSize = true;
            this.txt_ttDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ttDoanhThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.txt_ttDoanhThu.Location = new System.Drawing.Point(6, 31);
            this.txt_ttDoanhThu.Name = "txt_ttDoanhThu";
            this.txt_ttDoanhThu.Size = new System.Drawing.Size(84, 20);
            this.txt_ttDoanhThu.TabIndex = 29;
            this.txt_ttDoanhThu.Text = "Tổng tiền";
            // 
            // frm_quanLyDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1668, 856);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_quanLyDoanhThu";
            this.Text = "frm_quanLyDoanhThu";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsLoaiDoanhThu)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsDoanhThu)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgv_dsLoaiDoanhThu;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_dsDoanhThu;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_khoiPhuc;
        private System.Windows.Forms.Button btn_clear;
        private UC.ThemXoaSua themXoaSuaDoanhThu;
        private System.Windows.Forms.TextBox txt_maLoaiDoanhThu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_moTaLoaiDoanhThu;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_tongTienDoanhThu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_tenLoaiDoanhThu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbo_sanPham;
        private UC.ThemXoaSua themXoaSuaDT;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbo_loaiDoanhThu;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtp_thoiGianDoanhThu;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_soTienDoanhThu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_moTaDoanhThu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_maDoanhThu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label txt_ttDoanhThu;
        private System.Windows.Forms.Label txt_tongTienLoaiDoanhThu;
    }
}