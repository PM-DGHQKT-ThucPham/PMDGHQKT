namespace GUI
{
    partial class frm_lapThongKeLoiNhuan
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart_loiNhuan = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbo_sanPham = new System.Windows.Forms.ComboBox();
            this.btn_timKiem = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgv_dsLoiNhuan = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_timKiem = new System.Windows.Forms.TextBox();
            this.cbo_chucNang = new System.Windows.Forms.ComboBox();
            this.dtp_ngayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.dtp_ngayBatDau = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txt_loiNhuanGop = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_loiNhuanRong = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_tyLeLoiNhuanGop = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_tyLeLoiNhuanRong = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chart_tile = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart_loiNhuan)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsLoiNhuan)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_tile)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_loiNhuan
            // 
            this.chart_loiNhuan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart_loiNhuan.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_loiNhuan.Legends.Add(legend1);
            this.chart_loiNhuan.Location = new System.Drawing.Point(6, 25);
            this.chart_loiNhuan.Name = "chart_loiNhuan";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart_loiNhuan.Series.Add(series1);
            this.chart_loiNhuan.Size = new System.Drawing.Size(554, 295);
            this.chart_loiNhuan.TabIndex = 0;
            this.chart_loiNhuan.Text = "chart1";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.chart_loiNhuan);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(940, 86);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(566, 343);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Biểu đồ lợi nhuận";
            // 
            // cbo_sanPham
            // 
            this.cbo_sanPham.FormattingEnabled = true;
            this.cbo_sanPham.Location = new System.Drawing.Point(602, 25);
            this.cbo_sanPham.Name = "cbo_sanPham";
            this.cbo_sanPham.Size = new System.Drawing.Size(309, 28);
            this.cbo_sanPham.TabIndex = 10;
            // 
            // btn_timKiem
            // 
            this.btn_timKiem.BackgroundImage = global::GUI.Properties.Resources.icons8_find_35;
            this.btn_timKiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_timKiem.Location = new System.Drawing.Point(602, 133);
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
            // dgv_dsLoiNhuan
            // 
            this.dgv_dsLoiNhuan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_dsLoiNhuan.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv_dsLoiNhuan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dsLoiNhuan.Location = new System.Drawing.Point(7, 26);
            this.dgv_dsLoiNhuan.Name = "dgv_dsLoiNhuan";
            this.dgv_dsLoiNhuan.Size = new System.Drawing.Size(905, 413);
            this.dgv_dsLoiNhuan.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.dgv_dsLoiNhuan);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 382);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(918, 445);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lợi nhuận từng tháng";
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
            this.txt_timKiem.Size = new System.Drawing.Size(338, 26);
            this.txt_timKiem.TabIndex = 3;
            // 
            // cbo_chucNang
            // 
            this.cbo_chucNang.FormattingEnabled = true;
            this.cbo_chucNang.Location = new System.Drawing.Point(227, 25);
            this.cbo_chucNang.Name = "cbo_chucNang";
            this.cbo_chucNang.Size = new System.Drawing.Size(338, 28);
            this.cbo_chucNang.TabIndex = 2;
            // 
            // dtp_ngayKetThuc
            // 
            this.dtp_ngayKetThuc.Location = new System.Drawing.Point(227, 103);
            this.dtp_ngayKetThuc.Name = "dtp_ngayKetThuc";
            this.dtp_ngayKetThuc.Size = new System.Drawing.Size(338, 26);
            this.dtp_ngayKetThuc.TabIndex = 1;
            // 
            // dtp_ngayBatDau
            // 
            this.dtp_ngayBatDau.Location = new System.Drawing.Point(227, 65);
            this.dtp_ngayBatDau.Name = "dtp_ngayBatDau";
            this.dtp_ngayBatDau.Size = new System.Drawing.Size(338, 26);
            this.dtp_ngayBatDau.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbo_sanPham);
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
            this.groupBox2.Location = new System.Drawing.Point(16, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(918, 193);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm thông tin doanh thu";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1518, 53);
            this.label6.TabIndex = 6;
            this.label6.Text = "Thống kê lợi nhuận";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txt_tyLeLoiNhuanRong);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.txt_tyLeLoiNhuanGop);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txt_loiNhuanRong);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.txt_loiNhuanGop);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(16, 286);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(918, 90);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Lợi nhuận";
            // 
            // txt_loiNhuanGop
            // 
            this.txt_loiNhuanGop.BackColor = System.Drawing.Color.White;
            this.txt_loiNhuanGop.Location = new System.Drawing.Point(174, 24);
            this.txt_loiNhuanGop.Name = "txt_loiNhuanGop";
            this.txt_loiNhuanGop.Size = new System.Drawing.Size(178, 26);
            this.txt_loiNhuanGop.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label1.Location = new System.Drawing.Point(5, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 35;
            this.label1.Text = "Lợi nhuận gộp";
            // 
            // txt_loiNhuanRong
            // 
            this.txt_loiNhuanRong.BackColor = System.Drawing.Color.White;
            this.txt_loiNhuanRong.Location = new System.Drawing.Point(548, 22);
            this.txt_loiNhuanRong.Name = "txt_loiNhuanRong";
            this.txt_loiNhuanRong.Size = new System.Drawing.Size(228, 26);
            this.txt_loiNhuanRong.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label7.Location = new System.Drawing.Point(381, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 20);
            this.label7.TabIndex = 40;
            this.label7.Text = "Lợi nhuận ròng";
            // 
            // txt_tyLeLoiNhuanGop
            // 
            this.txt_tyLeLoiNhuanGop.BackColor = System.Drawing.Color.White;
            this.txt_tyLeLoiNhuanGop.Location = new System.Drawing.Point(174, 55);
            this.txt_tyLeLoiNhuanGop.Name = "txt_tyLeLoiNhuanGop";
            this.txt_tyLeLoiNhuanGop.Size = new System.Drawing.Size(178, 26);
            this.txt_tyLeLoiNhuanGop.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label8.Location = new System.Drawing.Point(2, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 20);
            this.label8.TabIndex = 42;
            this.label8.Text = "Tỉ lệ lợi nhuận gộp";
            // 
            // txt_tyLeLoiNhuanRong
            // 
            this.txt_tyLeLoiNhuanRong.BackColor = System.Drawing.Color.White;
            this.txt_tyLeLoiNhuanRong.Location = new System.Drawing.Point(548, 55);
            this.txt_tyLeLoiNhuanRong.Name = "txt_tyLeLoiNhuanRong";
            this.txt_tyLeLoiNhuanRong.Size = new System.Drawing.Size(228, 26);
            this.txt_tyLeLoiNhuanRong.TabIndex = 43;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label9.Location = new System.Drawing.Point(381, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(161, 20);
            this.label9.TabIndex = 44;
            this.label9.Text = "Tỉ lệ lợi nhuận ròng";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.chart_tile);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(940, 435);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(566, 392);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tỉ lệ lợi nhuận";
            // 
            // chart_tile
            // 
            this.chart_tile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chart_tile.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart_tile.Legends.Add(legend2);
            this.chart_tile.Location = new System.Drawing.Point(6, 25);
            this.chart_tile.Name = "chart_tile";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart_tile.Series.Add(series2);
            this.chart_tile.Size = new System.Drawing.Size(554, 344);
            this.chart_tile.TabIndex = 0;
            this.chart_tile.Text = "chart1";
            // 
            // frm_lapThongKeLoiNhuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1518, 833);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label6);
            this.Name = "frm_lapThongKeLoiNhuan";
            this.Text = "frm_lapThongKeLoiNhuan";
            ((System.ComponentModel.ISupportInitialize)(this.chart_loiNhuan)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsLoiNhuan)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_tile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_loiNhuan;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbo_sanPham;
        private System.Windows.Forms.Button btn_timKiem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgv_dsLoiNhuan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_timKiem;
        private System.Windows.Forms.ComboBox cbo_chucNang;
        private System.Windows.Forms.DateTimePicker dtp_ngayKetThuc;
        private System.Windows.Forms.DateTimePicker dtp_ngayBatDau;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txt_loiNhuanGop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_loiNhuanRong;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_tyLeLoiNhuanGop;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_tyLeLoiNhuanRong;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_tile;
    }
}