namespace GUI
{
    partial class frm_LoaiTieuChi
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
            this.themXoaSuaTieuChi = new UC.ThemXoaSua();
            this.dgv_dsTieuChi = new System.Windows.Forms.DataGridView();
            this.txtMaTieuChi = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTenTieuChi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsTieuChi)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // themXoaSuaTieuChi
            // 
            this.themXoaSuaTieuChi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.themXoaSuaTieuChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.themXoaSuaTieuChi.Location = new System.Drawing.Point(19, 121);
            this.themXoaSuaTieuChi.Margin = new System.Windows.Forms.Padding(6);
            this.themXoaSuaTieuChi.Name = "themXoaSuaTieuChi";
            this.themXoaSuaTieuChi.Size = new System.Drawing.Size(414, 69);
            this.themXoaSuaTieuChi.TabIndex = 2;
            // 
            // dgv_dsTieuChi
            // 
            this.dgv_dsTieuChi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_dsTieuChi.BackgroundColor = System.Drawing.Color.White;
            this.dgv_dsTieuChi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dsTieuChi.Location = new System.Drawing.Point(4, 224);
            this.dgv_dsTieuChi.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgv_dsTieuChi.Name = "dgv_dsTieuChi";
            this.dgv_dsTieuChi.Size = new System.Drawing.Size(769, 605);
            this.dgv_dsTieuChi.TabIndex = 1;
            // 
            // txtMaTieuChi
            // 
            this.txtMaTieuChi.Enabled = false;
            this.txtMaTieuChi.Location = new System.Drawing.Point(196, 22);
            this.txtMaTieuChi.Name = "txtMaTieuChi";
            this.txtMaTieuChi.Size = new System.Drawing.Size(302, 26);
            this.txtMaTieuChi.TabIndex = 20;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label13.Location = new System.Drawing.Point(15, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 20);
            this.label13.TabIndex = 19;
            this.label13.Text = "Mã tiêu chí";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(19)))), ((int)(((byte)(176)))));
            this.label12.Location = new System.Drawing.Point(15, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 20);
            this.label12.TabIndex = 21;
            this.label12.Text = "Tên tiêu chí";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.themXoaSuaTieuChi);
            this.groupBox3.Controls.Add(this.dgv_dsTieuChi);
            this.groupBox3.Controls.Add(this.txtMaTieuChi);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtTenTieuChi);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(5, 76);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Size = new System.Drawing.Size(777, 832);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Loại tiêu chí";
            // 
            // txtTenTieuChi
            // 
            this.txtTenTieuChi.Location = new System.Drawing.Point(196, 65);
            this.txtTenTieuChi.Name = "txtTenTieuChi";
            this.txtTenTieuChi.Size = new System.Drawing.Size(302, 26);
            this.txtTenTieuChi.TabIndex = 22;
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
            this.label1.TabIndex = 9;
            this.label1.Text = "Quản lý loại tiêu chí";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frm_LoaiTieuChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1574, 920);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label1);
            this.Name = "frm_LoaiTieuChi";
            this.Text = "frm_LoaiTieuChi";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsTieuChi)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UC.ThemXoaSua themXoaSuaTieuChi;
        private System.Windows.Forms.DataGridView dgv_dsTieuChi;
        private System.Windows.Forms.TextBox txtMaTieuChi;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtTenTieuChi;
        private System.Windows.Forms.Label label1;
    }
}