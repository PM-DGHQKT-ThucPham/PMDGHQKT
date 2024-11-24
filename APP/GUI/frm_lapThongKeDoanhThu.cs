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
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI
{
    public partial class frm_lapThongKeDoanhThu : Form
    {
        // Khai báo biến toàn cục
        private LoaiDoanhThuBLL _loaiDoanhThuBLL = new LoaiDoanhThuBLL();
        private DoanhThuBLL _doanhThuBLL = new DoanhThuBLL();
        private List<LoaiDoanhThu> _lstLoaiDoanhThu = null;
        private List<DoanhThu> _lstDoanhThu = null;
        private string maSanPham = "SP001";
        public frm_lapThongKeDoanhThu()
        {
            InitializeComponent();
            this.Load += Frm_lapThongKeDoanhThu_Load;
        }

        private void Frm_lapThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            _lstDoanhThu = new List<DoanhThu>();
            _lstDoanhThu = _doanhThuBLL.LayDanhSachDoanhThu(maSanPham);
            HienThiDanhSachDoanhThu(_lstDoanhThu);
            HienThiDoanhThuTheoLoaiDoanhThu(_lstDoanhThu);
            LoadComboboxTimKiem();
            LoadComboboxLoaiDoanhThu();
            cbo_chucNang.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_loaiDoanhThu.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_sanPham.DropDownStyle = ComboBoxStyle.DropDownList;
            dgv_dsDoanhThu.ReadOnly = true;
            //sự kiện khi chọn combo box
            cbo_chucNang.SelectedIndexChanged += Cbo_chucNang_SelectedIndexChanged;
            cbo_loaiDoanhThu.SelectedIndexChanged += Cbo_loaiDoanhThu_SelectedIndexChanged;
            //sự kiện click cho button tìm kiếm
            btn_timKiem.Click += Btn_timKiem_Click;
            PlaceHolder.SetPlaceholder(txt_timKiem, "Nhập từ khóa tìm kiếm");
        }

        private void Cbo_loaiDoanhThu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lấy giá trị của combobox
            string maLoaiDoanhThu = cbo_loaiDoanhThu.SelectedValue.ToString();
            string tenLoaiDoanhThu = cbo_loaiDoanhThu.Text;
            if (string.IsNullOrEmpty(maLoaiDoanhThu))
            {
                MessageBox.Show("Vui lòng chọn loại doanh thu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                _lstDoanhThu = _doanhThuBLL.LayDoanhThuTheoMaLoaiDoanhThu(maLoaiDoanhThu, maSanPham);
                HienThiDanhSachDoanhThu(_lstDoanhThu);
                string tile = "Doanh thu  theo " + tenLoaiDoanhThu;
                HienThiDoanhThuTheoThang(_lstDoanhThu,tile);

            }
        }

        private void Cbo_chucNang_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lấy giá trị của combobox
            string chucNang = cbo_chucNang.SelectedItem.ToString();
            if (chucNang == "Tìm kiếm theo mã doanh thu")
            {
                txt_timKiem.Enabled = true;
                dtp_ngayBatDau.Enabled = false;
                dtp_ngayKetThuc.Enabled = false;
            }
            else if (chucNang == "Tìm kiếm theo mã loại doanh thu")
            {
                txt_timKiem.Enabled = true;
                dtp_ngayBatDau.Enabled = false;
                dtp_ngayKetThuc.Enabled = false;
            }
            else if (chucNang == "Tìm kiếm theo tháng")
            {
                txt_timKiem.Enabled = false;
                dtp_ngayBatDau.Enabled = true;
                dtp_ngayKetThuc.Enabled = false;
            }
            else if (chucNang == "Tìm kiếm theo Thời gian")
            {
                txt_timKiem.Enabled = false;
                dtp_ngayBatDau.Enabled = true;
                dtp_ngayKetThuc.Enabled = true;
            }
            else if (chucNang == "Hiển thị tất cả")
            {
                txt_timKiem.Enabled = false;
                dtp_ngayBatDau.Enabled = false;
                dtp_ngayKetThuc.Enabled = false;
            }
        }

        private void Btn_timKiem_Click(object sender, EventArgs e)
        {
            //kiểm tra điều kiện tìm kiếm
            cbo_chucNang.SelectedIndex = cbo_chucNang.SelectedIndex;
            if (cbo_chucNang.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn chức năng tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                string chucNang = cbo_chucNang.SelectedItem.ToString();
                string timKiem = txt_timKiem.Text;
                _lstDoanhThu = new List<DoanhThu>();
                if (chucNang == "Tìm kiếm theo mã doanh thu")
                {
                    if (txt_timKiem.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    DoanhThu doanhThu = _doanhThuBLL.LayDoanhThuTheoMa(timKiem, maSanPham);
                    if (doanhThu != null)
                    {
                        _lstDoanhThu.Add(doanhThu);
                    }
                    HienThiDanhSachDoanhThu(_lstDoanhThu);
                }
                else if (chucNang == "Tìm kiếm theo mã loại doanh thu")
                {
                    if (txt_timKiem.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    _lstDoanhThu = _doanhThuBLL.LayDoanhThuTheoMaLoaiDoanhThu(timKiem, maSanPham);
                    if(_lstDoanhThu.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy kết quả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    HienThiDanhSachDoanhThu(_lstDoanhThu);
                }
                else if (chucNang == "Tìm kiếm theo tháng")
                {
                    DateTime ngay =dtp_ngayBatDau.Value;
                    // lấy ngày tháng năm từ datetimepicker
                    int thang = ngay.Month;
                    int nam = ngay.Year;
                    _lstDoanhThu = _doanhThuBLL.LayDoanhThuTheoThang(thang,nam, maSanPham);
                    if (_lstDoanhThu.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy kết quả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    HienThiDanhSachDoanhThu(_lstDoanhThu);
                    HienThiDoanhThuTheoLoaiDoanhThu(_lstDoanhThu);
                }
                else if (chucNang == "Tìm kiếm theo Thời gian")
                {
                    DateTime ngayBatDau = dtp_ngayBatDau.Value;
                    DateTime ngayKetThuc = dtp_ngayKetThuc.Value;
                    _lstDoanhThu = _doanhThuBLL.LayDoanhThuTheoKhoangThoiGian(ngayBatDau,ngayKetThuc, maSanPham);
                    if (_lstDoanhThu.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy kết quả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    HienThiDanhSachDoanhThu(_lstDoanhThu);
                    HienThiDoanhThuTheoLoaiDoanhThu(_lstDoanhThu);
                }
                else if (chucNang == "Hiển thị tất cả")
                {
                    _lstDoanhThu = _doanhThuBLL.LayDanhSachDoanhThu(maSanPham);
                    HienThiDanhSachDoanhThu(_lstDoanhThu);
                    HienThiDoanhThuTheoLoaiDoanhThu(_lstDoanhThu);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Tìm kiếm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //viết hàm xử lý 
        // Hiển thị doanh thu theo loại doanh thu lên biểu đồ Pie
        private void HienThiDoanhThuTheoLoaiDoanhThu(List<DoanhThu> _lstDoanhThu)
        {
            // Xóa dữ liệu cũ
            chart_doanhThu.Series.Clear();
            chart_doanhThu.Titles.Clear();
            chart_doanhThu.ChartAreas[0].RecalculateAxesScale();

            // Gắn nhãn cho biểu đồ
            chart_doanhThu.Titles.Add("Doanh thu theo loại doanh thu");

            // Tính toán tổng doanh thu theo loại
            var doanhThuTheoLoai = _lstDoanhThu
                .GroupBy(x => x.LoaiDoanhThu.TenLoaiDoanhThu)
                .Select(group => new { Loai = group.Key, TongDoanhThu = group.Sum(x => x.SoTien ?? 0) })
                .ToList();

            // Tính tổng doanh thu để tính phần trăm
            decimal tongDoanhThuTatCa = doanhThuTheoLoai.Sum(x => x.TongDoanhThu);

            // Khởi tạo Series cho biểu đồ Pie
            Series series = new Series("Doanh thu")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie,
                IsValueShownAsLabel = true
            };

            // Thêm dữ liệu vào Series
            foreach (var item in doanhThuTheoLoai)
            {
                var dataPoint = new DataPoint
                {
                    AxisLabel = $"{item.Loai}",
                    YValues = new[] { (double)item.TongDoanhThu },
                    Label = $"{item.Loai}: {item.TongDoanhThu:N0} ({(item.TongDoanhThu / tongDoanhThuTatCa):P1})"
                };
                series.Points.Add(dataPoint);
            }

            // Thêm Series vào biểu đồ
            chart_doanhThu.Series.Add(series);

            // Định dạng biểu đồ
            chart_doanhThu.Series["Doanh thu"]["PieLabelStyle"] = "Outside"; // Hiển thị nhãn bên ngoài biểu đồ
            chart_doanhThu.Legends.Clear(); // Thêm chú thích nếu cần
            Legend legend = new Legend
            {
                Docking = Docking.Right
            };
            chart_doanhThu.Legends.Add(legend);
        }

        // Hiển thị doanh thu từng tháng lên biểu đồ
        private void HienThiDoanhThuTheoThang(List<DoanhThu> _lstDoanhThu, string title)
        {
            // Xóa dữ liệu cũ
            chart_doanhThu.Series.Clear();
            chart_doanhThu.Titles.Clear();
            chart_doanhThu.ChartAreas[0].RecalculateAxesScale();

            // Gắn nhãn cho biểu đồ
            chart_doanhThu.Titles.Add(title);

            // Tính toán tổng doanh thu theo tháng
            var doanhThuTheoThang = _lstDoanhThu
                .GroupBy(x => x.ThoiGian.Value.Month)
                .Select(group => new { Thang = group.Key, TongDoanhThu = group.Sum(x => x.SoTien ?? 0) })
                .OrderBy(x => x.Thang)
                .ToList();

            // Khởi tạo Series cho biểu đồ cột
            Series series = new Series("Doanh thu")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column,
                IsValueShownAsLabel = true
            };

            // Thêm dữ liệu vào Series
            foreach (var item in doanhThuTheoThang)
            {
                series.Points.AddXY($"Tháng {item.Thang}", item.TongDoanhThu);
            }

            // Thêm Series vào biểu đồ
            chart_doanhThu.Series.Add(series);

            // Cấu hình trục
            chart_doanhThu.ChartAreas[0].AxisX.Title = "Tháng";
            chart_doanhThu.ChartAreas[0].AxisX.Interval = 1;

            chart_doanhThu.ChartAreas[0].AxisY.Title = "Doanh thu";
            chart_doanhThu.ChartAreas[0].AxisY.Interval = 1000000000; // Từng 1 tỷ
            chart_doanhThu.ChartAreas[0].AxisY.Minimum = 0;
            chart_doanhThu.ChartAreas[0].AxisY.Maximum = 5000000000; // Giới hạn 5 tỷ
        }
        //load combobox loại doanh thu
        private void LoadComboboxLoaiDoanhThu()
        {
            _lstLoaiDoanhThu = _loaiDoanhThuBLL.LayDanhSachLoaiDoanhThu(maSanPham);
            if (_lstLoaiDoanhThu != null)
            {
                cbo_loaiDoanhThu.DataSource = _lstLoaiDoanhThu;
                cbo_loaiDoanhThu.DisplayMember = "TenLoaiDoanhThu";
                cbo_loaiDoanhThu.ValueMember = "MaLoaiDoanhThu";
            }
        }
        //viết hàm load các chức năng tìm kiếm lên combobox
        private void LoadComboboxTimKiem()
        {
            cbo_chucNang.Items.Add("Hiển thị tất cả");
            cbo_chucNang.Items.Add("Tìm kiếm theo mã doanh thu");
            cbo_chucNang.Items.Add("Tìm kiếm theo mã loại doanh thu");
            cbo_chucNang.Items.Add("Tìm kiếm theo tháng");
            cbo_chucNang.Items.Add("Tìm kiếm theo Thời gian");
            cbo_chucNang.SelectedIndex = 0;

        }
        // viết hàm xử lý thêm cột số thứ tự nếu chưa có
        private void dgvSanPham_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dgv_dsDoanhThu.Columns.Contains("SoThuTu"))
            {
                dgv_dsDoanhThu.Rows[e.RowIndex].Cells["SoThuTu"].Value = (e.RowIndex + 1).ToString();
            }
        }
        private void themCotSoThuTu(DataGridView dgvSanPham)
        {
            // Kiểm tra xem cột đã tồn tại hay chưa
            if (dgvSanPham.Columns["SoThuTu"] == null)
            {
                DataGridViewTextBoxColumn soThuTuColumn = new DataGridViewTextBoxColumn
                {
                    Name = "SoThuTu",
                    HeaderText = "STT",
                    Width = 40,
                    ReadOnly = true
                };

                // Thêm cột số thứ tự vào đầu DataGridView
                dgvSanPham.Columns.Insert(0, soThuTuColumn);
            }
        }
        // khời tạo datagirdview    
        public void KhoiTaoDgvDoanhThu()
        {
            dgv_dsDoanhThu.Columns["MaDoanhThu"].HeaderText = "Mã doanh thu";
            dgv_dsDoanhThu.Columns["MaLoaiDoanhThu"].HeaderText = "Mã loại doanh thu";
            dgv_dsDoanhThu.Columns["MoTa"].HeaderText = "Mô tả";
            dgv_dsDoanhThu.Columns["SoTien"].HeaderText = "Số tiền";
            dgv_dsDoanhThu.Columns["ThoiGian"].HeaderText = "Thời gian";

            //in đậm tiêu đề 
            dgv_dsDoanhThu.Columns["MaDoanhThu"].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv_dsDoanhThu.Columns["MaLoaiDoanhThu"].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv_dsDoanhThu.Columns["MoTa"].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv_dsDoanhThu.Columns["SoTien"].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv_dsDoanhThu.Columns["ThoiGian"].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);

            //ẩn các dòng trống
            dgv_dsDoanhThu.AllowUserToAddRows = false;
            dgv_dsDoanhThu.AllowUserToDeleteRows = false;
            dgv_dsDoanhThu.AllowUserToResizeRows = false;
            dgv_dsDoanhThu.RowHeadersVisible = false;
            dgv_dsDoanhThu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_dsDoanhThu.ReadOnly = true;
            //định dạng kiểu tiền tệ
            dgv_dsDoanhThu.Columns["SoTien"].DefaultCellStyle.Format = "N0";
            //ẩn các cột không can thiệp
            dgv_dsDoanhThu.Columns["LoaiDoanhThu"].Visible = false;
        }
        //lấy doanh sách doanh thu hiện lên datagridview
        private void HienThiDanhSachDoanhThu(List<DoanhThu> lstDoanhThu)
        {
            try
            {
                 dgv_dsDoanhThu.DataSource = null;
                _lstDoanhThu = lstDoanhThu;
                if (_lstDoanhThu != null)
                {
                    dgv_dsDoanhThu.DataSource = _lstDoanhThu;
                    KhoiTaoDgvDoanhThu();
                    themCotSoThuTu(dgv_dsDoanhThu);
                    dgv_dsDoanhThu.RowPostPaint -= dgvSanPham_RowPostPaint;
                    dgv_dsDoanhThu.RowPostPaint += dgvSanPham_RowPostPaint;
                    dgv_dsDoanhThu.Invalidate();
                    dgv_dsDoanhThu.Refresh();
                }  
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
        }
    }
}
