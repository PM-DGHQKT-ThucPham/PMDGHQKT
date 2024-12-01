using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_danhGiaTongThe : Form
    {
        List<SanPham> lstSanPham = new List<SanPham>();
        SanPhamBLL sanPhamBLL = new SanPhamBLL();
        SanPham_TieuChiBLL SanPham_TieuChiBLL = new SanPham_TieuChiBLL();
        List<DiemSanPhamTheoTungTieuChi> diemSanPhamTheoTungTieuChis = new List<DiemSanPhamTheoTungTieuChi>();
        DiemSanPhamTheoTungTieuChiBLL diemTheoTieuChiBLL = new DiemSanPhamTheoTungTieuChiBLL();
        public frm_danhGiaTongThe()
        {
            InitializeComponent();
            this.Load += Frm_danhGiaTongThe_Load;
        }

        private void Frm_danhGiaTongThe_Load(object sender, EventArgs e)
        {
            //Load comboboxSanPham
            LoadComboboxSanPham();
        }

        private void LoadComboboxSanPham()
        {
            try
            {            //Load giá trị lên combobox

                SanPhamBLL sanPhamBLL = new SanPhamBLL();
                lstSanPham = sanPhamBLL.LayDanhSachSanPham();
                if (lstSanPham != null && lstSanPham.Count > 0)
                {
                    cbbSanPham.DataSource = lstSanPham;
                    cbbSanPham.ValueMember = "MaSanPham";
                    cbbSanPham.DisplayMember = "TenSanPham";
                    cbbSanPham.SelectedIndex = -1;
                    cbbSanPham.SelectedIndexChanged += CbbSanPham_SelectedIndexChanged;
                    cbbSanPham.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void CbbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataGridViewTieuChi();
            LoadDataGridViewDiemTieuChi();
            LoadDiemTong();
        }

        private void LoadDiemTong()
        {
            try
            {
                //Load lblDiemTong
                decimal diemTong = 0;
                foreach (DiemSanPhamTheoTungTieuChi item in diemSanPhamTheoTungTieuChis)
                {
                    diemTong = diemTong + (decimal)item.MucDoAnhHuong * (decimal)item.TrongSo;
                }
                lblDiemTong.Text = diemTong.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void LoadDataGridViewDiemTieuChi()
        {
            try
            {
                string maSanPham = cbbSanPham.SelectedValue.ToString();
                diemSanPhamTheoTungTieuChis = diemTheoTieuChiBLL.LayDanhSach(maSanPham);
                if (diemSanPhamTheoTungTieuChis != null && diemSanPhamTheoTungTieuChis.Count > 0)
                {
                    dgvDiemTheoTieuChi.DataSource = diemSanPhamTheoTungTieuChis;
                    dgvDiemTheoTieuChi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvDiemTheoTieuChi.Columns["TenTieuChi"].HeaderText = "Tên tiêu chí";
                    dgvDiemTheoTieuChi.Columns["MucDoAnhHuong"].HeaderText = "Điểm";
                    dgvDiemTheoTieuChi.Columns["TrongSo"].Visible = false;
                }
                else
                {
                    dgvDiemTheoTieuChi.DataSource = null;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            

        }

        private void LoadDataGridViewTieuChi()
        {
            try
            {
                //Load danh sách tiêu chí của sản phẩm lên datagridview gồm mã tiêu chí, tên tiêu chí, trọng số
                string maSanPham = cbbSanPham.SelectedValue.ToString();
                //List<TieuChi_SanPham> tieuChi_SanPhams = new List<TieuChi_SanPham>();
                var a = from ctsp in SanPham_TieuChiBLL.LayCTTC_CuaSanPham(maSanPham)
                        select new
                        {
                            TenTieuChi = ctsp.TieuChi.TenTieuChi,
                            TrongSo = ctsp.TrongSo,
                        };
                //tieuChi_SanPhams = SanPham_TieuChiBLL.LayCTTC_CuaSanPham(maSanPham);
                if (a != null && a.ToList().Count > 0)
                {
                    dgv_TieuChiSanPham.DataSource = a.ToList();
                    dgv_TieuChiSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgv_TieuChiSanPham.Columns["TenTieuChi"].HeaderText = "Tên tiêu chí";
                    dgv_TieuChiSanPham.Columns["TrongSo"].HeaderText = "Trọng số";
                }
                else
                {
                    dgv_TieuChiSanPham.DataSource = null;
                }
                //Load danh sách các tiêu chỉ và mức độ ảnh hưởng từ các bảng khác lên datagridview
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
