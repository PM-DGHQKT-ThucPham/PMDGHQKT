namespace GUI
{
    partial class frm_themChiTietThanhPhanNguyenLieu
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
            this.label2 = new System.Windows.Forms.Label();
            this.cbbNguyenLieu = new System.Windows.Forms.ComboBox();
            this.btnHoanTatThem = new System.Windows.Forms.Button();
            this.txtPhanTramNguyenLieu = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label1.Location = new System.Drawing.Point(37, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nguyên liệu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label2.Location = new System.Drawing.Point(37, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Phần trăm nguyên liệu";
            // 
            // cbbNguyenLieu
            // 
            this.cbbNguyenLieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbNguyenLieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.cbbNguyenLieu.FormattingEnabled = true;
            this.cbbNguyenLieu.Location = new System.Drawing.Point(159, 24);
            this.cbbNguyenLieu.Name = "cbbNguyenLieu";
            this.cbbNguyenLieu.Size = new System.Drawing.Size(329, 28);
            this.cbbNguyenLieu.TabIndex = 1;
            // 
            // btnHoanTatThem
            // 
            this.btnHoanTatThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.btnHoanTatThem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnHoanTatThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoanTatThem.ForeColor = System.Drawing.Color.White;
            this.btnHoanTatThem.Location = new System.Drawing.Point(0, 131);
            this.btnHoanTatThem.Name = "btnHoanTatThem";
            this.btnHoanTatThem.Size = new System.Drawing.Size(516, 57);
            this.btnHoanTatThem.TabIndex = 3;
            this.btnHoanTatThem.Text = "Hoàn tất thêm";
            this.btnHoanTatThem.UseVisualStyleBackColor = false;
            // 
            // txtPhanTramNguyenLieu
            // 
            this.txtPhanTramNguyenLieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhanTramNguyenLieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.txtPhanTramNguyenLieu.Location = new System.Drawing.Point(240, 73);
            this.txtPhanTramNguyenLieu.Name = "txtPhanTramNguyenLieu";
            this.txtPhanTramNguyenLieu.Size = new System.Drawing.Size(248, 26);
            this.txtPhanTramNguyenLieu.TabIndex = 4;
            // 
            // frm_themChiTietThanhPhanNguyenLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 188);
            this.Controls.Add(this.txtPhanTramNguyenLieu);
            this.Controls.Add(this.btnHoanTatThem);
            this.Controls.Add(this.cbbNguyenLieu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frm_themChiTietThanhPhanNguyenLieu";
            this.Text = "frm_themChiTietThanhPhanNguyenLieu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbNguyenLieu;
        private System.Windows.Forms.Button btnHoanTatThem;
        private System.Windows.Forms.TextBox txtPhanTramNguyenLieu;
    }
}