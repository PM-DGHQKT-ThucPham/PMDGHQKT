using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BLL;
using DTO;

namespace GUI
{
    public partial class frm_lapThongKeLoiNhuan : Form
    {

        LoiNhuanBLL _loiNhuanBLL = new LoiNhuanBLL();
        DoanhThuBLL _doanhThuBLL = new DoanhThuBLL();
        List<LoiNhuan> _lstLoiNhuan = new List<LoiNhuan>();

        SanPhamBLL _sanPhamBLL = new SanPhamBLL();
        List<SanPham> _lstSanPham = new List<SanPham>();
        string maSP = string.Empty;
        public frm_lapThongKeLoiNhuan()
        {
            InitializeComponent();
            this.Load += frm_lapThongKeLoiNhuan_Load;
        }

        private void frm_lapThongKeLoiNhuan_Load(object sender, EventArgs e)
        {
            LoadComboBoxSanPham();
            LoadComboBoxChucNang();
            _lstLoiNhuan=_loiNhuanBLL.LayTatCaLoiNhuanTheoMaSanPham(maSP);
            HienThiTatCaLoiNhuanTheoMaSanPham(_lstLoiNhuan);
            HienThiLoiNhuanLenBieuDo(_lstLoiNhuan);
            HienThiTiLeLoiNhuanLenBieuDo(_lstLoiNhuan, _doanhThuBLL.LayDanhSachDoanhThu(maSP));
            cbo_chucNang.SelectedIndexChanged += Cbo_chucNang_SelectedIndexChanged;
            btn_timKiem.Click += Btn_timKiem_Click;
            //chỉnh sửa dtp hiển thị ngày tháng năm
            dtp_ngayBatDau.Format = DateTimePickerFormat.Custom;
            dtp_ngayBatDau.CustomFormat = "MM/yyyy";
            dtp_ngayKetThuc.Format = DateTimePickerFormat.Custom;
            dtp_ngayKetThuc.CustomFormat = "MM/yyyy";
            dgv_dsLoiNhuan.SelectionChanged += Dgv_dsLoiNhuan_SelectionChanged;
        }

        private void Dgv_dsLoiNhuan_SelectionChanged(object sender, EventArgs e)
        {
            //lấy current row
            if (dgv_dsLoiNhuan.CurrentRow != null)
            {
                LoiNhuan ln = (LoiNhuan)dgv_dsLoiNhuan.CurrentRow.DataBoundItem;
                if (ln != null)
                {

                    //hiển thị tiền việt nam
                    txt_loiNhuanGop.Text = $"{ln.LoiNhuanGop:N0} VND";
                    txt_loiNhuanRong.Text = $"{ln.LoiNhuanRong:N0} VND"; ;
                }
                //tính tỉ lệ lợi nhuận gộp và ròng
                // Lấy lợi nhuận gộp và ròng từ BLL
                decimal loiNhuanGop = _loiNhuanBLL.TinhLoiNhuanGop(maSP, ln.ThoiGian.Value.Month, ln.ThoiGian.Value.Year);
                decimal loiNhuanRong = _loiNhuanBLL.TinhLoiNhuanRong(maSP, ln.ThoiGian.Value.Month, ln.ThoiGian.Value.Year);
                // Lấy doanh thu của sản phẩm trong cùng tháng và năm để tính tỷ lệ
                List<DoanhThu> doanhThus = _doanhThuBLL.LayDoanhThuTheoThang(ln.ThoiGian.Value.Month, ln.ThoiGian.Value.Year, maSP);
                //tính tổng doanh thu
                decimal? totalDoanhThu = doanhThus?.Sum(dt => dt.SoTien);
                DoanhThu doanhThu = new DoanhThu { SoTien = totalDoanhThu ?? 0 };
                Decimal doanhThuThang = doanhThu?.SoTien ?? 0;
                // Kiểm tra để tránh chia cho 0
                if (doanhThuThang != 0)
                {
                    // Tính tỷ lệ lợi nhuận gộp và lợi nhuận ròng
                    decimal tyLeLoiNhuanGop = (loiNhuanGop / doanhThuThang) * 100;
                    decimal tyLeLoiNhuanRong = (loiNhuanRong / doanhThuThang) * 100;

                    // Cập nhật lên giao diện
                    txt_tyLeLoiNhuanGop.Text = tyLeLoiNhuanGop.ToString("F2") + '%'; // Hiển thị 2 chữ số sau dấu phẩy
                    txt_tyLeLoiNhuanRong.Text = tyLeLoiNhuanRong.ToString("F2") + '%'; // Hiển thị 2 chữ số sau dấu phẩy
                }
                else
                {
                    // Nếu doanh thu = 0, tỉ lệ lợi nhuận gộp và ròng sẽ là 0%
                    txt_tyLeLoiNhuanGop.Text = "0%";
                    txt_tyLeLoiNhuanRong.Text = "0%";
                }
            }
        }

