using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace GUI
{
    public partial class frm_thietLapTaiKhoan : Form
    {
        NhanVienBLL _nhanVienBLL = new NhanVienBLL();
        public event EventHandler CapNhat;
        public NhanVien _nhanVien { get; set; }
        public frm_thietLapTaiKhoan()
        {
            InitializeComponent();
            this.Load += Frm_thietLapTaiKhoan_Load;
            //hiển thị ở giữa màn hình
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Frm_thietLapTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadData();
            this.btn_CapNhat.Click += btnCapNhat_Click;
            this.btnDong.Click += btnDong_Click;
        }
        //đóng form
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //cập nhật tài khoản
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string soDienThoai = txtSoDienThoai.Text;
            if (soDienThoai.Length != 10 || !soDienThoai.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại phải có 10 chữ số");
                return;
            }

            string hoVaTen = txtHoVaTen.Text;
            DateTime ngaySinh = dtpNgaySinh.Value;
            string gioiTinh = rbtnNam.Checked ? "Nam" : "Nữ";
            string diaChi = txtDiaChi.Text;
            string chucVu = txtChucVu.Text;

            if (string.IsNullOrEmpty(chucVu))
            {
                MessageBox.Show("Chức vụ không được để trống");
                return;
            }

            string email = txtEmail.Text;
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Email không được để trống");
                return;
            }
            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Email không hợp lệ");
                return;
            }

            string taiKhoan = txtTaiKhoan.Text;
            if (string.IsNullOrEmpty(taiKhoan))
            {
                MessageBox.Show("Tài khoản không được để trống");
                return;
            }

            string matKhau = txtMatKhau.Text;
            if (string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Mật khẩu không được để trống");
                return;
            }

            string matKhauMoi = txtMatKhauMoi.Text;
            if (!string.IsNullOrEmpty(matKhauMoi))
            {
                if (matKhauMoi.Length < 6)
                {
                    MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự");
                    return;
                }
                if (matKhauMoi != txtNhapLaiMatKhau.Text)
                {
                    MessageBox.Show("Mật khẩu mới không khớp");
                    return;
                }
            }

            // Kiểm tra mật khẩu cũ nếu có thông tin
            if (!string.IsNullOrEmpty(matKhau))
            {
                // Kiểm tra mật khẩu hiện tại có đúng không
                if (!_nhanVienBLL.KiemTraDangNhap(_nhanVien.TaiKhoan, matKhau))
                {
                    MessageBox.Show("Mật khẩu không đúng");
                    return;
                }
            }

            // Hiển thị dialog xác nhận trước khi thay đổi thông tin
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thay đổi thông tin nhân viên này?",
                                                        "Xác nhận thay đổi",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                // Cập nhật thông tin nhân viên
                NhanVien nv = new NhanVien
                {
                    MaNhanVien = _nhanVien.MaNhanVien,
                    TenNhanVien = hoVaTen,
                    NgaySinh = ngaySinh,
                    GioiTinh = gioiTinh,
                    DiaChi = diaChi,
                    ChucVu = chucVu,
                    Email = email,
                    TaiKhoan = taiKhoan,
                    SoDienThoai = soDienThoai
                };

                // Nếu có mật khẩu mới, thì gán vào
                if (!string.IsNullOrEmpty(matKhauMoi))
                {
                    //xác nhận mật khẩu mới
                    if (matKhauMoi == txt.Text)
                    {
                        nv.MatKhau = matKhauMoi;  // Đổi mật khẩu
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu mới không khớp");
                        return;
                    }
                }
                else
                {
                    nv.MatKhau = matKhau;  // Nếu không đổi mật khẩu thì giữ nguyên mật khẩu cũ
                }

                // Cập nhật vào cơ sở dữ liệu
                if (_nhanVienBLL.CapNhatNhanVien(nv))
                {
                    MessageBox.Show("Cập nhật thành công");
                    CapNhat?.Invoke(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại");
                }
            }
            else
            {
                MessageBox.Show("Cập nhật bị hủy bỏ");
            }
        }

        private void LoadData()
        {
            if (_nhanVien == null)
            {
                MessageBox.Show("Employee data is not available.");
                return;
            }
            txtHoVaTen.Text = _nhanVien.TenNhanVien;
            dtpNgaySinh.Value = _nhanVien.NgaySinh.Value;
            if (_nhanVien.GioiTinh == "Nam")
            {
                rbtnNam.Checked = true;
            }
            else
            {
                rbtnNu.Checked = true;
            }
            txtDiaChi.Text = _nhanVien.DiaChi;
            txtChucVu.Text = _nhanVien.ChucVu;
            txtEmail.Text = _nhanVien.Email;
            txtTaiKhoan.Text = _nhanVien.TaiKhoan;
            txtSoDienThoai.Text = _nhanVien.SoDienThoai;
        }
    }
}
