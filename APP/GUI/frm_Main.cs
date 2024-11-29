using BLL;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_main : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private DichVuPhanQuyenBLL _phanQuyenBLL = new DichVuPhanQuyenBLL();
        public NhanVien _nhanVien { get; set; }
        private frm_dangNhap _frmDangNhap;
        public frm_main(frm_dangNhap frmDangNhap)
        {
            InitializeComponent();
            this.Load += Frm_main1_Load;
            _frmDangNhap = frmDangNhap;
        }

        private void Frm_main1_Load(object sender, EventArgs e)
        {
            pnMain.Height = this.ClientSize.Height;
            pnMain.Width = this.ClientSize.Width - pnLeft.Width;
            this.MaximizeBox = false;
            loadForm(new frm_formHome());
            label_tenNV.Caption = "Nhân viên: "+ _nhanVien.TenNhanVien.ToString();
            PhanQuyen();
        }

        void loadForm(Form form)
        {
            this.Text = form.Text;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Height = pnMain.Height;
            form.Width = pnMain.Width;
            pnMain.Controls.Add(form);
            pnMain.Tag = form;
            form.BringToFront();
            form.Show();

        }
        private void PhanQuyen()
        {
            List<string> danhSachQuyen = _phanQuyenBLL.LayDanhSachQuyen(_nhanVien.MaNhanVien);

            // Lặp qua tất cả các control trong form
            foreach (AccordionControlElement control in accordionControl1.Elements)
            {
                foreach (AccordionControlElement element in control.Elements)
                {
                    if (element.Tag != null)
                    {
                        List<string> requiredPermissions = element.Tag.ToString().Split(',').ToList();
                        if (requiredPermissions.Any(permission => danhSachQuyen.Contains(permission)))
                        {
                            element.Visible = true;
                            element.Enabled = true;
                        }
                        else
                        {
                            element.Visible = false;
                            element.Enabled = false;
                        }
                    }
                }
            }
        }

        // lập thống kê báo cáo
        private void btn_lapThongKeChiPhiSanXuat_Click(object sender, EventArgs e)
        {
            loadForm(new frm_lapThongKeChiPhiSanXuat());
        }

        private void btn_lapThongKeDoanhThu_Click(object sender, EventArgs e)
        {
            loadForm(new frm_lapThongKeDoanhThu());
        }

        private void btn_lapThongKeLoiNhuan_Click(object sender, EventArgs e)
        {
            loadForm(new frm_lapThongKeLoiNhuan());
        }

        private void btn_lapThongKeChiPhiLoiIch_Click(object sender, EventArgs e)
        {
        }

        private void btn_lapThongKeBaoCao_Click(object sender, EventArgs e)
        {
            loadForm(new frm_lapThongKeBaoCao());
        }
        /// <summary>
        /// phân tích đanh giá chỉ số hiệu quả 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_danhGiaTongThe_Click(object sender, EventArgs e)
        {
            loadForm(new frm_danhGiaTongThe());
        }

        private void btn_phanTichXuHuong_Click(object sender, EventArgs e)
        {
            loadForm(new frm_phanTichXuHuong());
        }
        /// <summary>
        /// quản lý kho hàng
        /// 
        private void btn_quanLyKhoHang_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyKhoHang());
        }

        /// <summary>
        /// quản lý nhân viên
        /// 
        private void btn_quanLyNhanVien_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyNhanVien());
        }

        private void btn_quanLyPhanQuyenNhanVien_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyPhanQuyenNhanVien());
        }

        /// <summary>
        /// Quản lý các chi phí 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_quanLyChiPhiNguyenLieu_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyChiPhiNguyenLieu());
        }

        private void btn_quanLyChiPhiNhanCong_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyChiPhiNhanCong());
        }

        private void btn_quanLyChiPhiThietKeBaoBi_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyChiPhiThietKeBaoBi());
        }
        /// <summary>
        /// quản lý các tiêu chi đánh giá sản phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_quanLyNguyenLieu_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyNguyenLieu());
        }

        private void btn_quanLyChatLuong_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyChatLuong());
        }

        private void btn_quanLyThietKe_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyThietKe());
        }

        private void btn_quanLyHieuSuat_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyHieuSuat());
        }

        private void btn_quanLyGiaCa_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyGiaCa());
        }

        private void btn_quanLyDichVuKhachHang_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyDichVuKhachHang());
        }

        private void btn_quanLyPhanHoiKhachHang_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyPhanHoiKhachHang());
        }

        private void btn_quanLyBenVung_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyBenVung());
        }

        private void btn_tinhNangBoSung_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyTinhNang());
        }

        private void btn_quanLyDoanhThu_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyDoanhThu());
        }

        private void btn_tinhToanLoiNhuan_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyLoiNhuan());
        }

        private void btn_quanLyThiTruong_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyThiTruong());
        }

        private void btn_quanLyChiPhi_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyChiPhi());
        }

        private void btn_quanLyNguyenLieuKhoHang_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyNguyenLieu());
        }
    }
}
    