        private void Btn_timKiem_Click(object sender, EventArgs e)
        {
            //kiểm tra chức năng
            string chucNang = cbo_chucNang.SelectedItem.ToString();
            string timKiem = txt_timKiem.Text;
            DateTime ngayBatDau = dtp_ngayBatDau.Value;
            DateTime ngayKetThuc = dtp_ngayKetThuc.Value;
            switch (chucNang) {
                case "Hiển thị tất cả":
                    _lstLoiNhuan = _loiNhuanBLL.LayTatCaLoiNhuanTheoMaSanPham(maSP);
                    break;
                case "Hiển thị mã lợi nhuận":
                    //kiểm tra mã lợi nhuận
                    if(string.IsNullOrEmpty(timKiem))
                     {
                        MessageBox.Show("Vui lòng nhập mã lợi nhuân");
                    }
                    _lstLoiNhuan =_loiNhuanBLL.LayTatCaLoiNhuanTheoMaSanPham(maSP).Where(x => x.MaLoiNhuan.Contains(timKiem)).ToList();
                    break;
                case "Hiển thị theo tháng":
                    //kiểm tra tháng nhỏ hơn 6-2024
                    DateTime thang6 = new DateTime(2024, 6, 1);
                    if(ngayBatDau < thang6 )
                    {
                        MessageBox.Show("Vui lòng chọn tháng lớn hơn 6-2024");
                        return;
                    }    
                    _lstLoiNhuan = _loiNhuanBLL.LayLoiNhuanTheoThangNam(ngayBatDau.Month, ngayBatDau.Year, maSP);
                    break;
                case "Hiển thị theo khoảng thời gian":
                    //kiểm tra ngày bắt đầu nhỏ hơn ngày kết thúc
                    if (ngayBatDau > ngayKetThuc)
                    {
                        MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc");
                        return;
                    }
                    _lstLoiNhuan = _loiNhuanBLL.LayLoiNhuanTheoKhoangThoiGian(ngayBatDau, ngayKetThuc, maSP);
                    break;
                default:
                    break;
            }
            HienThiTatCaLoiNhuanTheoMaSanPham(_lstLoiNhuan);
        }

        private void Cbo_chucNang_SelectedIndexChanged(object sender, EventArgs e)
        {
            //xử lý ẩn hiện các control
            if (cbo_chucNang.SelectedItem.ToString() == "Hiển thị mã lợi nhuận")
            {
                dtp_ngayBatDau.Enabled = false;
                dtp_ngayKetThuc.Enabled = false;
                txt_timKiem.Enabled = true;
                btn_timKiem.Enabled = true;
            }
            else if (cbo_chucNang.SelectedItem.ToString() == "Hiển thị theo tháng")
            {
                dtp_ngayBatDau.Enabled = true;
                dtp_ngayKetThuc.Enabled = false;
                txt_timKiem.Enabled = false;
                btn_timKiem.Enabled = true;
            }
            else if (cbo_chucNang.SelectedItem.ToString() == "Hiển thị theo khoảng thời gian")
            {
                dtp_ngayBatDau.Enabled = true;
                dtp_ngayKetThuc.Enabled = true;
                txt_timKiem.Enabled = false;
                btn_timKiem.Enabled = true;
            }
            else
            {
                btn_timKiem.Enabled = true;
                _lstLoiNhuan = _loiNhuanBLL.LayTatCaLoiNhuanTheoMaSanPham(maSP);
                HienThiTatCaLoiNhuanTheoMaSanPham(_lstLoiNhuan);
                HienThiLoiNhuanLenBieuDo(_lstLoiNhuan);
                HienThiTiLeLoiNhuanLenBieuDo(_lstLoiNhuan, _doanhThuBLL.LayDanhSachDoanhThu(maSP));
            }
        }
        private void Cbo_sanPham_SelectedValueChanged(object sender, EventArgs e)
        {
            maSP = cbo_sanPham.SelectedValue.ToString();
            LoadLaiTrang();
        }


