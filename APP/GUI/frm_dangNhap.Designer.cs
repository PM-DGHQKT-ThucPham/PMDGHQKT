namespace GUI
{
    partial class frm_dangNhap
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_hienmatkhau = new System.Windows.Forms.Button();
            this.btn_dangnhap = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_matkhau = new System.Windows.Forms.TextBox();
            this.txt_tentaikhoan = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(349, 450);
            this.panel1.TabIndex = 32;
            // 
            // button2
            // 
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Image = global::GUI.Properties.Resources.icons8_password_35;
            this.button2.Location = new System.Drawing.Point(444, 205);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 34);
            this.button2.TabIndex = 31;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btn_hienmatkhau
            // 
            this.btn_hienmatkhau.BackColor = System.Drawing.SystemColors.Control;
            this.btn_hienmatkhau.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_hienmatkhau.Image = global::GUI.Properties.Resources.icons8_eye_32;
            this.btn_hienmatkhau.Location = new System.Drawing.Point(711, 211);
            this.btn_hienmatkhau.Margin = new System.Windows.Forms.Padding(2);
            this.btn_hienmatkhau.Name = "btn_hienmatkhau";
            this.btn_hienmatkhau.Size = new System.Drawing.Size(48, 28);
            this.btn_hienmatkhau.TabIndex = 29;
            this.btn_hienmatkhau.UseVisualStyleBackColor = false;
            // 
            // btn_dangnhap
            // 
            this.btn_dangnhap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_dangnhap.Image = global::GUI.Properties.Resources.icons8_login_35;
            this.btn_dangnhap.Location = new System.Drawing.Point(562, 260);
            this.btn_dangnhap.Margin = new System.Windows.Forms.Padding(2);
            this.btn_dangnhap.Name = "btn_dangnhap";
            this.btn_dangnhap.Size = new System.Drawing.Size(68, 42);
            this.btn_dangnhap.TabIndex = 28;
            this.btn_dangnhap.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(508, 68);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 33);
            this.label3.TabIndex = 27;
            this.label3.Text = "ĐĂNG NHẬP";
            // 
            // txt_matkhau
            // 
            this.txt_matkhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_matkhau.Location = new System.Drawing.Point(500, 209);
            this.txt_matkhau.Margin = new System.Windows.Forms.Padding(2);
            this.txt_matkhau.Name = "txt_matkhau";
            this.txt_matkhau.Size = new System.Drawing.Size(207, 26);
            this.txt_matkhau.TabIndex = 26;
            this.txt_matkhau.UseSystemPasswordChar = true;
            // 
            // txt_tentaikhoan
            // 
            this.txt_tentaikhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tentaikhoan.Location = new System.Drawing.Point(500, 156);
            this.txt_tentaikhoan.Margin = new System.Windows.Forms.Padding(2);
            this.txt_tentaikhoan.Name = "txt_tentaikhoan";
            this.txt_tentaikhoan.Size = new System.Drawing.Size(207, 26);
            this.txt_tentaikhoan.TabIndex = 25;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Image = global::GUI.Properties.Resources.icons8_account_35;
            this.button1.Location = new System.Drawing.Point(444, 151);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 39);
            this.button1.TabIndex = 30;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // frm_dangNhap
            // 
            this.AcceptButton = this.btn_dangnhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_hienmatkhau);
            this.Controls.Add(this.btn_dangnhap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_matkhau);
            this.Controls.Add(this.txt_tentaikhoan);
            this.Name = "frm_dangNhap";
            this.Text = "frm_dangNhap";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_hienmatkhau;
        private System.Windows.Forms.Button btn_dangnhap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_matkhau;
        private System.Windows.Forms.TextBox txt_tentaikhoan;
    }
}