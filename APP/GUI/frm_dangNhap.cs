﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace GUI
{
    public partial class frm_dangNhap : Form
    {
        public frm_dangNhap()
        {
            InitializeComponent();
            btn_dangnhap.Click += Btn_dangnhap_Click;
            btn_hienmatkhau.Click += Btn_hienmatkhau_Click;
            this.Load += Frm_dangNhap_Load;
        }

        private void Frm_dangNhap_Load(object sender, EventArgs e)
        {
            PlaceHolder.SetPlaceholder(txt_tentaikhoan, "Nhập tên tài khoản");
        }

        private void Btn_hienmatkhau_Click(object sender, EventArgs e)
        {
            // Hiện mật khẩu
            if (txt_matkhau.UseSystemPasswordChar)
            {
                txt_matkhau.UseSystemPasswordChar = false;
            }
            // Ẩn mật khẩu
            else
            {
                txt_matkhau.UseSystemPasswordChar = true;
            }
        }

        private void Btn_dangnhap_Click(object sender, EventArgs e)
        {
            // Tài khoản < 255 ký tự
            if (txt_tentaikhoan.Text.Length > 255)
            {
                MessageBox.Show("Tài khoản không được quá 255 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Mật khẩu < 255 ký tự
            if (txt_matkhau.Text.Length > 255)
            {
                MessageBox.Show("Mật khẩu không được quá 255 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Tài khoản không được để trống
            if (txt_tentaikhoan.Text == "")
            {
                MessageBox.Show("Tài khoản không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Mật khẩu không được để trống
            if (txt_matkhau.Text == "")
            {
                MessageBox.Show("Mật khẩu không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra đăng nhập
            BLL.NhanVienBLL nhanVienBLL = new BLL.NhanVienBLL();
            if (nhanVienBLL.KiemTraDangNhap(txt_tentaikhoan.Text, txt_matkhau.Text))
            {
                MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Visible = false;  // Ẩn form đăng nhập

                NhanVien nv = nhanVienBLL.LayNhanVien(txt_tentaikhoan.Text, txt_matkhau.Text);
                frm_main frm = new frm_main(this);  // Truyền tham chiếu của frm_dangNhap
                frm._nhanVien = nv;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