        // viết hàm xử lý ở đây
        //load lại trang
        private void LoadLaiTrang()
        {
            _lstLoiNhuan = _loiNhuanBLL.LayTatCaLoiNhuanTheoMaSanPham(maSP);
            HienThiTatCaLoiNhuanTheoMaSanPham(_lstLoiNhuan);
            HienThiLoiNhuanLenBieuDo(_lstLoiNhuan);
            HienThiTiLeLoiNhuanLenBieuDo(_lstLoiNhuan, _doanhThuBLL.LayDanhSachDoanhThu(maSP));
        }
        private void LoadComboBoxSanPham()
        {
            try
            {
                _lstSanPham = _sanPhamBLL.LayDanhSachSanPham();  // Lấy danh sách sản phẩm từ BLL

                if (_lstSanPham != null && _lstSanPham.Count > 0)
                {
                    cbo_sanPham.DataSource = _lstSanPham;
                    cbo_sanPham.DisplayMember = "TenSanPham";  // Hiển thị tên sản phẩm
                    cbo_sanPham.ValueMember = "MaSanPham";  // Gán giá trị mã sản phẩm

                    // Gán giá trị đầu tiên vào maSP
                    maSP = _lstSanPham.FirstOrDefault()?.MaSanPham.ToString();

                    // Chọn mục đầu tiên của ComboBox nếu có ít nhất một phần tử
                    cbo_sanPham.SelectedIndex = 0;

                    // Đăng ký sự kiện SelectedValueChanged
                    cbo_sanPham.SelectedValueChanged += Cbo_sanPham_SelectedValueChanged;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm nào");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu sản phẩm: " + ex.Message);
            }
        }

