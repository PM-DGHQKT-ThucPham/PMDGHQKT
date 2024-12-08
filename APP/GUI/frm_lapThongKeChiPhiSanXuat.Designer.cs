namespace GUI
{
    partial class frm_lapThongKeChiPhiSanXuat
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chart_chiPhi = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbo_sanPham = new System.Windows.Forms.ComboBox();
            this.cbo_loaiChiPhi = new System.Windows.Forms.ComboBox();
            this.btn_timKiem = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_timKiem = new System.Windows.Forms.TextBox();
            this.cbo_chucNang = new System.Windows.Forms.ComboBox();
            this.dtp_ngayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.dtp_ngayBatDau = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_dsChiPhi = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chart_codinh = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chart_giantiep = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupbox = new System.Windows.Forms.GroupBox();
            this.chart_biendoi = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txt_tongTien = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_chiPhi)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsChiPhi)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_codinh)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_giantiep)).BeginInit();
            this.groupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_biendoi)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1635, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thống kê chi phí sản xuất";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.chart_chiPhi);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(746, 78);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(854, 401);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Biểu đồ chi phí";
            // 
            // chart_chiPhi
            // 
            this.chart_chiPhi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea5.Name = "ChartArea1";
            this.chart_chiPhi.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chart_chiPhi.Legends.Add(legend5);
            this.chart_chiPhi.Location = new System.Drawing.Point(8, 42);
            this.chart_chiPhi.Name = "chart_chiPhi";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chart_chiPhi.Series.Add(series5);
            this.chart_chiPhi.Size = new System.Drawing.Size(820, 353);
            this.chart_chiPhi.TabIndex = 0;
            this.chart_chiPhi.Text = "chart1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbo_sanPham);
            this.groupBox2.Controls.Add(this.cbo_loaiChiPhi);
            this.groupBox2.Controls.Add(this.btn_timKiem);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txt_timKiem);
            this.groupBox2.Controls.Add(this.cbo_chucNang);
            this.groupBox2.Controls.Add(this.dtp_ngayKetThuc);
            this.groupBox2.Controls.Add(this.dtp_ngayBatDau);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(5, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(724, 193);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm thông tin doanh thu";
            // 
            // cbo_sanPham
            // 
            this.cbo_sanPham.FormattingEnabled = true;
            this.cbo_sanPham.Location = new System.Drawing.Point(512, 25);
            this.cbo_sanPham.Name = "cbo_sanPham";
            this.cbo_sanPham.Size = new System.Drawing.Size(198, 28);
            this.cbo_sanPham.TabIndex = 10;
            // 
            // cbo_loaiChiPhi
            // 
            this.cbo_loaiChiPhi.FormattingEnabled = true;
            this.cbo_loaiChiPhi.Location = new System.Drawing.Point(512, 63);
            this.cbo_loaiChiPhi.Name = "cbo_loaiChiPhi";
            this.cbo_loaiChiPhi.Size = new System.Drawing.Size(198, 28);
            this.cbo_loaiChiPhi.TabIndex = 9;
            // 
            // btn_timKiem
            // 
            this.btn_timKiem.BackgroundImage = global::GUI.Properties.Resources.icons8_find_35;
            this.btn_timKiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_timKiem.Location = new System.Drawing.Point(512, 133);
            this.btn_timKiem.Name = "btn_timKiem";
            this.btn_timKiem.Size = new System.Drawing.Size(59, 39);
            this.btn_timKiem.TabIndex = 8;
            this.btn_timKiem.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label5.Location = new System.Drawing.Point(11, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(198, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Nhập thông tin tìm kiếm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label4.Location = new System.Drawing.Point(11, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ngày kết thúc";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label3.Location = new System.Drawing.Point(11, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ngày bắt đầu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label2.Location = new System.Drawing.Point(11, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Chọn chức năng tìm kiếm";
            // 
            // txt_timKiem
            // 
            this.txt_timKiem.Location = new System.Drawing.Point(227, 141);
            this.txt_timKiem.Name = "txt_timKiem";
            this.txt_timKiem.Size = new System.Drawing.Size(267, 26);
            this.txt_timKiem.TabIndex = 3;
            // 
            // cbo_chucNang
            // 
            this.cbo_chucNang.FormattingEnabled = true;
            this.cbo_chucNang.Location = new System.Drawing.Point(227, 25);
            this.cbo_chucNang.Name = "cbo_chucNang";
            this.cbo_chucNang.Size = new System.Drawing.Size(267, 28);
            this.cbo_chucNang.TabIndex = 2;
            // 
            // dtp_ngayKetThuc
            // 
            this.dtp_ngayKetThuc.Location = new System.Drawing.Point(227, 103);
            this.dtp_ngayKetThuc.Name = "dtp_ngayKetThuc";
            this.dtp_ngayKetThuc.Size = new System.Drawing.Size(267, 26);
            this.dtp_ngayKetThuc.TabIndex = 1;
            // 
            // dtp_ngayBatDau
            // 
            this.dtp_ngayBatDau.Location = new System.Drawing.Point(227, 65);
            this.dtp_ngayBatDau.Name = "dtp_ngayBatDau";
            this.dtp_ngayBatDau.Size = new System.Drawing.Size(267, 26);
            this.dtp_ngayBatDau.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.dgv_dsChiPhi);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 303);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(724, 486);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi phí sản xuất từng tháng";
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
            this.dgv_dsChiPhi.Size = new System.Drawing.Size(711, 435);
            this.dgv_dsChiPhi.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBox4.Controls.Add(this.chart_codinh);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(746, 485);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(274, 310);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Chi phí cố định";
            // 
            // chart_codinh
            // 
            this.chart_codinh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea6.Name = "ChartArea1";
            this.chart_codinh.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chart_codinh.Legends.Add(legend6);
            this.chart_codinh.Location = new System.Drawing.Point(7, 20);
            this.chart_codinh.Name = "chart_codinh";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chart_codinh.Series.Add(series6);
            this.chart_codinh.Size = new System.Drawing.Size(261, 284);
            this.chart_codinh.TabIndex = 0;
            this.chart_codinh.Text = "chart1";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBox5.Controls.Add(this.chart_giantiep);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(1024, 485);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(285, 310);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Chi phí gián tiếp";
            // 
            // chart_giantiep
            // 
            this.chart_giantiep.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea7.Name = "ChartArea1";
            this.chart_giantiep.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.chart_giantiep.Legends.Add(legend7);
            this.chart_giantiep.Location = new System.Drawing.Point(6, 19);
            this.chart_giantiep.Name = "chart_giantiep";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.chart_giantiep.Series.Add(series7);
            this.chart_giantiep.Size = new System.Drawing.Size(260, 285);
            this.chart_giantiep.TabIndex = 1;
            this.chart_giantiep.Text = "chart2";
            // 
            // groupbox
            // 
            this.groupbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupbox.Controls.Add(this.chart_biendoi);
            this.groupbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupbox.Location = new System.Drawing.Point(1315, 485);
            this.groupbox.Name = "groupbox";
            this.groupbox.Size = new System.Drawing.Size(285, 310);
            this.groupbox.TabIndex = 11;
            this.groupbox.TabStop = false;
            this.groupbox.Text = "Chi phí biển đổi";
            // 
            // chart_biendoi
            // 
            this.chart_biendoi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea8.Name = "ChartArea1";
            this.chart_biendoi.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.chart_biendoi.Legends.Add(legend8);
            this.chart_biendoi.Location = new System.Drawing.Point(7, 20);
            this.chart_biendoi.Name = "chart_biendoi";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.chart_biendoi.Series.Add(series8);
            this.chart_biendoi.Size = new System.Drawing.Size(260, 284);
            this.chart_biendoi.TabIndex = 2;
            this.chart_biendoi.Text = "chart3";
            // 
            // txt_tongTien
            // 
            this.txt_tongTien.AutoSize = true;
            this.txt_tongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.txt_tongTien.Location = new System.Drawing.Point(464, 280);
            this.txt_tongTien.Name = "txt_tongTien";
            this.txt_tongTien.Size = new System.Drawing.Size(84, 20);
            this.txt_tongTien.TabIndex = 11;
            this.txt_tongTien.Text = "Tổng tiền";
            // 
            // frm_lapThongKeChiPhiSanXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1635, 807);
            this.Controls.Add(this.txt_tongTien);
            this.Controls.Add(this.groupbox);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frm_lapThongKeChiPhiSanXuat";
            this.Text = "frm_lapThongKeChiPhiSanXuat";
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_chiPhi)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsChiPhi)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_codinh)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_giantiep)).EndInit();
            this.groupbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_biendoi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_chiPhi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbo_sanPham;
        private System.Windows.Forms.ComboBox cbo_loaiChiPhi;
        private System.Windows.Forms.Button btn_timKiem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_timKiem;
        private System.Windows.Forms.ComboBox cbo_chucNang;
        private System.Windows.Forms.DateTimePicker dtp_ngayKetThuc;
        private System.Windows.Forms.DateTimePicker dtp_ngayBatDau;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_dsChiPhi;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_codinh;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_giantiep;
        private System.Windows.Forms.GroupBox groupbox;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_biendoi;
        private System.Windows.Forms.Label txt_tongTien;
    }
}