namespace GUI
{
    partial class frm_themTieuChi_SanPhamTieuChi
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
            this.txtTrongSo = new System.Windows.Forms.TextBox();
            this.btnHoanTatThem = new System.Windows.Forms.Button();
            this.cbbTieuChi = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTrongSo
            // 
            this.txtTrongSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrongSo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.txtTrongSo.Location = new System.Drawing.Point(240, 61);
            this.txtTrongSo.Name = "txtTrongSo";
            this.txtTrongSo.Size = new System.Drawing.Size(248, 26);
            this.txtTrongSo.TabIndex = 9;
            // 
            // btnHoanTatThem
            // 
            this.btnHoanTatThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.btnHoanTatThem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnHoanTatThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoanTatThem.ForeColor = System.Drawing.Color.White;
            this.btnHoanTatThem.Location = new System.Drawing.Point(0, 103);
            this.btnHoanTatThem.Name = "btnHoanTatThem";
            this.btnHoanTatThem.Size = new System.Drawing.Size(578, 57);
            this.btnHoanTatThem.TabIndex = 8;
            this.btnHoanTatThem.Text = "Hoàn tất thêm";
            this.btnHoanTatThem.UseVisualStyleBackColor = false;
            // 
            // cbbTieuChi
            // 
            this.cbbTieuChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTieuChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.cbbTieuChi.FormattingEnabled = true;
            this.cbbTieuChi.Location = new System.Drawing.Point(159, 12);
            this.cbbTieuChi.Name = "cbbTieuChi";
            this.cbbTieuChi.Size = new System.Drawing.Size(329, 28);
            this.cbbTieuChi.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label2.Location = new System.Drawing.Point(37, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Trọng số";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label1.Location = new System.Drawing.Point(37, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "TieuChi";
            // 
            // frm_themTieuChi_SanPhamTieuChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 160);
            this.Controls.Add(this.txtTrongSo);
            this.Controls.Add(this.btnHoanTatThem);
            this.Controls.Add(this.cbbTieuChi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frm_themTieuChi_SanPhamTieuChi";
            this.Text = "frm_themTieuChi_SanPhamTieuChi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTrongSo;
        private System.Windows.Forms.Button btnHoanTatThem;
        private System.Windows.Forms.ComboBox cbbTieuChi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}