        private void HienThiLoiNhuanLenBieuDo(List<LoiNhuan> lstLoiNhuan)
        {
            if (lstLoiNhuan == null || lstLoiNhuan.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để hiển thị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xóa dữ liệu cũ trên biểu đồ
            chart_loiNhuan.Series.Clear();
            chart_loiNhuan.ChartAreas.Clear();
            chart_loiNhuan.Titles.Clear();
            chart_loiNhuan.Legends.Clear();

            // Thêm tiêu đề biểu đồ với cỡ chữ 12
            Title title = new Title("Biểu đồ lợi nhuận")
            {
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            chart_loiNhuan.Titles.Add(title);

            // Thêm khu vực biểu đồ
            ChartArea chartArea = new ChartArea("LoiNhuanArea");
            chartArea.AxisX.Title = "Thời gian";
            chartArea.AxisX.TitleFont = new Font("Arial", 12, FontStyle.Bold);
            chartArea.AxisY.Title = "Lợi nhuận";
            chartArea.AxisY.TitleFont = new Font("Arial", 12, FontStyle.Bold);

            chartArea.AxisX.LabelStyle.Font = new Font("Arial", 12); // Cỡ chữ trục X
            chartArea.AxisY.LabelStyle.Font = new Font("Arial", 12); // Cỡ chữ trục Y
            chartArea.AxisX.Interval = 1; // Hiển thị từng thời điểm
            chart_loiNhuan.ChartAreas.Add(chartArea);

            // Thêm series cho lợi nhuận gộp
            Series seriesGop = new Series("Lợi nhuận gộp")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 2,
                Font = new Font("Arial", 12)
            };
            chart_loiNhuan.Series.Add(seriesGop);

            // Thêm series cho lợi nhuận ròng
            Series seriesRong = new Series("Lợi nhuận ròng")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 2,
                Font = new Font("Arial", 12)
            };
            chart_loiNhuan.Series.Add(seriesRong);

            // Thêm dữ liệu vào series
            foreach (var loiNhuan in lstLoiNhuan)
            {
                seriesGop.Points.AddXY(
                    string.Format(CultureInfo.InvariantCulture, "{0:MM/yyyy}", loiNhuan.ThoiGian),
                    loiNhuan.LoiNhuanGop
                );
                seriesRong.Points.AddXY(
                    string.Format(CultureInfo.InvariantCulture, "{0:MM/yyyy}", loiNhuan.ThoiGian),
                    loiNhuan.LoiNhuanRong
                );
            }

            // Thêm chú thích (Legend)
            Legend legend = new Legend()
            {
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            chart_loiNhuan.Legends.Add(legend);

            // Cập nhật biểu đồ
            chart_loiNhuan.Invalidate();
        }
        private void HienThiTiLeLoiNhuanLenBieuDo(List<LoiNhuan> lstLoiNhuan, List<DoanhThu> lstDoanhThu)
        {
            if (lstLoiNhuan == null || lstLoiNhuan.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để hiển thị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xóa dữ liệu cũ trên biểu đồ
            chart_tile.Series.Clear();
            chart_tile.ChartAreas.Clear();
            chart_tile.Titles.Clear();
            chart_tile.Legends.Clear();

            // Thêm tiêu đề biểu đồ
            Title title = new Title("Biểu đồ tỷ lệ lợi nhuận")
            {
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            chart_tile.Titles.Add(title);

            // Thêm khu vực biểu đồ
            ChartArea chartArea = new ChartArea("TiLeLoiNhuanArea");
            chartArea.AxisX.Title = "Thời gian";
            chartArea.AxisX.TitleFont = new Font("Arial", 12, FontStyle.Bold);
            chartArea.AxisY.Title = "Tỷ lệ (%)";
            chartArea.AxisY.TitleFont = new Font("Arial", 12, FontStyle.Bold);
            chartArea.AxisX.LabelStyle.Font = new Font("Arial", 12);
            chartArea.AxisY.LabelStyle.Font = new Font("Arial", 12);
            chartArea.AxisX.Interval = 1;
            chart_tile.ChartAreas.Add(chartArea);

            // Thêm series cho tỷ lệ lợi nhuận gộp
            Series seriesGop = new Series("Tỷ lệ lợi nhuận gộp")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 2
            };
            chart_tile.Series.Add(seriesGop);

            // Thêm series cho tỷ lệ lợi nhuận ròng
            Series seriesRong = new Series("Tỷ lệ lợi nhuận ròng")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 2
            };
            chart_tile.Series.Add(seriesRong);

            // Tính toán và thêm dữ liệu vào series
            // Tính toán và thêm dữ liệu vào series
            foreach (var loiNhuan in lstLoiNhuan)
            {
                // Tính tổng doanh thu cho tháng đó
                var doanhThu = lstDoanhThu
                .Where(dt => dt.ThoiGian.HasValue && dt.ThoiGian.Value.Month == loiNhuan.ThoiGian.Value.Month && dt.ThoiGian.Value.Year == loiNhuan.ThoiGian.Value.Year)  // Lọc doanh thu theo tháng và năm của lợi nhuận
                .Sum(dt => dt.SoTien);  // Tính tổng doanh thu cho tháng đó

                // Kiểm tra nếu doanh thu có giá trị
                if (doanhThu > 0)
                {
                    // Tính tỷ lệ lợi nhuận
                    decimal tyLeLoiNhuanGop = (loiNhuan.LoiNhuanGop.GetValueOrDefault() / doanhThu.GetValueOrDefault()) * 100;
                    decimal tyLeLoiNhuanRong = (loiNhuan.LoiNhuanRong.GetValueOrDefault() / doanhThu.GetValueOrDefault()) * 100;

                    // Xuất ra console để kiểm tra
                    Console.WriteLine($"Thời gian: {loiNhuan.ThoiGian:MM/yyyy}");
                    Console.WriteLine($"Tổng doanh thu: {doanhThu}");
                    Console.WriteLine($"Lợi nhuận gộp: {loiNhuan.LoiNhuanGop.GetValueOrDefault()}, Tỷ lệ gộp: {tyLeLoiNhuanGop}%");
                    Console.WriteLine($"Lợi nhuận ròng: {loiNhuan.LoiNhuanRong.GetValueOrDefault()}, Tỷ lệ ròng: {tyLeLoiNhuanRong}%");
                    Console.WriteLine("----------------------------------------");

                    // Thêm điểm vào series
                    string thoiGian = string.Format(CultureInfo.InvariantCulture, "{0:MM/yyyy}", loiNhuan.ThoiGian);
                    seriesGop.Points.AddXY(thoiGian, tyLeLoiNhuanGop);
                    seriesRong.Points.AddXY(thoiGian, tyLeLoiNhuanRong);
                }
            }


            // Thêm chú thích (Legend)
            Legend legend = new Legend()
            {
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            chart_tile.Legends.Add(legend);

            // Cập nhật biểu đồ
            chart_tile.Invalidate();
        }


        // load combobox chức năng
        private void LoadComboBoxChucNang()
        {
            cbo_chucNang.Items.Add("Hiển thị tất cả");
            cbo_chucNang.Items.Add("Hiển thị mã lợi nhuận");
            cbo_chucNang.Items.Add("Hiển thị theo tháng");
            cbo_chucNang.Items.Add("Hiển thị theo khoảng thời gian");
            cbo_chucNang.SelectedIndex = 0;
        }
        //thêm cột số thứ tự vào datagirdview nếu chưa có
        // viết hàm xử lý thêm cột số thứ tự nếu chưa có
        private void dgvSanPham_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dgv_dsLoiNhuan.Columns.Contains("SoThuTu"))
            {
                dgv_dsLoiNhuan.Rows[e.RowIndex].Cells["SoThuTu"].Value = (e.RowIndex + 1).ToString();
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

        // khởi tạo datagird view
        private void KhoiTaoDataGirdView()
        {
            if (dgv_dsLoiNhuan == null || dgv_dsLoiNhuan.Columns.Count == 0)
            {
                MessageBox.Show("DataGridView chưa được khởi tạo hoặc không có cột nào", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Sửa tiêu đề của các cột nếu tồn tại
            if (dgv_dsLoiNhuan.Columns["MaLoiNhuan"] != null)
                dgv_dsLoiNhuan.Columns["MaLoiNhuan"].HeaderText = "Mã lợi nhuận";

            if (dgv_dsLoiNhuan.Columns["MaSanPham"] != null)
                dgv_dsLoiNhuan.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";

            if (dgv_dsLoiNhuan.Columns["ThoiGian"] != null)
                dgv_dsLoiNhuan.Columns["ThoiGian"].HeaderText = "Thời gian";

            if (dgv_dsLoiNhuan.Columns["MoTa"] != null)
                dgv_dsLoiNhuan.Columns["MoTa"].HeaderText = "Mô tả";

            if (dgv_dsLoiNhuan.Columns["LoiNhuanGop"] != null)
                dgv_dsLoiNhuan.Columns["LoiNhuanGop"].HeaderText = "Lợi nhuận gộp";

            if (dgv_dsLoiNhuan.Columns["LoiNhuanRong"] != null)
                dgv_dsLoiNhuan.Columns["LoiNhuanRong"].HeaderText = "Lợi nhuận ròng";

            // Định dạng cột
            foreach (DataGridViewColumn col in dgv_dsLoiNhuan.Columns)
            {
                col.HeaderCell.Style.Font = new Font("Arial", 11.75F, FontStyle.Bold);
            }

            // Căn giữa dữ liệu toàn bộ dữ liệu hiển thị full datagridview
            dgv_dsLoiNhuan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // căn giữa tiêu đề cột
            dgv_dsLoiNhuan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (dgv_dsLoiNhuan.Columns["MaLoiNhuan"] != null)
                dgv_dsLoiNhuan.Columns["MaLoiNhuan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Ẩn cột không cần thiết
            if (dgv_dsLoiNhuan.Columns["SanPham"] != null)
                dgv_dsLoiNhuan.Columns["SanPham"].Visible = false;
            //hiển thị tiền việt nam
            if (dgv_dsLoiNhuan.Columns["LoiNhuanGop"] != null)
                dgv_dsLoiNhuan.Columns["LoiNhuanGop"].DefaultCellStyle.Format = "N0";
            if (dgv_dsLoiNhuan.Columns["LoiNhuanRong"] != null)
                dgv_dsLoiNhuan.Columns["LoiNhuanRong"].DefaultCellStyle.Format = "N0";

            dgv_dsLoiNhuan.Columns["LoiNhuanGop"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // Căn phải
            dgv_dsLoiNhuan.Columns["LoiNhuanRong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // Căn phải
        }

        //Hiển thị tất cả lợi nhuận theo mã sản phẩm
        private void HienThiTatCaLoiNhuanTheoMaSanPham(List<LoiNhuan> _lst)
        {
            try
            {
                _lstLoiNhuan = _lst;
                if (_lstLoiNhuan.Count > 0)
                {
                    dgv_dsLoiNhuan.DataSource = _lstLoiNhuan;

                    KhoiTaoDataGirdView();
                    themCotSoThuTu(dgv_dsLoiNhuan);
                    dgv_dsLoiNhuan.RowPostPaint -= dgvSanPham_RowPostPaint;
                    dgv_dsLoiNhuan.RowPostPaint += dgvSanPham_RowPostPaint;
                    dgv_dsLoiNhuan.Invalidate();
                    dgv_dsLoiNhuan.Refresh();
                }
                else
                {
                    MessageBox.Show("Không có lợi nhuận nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
