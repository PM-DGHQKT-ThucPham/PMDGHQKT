using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
namespace GUI
{
    public partial class frm_quanLyPhanHoiKhachHang : Form
    {
        List<PhanHoiNguoiDung> lstPhanHoiNguoiDung = new List<PhanHoiNguoiDung>();
        PhanHoiNguoiDungBLL phndBll = new PhanHoiNguoiDungBLL();
        public frm_quanLyPhanHoiKhachHang()
        {
            InitializeComponent();
            this.Load += Frm_quanLyPhanHoiKhachHang_Load;
            this.btnLoc.Click += BtnLoc_Click;
            this.btnLocXepHang.Click += BtnLocXepHang_Click;
        }

        private void BtnLocXepHang_Click(object sender, EventArgs e)
        {
            try
            {
                //Load data grid view theo điểm xếp hạng được chọn từ combobox xếp hạng
                string masanpham = cbbSanPham.SelectedValue.ToString();
                int diem = int.Parse(cbbXepHang.SelectedValue.ToString());
                lstPhanHoiNguoiDung = phndBll.LayDanhSachPhanHoiNguoiDungTheoDiem(masanpham, diem);
                if (lstPhanHoiNguoiDung != null && lstPhanHoiNguoiDung.Count > 0)
                {
                    dgv_DsPhanHoiKhachHang.DataSource = lstPhanHoiNguoiDung;
                    dgv_DsPhanHoiKhachHang.Columns[0].Visible = false;
                    dgv_DsPhanHoiKhachHang.Columns[1].Visible = false;
                    dgv_DsPhanHoiKhachHang.Columns[5].Visible = false;
                    dgv_DsPhanHoiKhachHang.BackgroundColor = Color.White;
                    dgv_DsPhanHoiKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgv_DsPhanHoiKhachHang.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    //Hiển thị số lượng phản hồi theo điểm xếp hạng lên lblSoLuongPhanHoi
                    int soLuongPhanHoi = phndBll.ThongKeSoLuongPhanHoiNguoiDungTheoDiem(masanpham, diem);
                    lblSoLuongDanhGia.Text = soLuongPhanHoi.ToString();
                }
                else
                {
                    dgv_DsPhanHoiKhachHang.DataSource = null;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void BtnLoc_Click(object sender, EventArgs e)
        {
            //Load data grid view theo điều kiện lọc từ ngày bắt đầu đến ngày kết thúc
            try
            {
                DateTime tuNgay = (DateTime)dtpNgayBatDau.Value;
                DateTime denNgay = (DateTime)dtpNgayKetThuc.Value;
                string masanpham = cbbSanPham.SelectedValue.ToString();
                lstPhanHoiNguoiDung = phndBll.LayDanhSachPhanHoiNguoiDungTheoThoiGian(masanpham, tuNgay, denNgay);
                if (lstPhanHoiNguoiDung != null && lstPhanHoiNguoiDung.Count > 0)
                {
                    dgv_DsPhanHoiKhachHang.DataSource = lstPhanHoiNguoiDung;
                    dgv_DsPhanHoiKhachHang.Columns[0].Visible = false;
                    dgv_DsPhanHoiKhachHang.Columns[1].Visible = false;
                    dgv_DsPhanHoiKhachHang.Columns[5].Visible = false;
                    dgv_DsPhanHoiKhachHang.BackgroundColor = Color.White;
                    dgv_DsPhanHoiKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgv_DsPhanHoiKhachHang.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                }
                else
                {
                    dgv_DsPhanHoiKhachHang.DataSource = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        private void Frm_quanLyPhanHoiKhachHang_Load(object sender, EventArgs e)
        {
            LoadComboboxSanPham();
            LoadComboboxXepHang();
        }

        private void LoadComboboxXepHang()
        {
            try
            {
                //Cho combobox chọn điểm từ 1 đến 5
                List<int> lstDiem = new List<int>();
                for (int i = 1; i <= 5; i++)
                {
                    lstDiem.Add(i);
                }
                cbbXepHang.DataSource = lstDiem;
                cbbXepHang.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            

        }

        private void LoadDataGridView()
        {
            try
            {
                string masanpham = cbbSanPham.SelectedValue.ToString();
                lstPhanHoiNguoiDung = phndBll.LayDanhSachPhanHoiNguoiDung(masanpham);
                if (lstPhanHoiNguoiDung != null && lstPhanHoiNguoiDung.Count > 0)
                {
                    dgv_DsPhanHoiKhachHang.DataSource = lstPhanHoiNguoiDung;
                    dgv_DsPhanHoiKhachHang.Columns[0].Visible = false;
                    dgv_DsPhanHoiKhachHang.Columns[1].Visible = false;
                    dgv_DsPhanHoiKhachHang.Columns[5].Visible = false;
                    dgv_DsPhanHoiKhachHang.BackgroundColor = Color.White;
                    dgv_DsPhanHoiKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgv_DsPhanHoiKhachHang.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    //Load điểm xếp hạng trung bình gắn cho lblXepHangTrungBinh
                    decimal diemTB = (decimal)lstPhanHoiNguoiDung.Average(x => x.XepHangNguoiDung);
                    lblDiemXepHangTrungBinh.Text = diemTB.ToString();
                    lblSoLuongDanhGia.Text = lstPhanHoiNguoiDung.Count.ToString();

                }
                else
                {
                    dgv_DsPhanHoiKhachHang.DataSource = null;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void LoadComboboxSanPham()
        {
            try
            {
                SanPhamBLL sanPhamBLL = new SanPhamBLL();
                List<SanPham> lst = sanPhamBLL.LayDanhSachSanPham();
                cbbSanPham.DataSource = lst;
                cbbSanPham.ValueMember = "MaSanPham";
                cbbSanPham.DisplayMember = "TenSanPham";
                cbbSanPham.SelectedIndex = -1;
                cbbSanPham.SelectedIndexChanged += CbbSanPham_SelectedIndexChanged;
                cbbSanPham.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void CbbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
    }
}
