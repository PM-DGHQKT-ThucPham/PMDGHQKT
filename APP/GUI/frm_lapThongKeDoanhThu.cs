﻿using System;
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
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.SpreadsheetSource;
using DevExpress.XtraReports.Parameters.Native;
using System.IO;
using Syncfusion.XlsIO;

namespace GUI
{
    public partial class frm_lapThongKeDoanhThu : Form
    {
        // Khai báo biến toàn cục

        private LoaiDoanhThuBLL _loaiDoanhThuBLL = new LoaiDoanhThuBLL();
        private DoanhThuBLL _doanhThuBLL = new DoanhThuBLL();
        private List<LoaiDoanhThu> _lstLoaiDoanhThu = null;
        private List<DoanhThu> _lstDoanhThu = null;
        private SanPhamBLL _sanPhamBLL = new SanPhamBLL();
        List<SanPham> _lstSanPham = new List<SanPham>();
        string maSanPham = string.Empty;
        public frm_lapThongKeDoanhThu()
        {
            InitializeComponent();
            this.Load += Frm_lapThongKeDoanhThu_Load;
        }

        private void Frm_lapThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            LoadComboBoxSanPham();
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
            btnReport.Click += BtnReport_Click;
            //hiển thị dtp ngày tháng năm
            dtp_ngayBatDau.Format = DateTimePickerFormat.Custom;
            dtp_ngayBatDau.CustomFormat = "MM/yyyy";
            dtp_ngayKetThuc.Format = DateTimePickerFormat.Custom;
            dtp_ngayKetThuc.CustomFormat = "MM/yyyy";
            var data = _doanhThuBLL.TinhTiLeTangTruongTheoLoai(maSanPham); // Lấy dữ liệu doanh thu theo loại
            HienThiBieuDo3LoaiDoanhThu(chart_doanhThuDuong, data); // Hiển thị lên biểu đồ

        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            try
            {
                //Lấy danh sách PHIEUBAOCAO từ DataGridView
                List<PHIEUBAOCAO> dsPBC = new List<PHIEUBAOCAO>();
                if (dgv_dsDoanhThu.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgv_dsDoanhThu.Rows)
                    {
                        PHIEUBAOCAO pbc = new PHIEUBAOCAO();
                        pbc.STT = row.Cells["SoThuTu"].Value.ToString();
                        pbc.MADOANHTHU = row.Cells["MaDoanhThu"].Value.ToString();
                        pbc.MALOAIDOANHTHU = row.Cells["MaLoaiDoanhThu"].Value.ToString();
                        pbc.MOTA = row.Cells["MoTa"].Value.ToString();
                        pbc.SOTIEN = decimal.Parse(row.Cells["SoTien"].Value.ToString());
                        pbc.NGAY = DateTime.Parse(row.Cells["ThoiGian"].Value.ToString());
                        dsPBC.Add(pbc);
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để xuất báo cáo");
                    return;
                }
                //Create replacer
                Dictionary<string, string> replacer = new Dictionary<string, string>();
                string ngay = "Ngày" + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                //Lấy ngày bắt đầu bằng giá trị ngày nhỏ nhát của dsPBC
                DateTime ngayBatDau = dsPBC.Min(x => x.NGAY);
                //Lấy ngày bắt đầu bằng giá trị lớn nhất của dsPBC
                DateTime ngayKetThuc = dsPBC.Max(x => x.NGAY);
                replacer.Add("%NgayBatDau", ngayBatDau.ToString());
                replacer.Add("%NgayKetThuc", ngayKetThuc.ToString());
                replacer.Add("%NgayThangNam", ngay);
                decimal tongTien = 0;
                foreach (PHIEUBAOCAO item in dsPBC)
                {
                    tongTien += item.SOTIEN;
                }
                replacer.Add("%TongTien", String.Format("{0:0,0} VNĐ", tongTien));

                MemoryStream stream = null;
                byte[] arrByte = new byte[0];
                arrByte = File.ReadAllBytes("PhieuBaoCao.xlsx").ToArray();
                //Get stream
                if (arrByte.Count() > 0)
                {
                    stream = new MemoryStream(arrByte);
                }
                //Create Excel Engine
                ExcelEngine engine = new ExcelEngine();
                IWorkbook workBook = engine.Excel.Workbooks.Open(stream);
                Syncfusion.XlsIO.IWorksheet workSheet = workBook.Worksheets[0];
                ITemplateMarkersProcessor markProcessor = workSheet.CreateTemplateMarkersProcessor();
                //Replace value
                if (replacer != null && replacer.Count > 0)
                {
                    foreach (KeyValuePair<string, string> repl in replacer)
                    {
                        Replace(workSheet, repl.Key, repl.Value);
                    }
                }
                string viewName = "PhieuBaoCao";
                markProcessor.AddVariable(viewName, dsPBC);
                markProcessor.ApplyMarkers(UnknownVariableAction.ReplaceBlank);
                ////Xóa bỏ dòng đánh dấu [TMP]
                Syncfusion.XlsIO.IRange range = workSheet.FindFirst("[TMP]", ExcelFindType.Text);
                if (range != null)
                {
                    workSheet.DeleteRow(range.Row);
                }
                string fileName = "PhieuBaoCao_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
                //workBook.SaveAs(fileName);
                //Thay vì lưu fileName mặc định thì mở file Dialog lưu vào vị trí mong muốn
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveFileDialog.FileName = fileName;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workBook.SaveAs(saveFileDialog.FileName);
                }


                //Close
                workBook.Close();
                engine.Dispose();
                MessageBox.Show("Xuất xong");
                if (!string.IsNullOrEmpty(fileName) && MessageBox.Show("Bạn có muốn mở file không  ?", "Thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    //Mở fileName bằng đường mà workBook.SaveAs(saveFileDialog.FileName) đã lưu
                    System.Diagnostics.Process.Start(saveFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        private void Replace(Syncfusion.XlsIO.IWorksheet workSheet, string p1, string p2)
        {
            workSheet.Replace(p1, p2);
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
        private void Cbo_sanPham_SelectedValueChanged(object sender, EventArgs e)
        {
            maSanPham = cbo_sanPham.SelectedValue.ToString();
            LoadLaiTrang();
        }


        // viết hàm xử lý ở đây
        public void HienThiBieuDo3LoaiDoanhThu(Chart chart, List<(DateTime Thang, string LoaiDoanhThu, decimal DoanhThu, decimal TiLeTangTruong)> data)
        {
            // Xóa dữ liệu cũ trên biểu đồ
            chart.Series.Clear();
            chart.ChartAreas.Clear();

            // Thêm một khu vực biểu đồ
            chart.ChartAreas.Add(new ChartArea("TiLeTangTruong"));

            // Lấy danh sách các loại doanh thu (Trực tuyến, Trực tiếp, Nhà phân phối)
            var loaiDoanhThu = data.Select(d => d.LoaiDoanhThu).Distinct().ToList();

            // Lặp qua từng loại doanh thu
            foreach (var loai in loaiDoanhThu)
            {
                // Tạo Series mới cho loại doanh thu
                var series = new Series(loai)
                {
                    ChartType = SeriesChartType.Line, // Biểu đồ đường
                    BorderWidth = 2, // Độ rộng đường
                    IsValueShownAsLabel = true // Hiển thị giá trị trên điểm
                };

                // Lấy dữ liệu của loại doanh thu này
                var dataTheoLoai = data.Where(d => d.LoaiDoanhThu == loai).OrderBy(d => d.Thang).ToList();

                // Thêm dữ liệu vào Series
                foreach (var item in dataTheoLoai)
                {
                    series.Points.AddXY(item.Thang.ToString("MM/yyyy"), item.TiLeTangTruong); // Hiển thị tỷ lệ tăng trưởng
                }

                // Thêm Series vào biểu đồ
                chart.Series.Add(series);
            }

            // Tùy chỉnh trục X và Y
            var chartArea = chart.ChartAreas["TiLeTangTruong"];
            chartArea.AxisX.Title = "Tháng";
            chartArea.AxisY.Title = "Tỷ lệ tăng trưởng (%)";
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.LabelStyle.Angle = -45; // Xoay nhãn trục X
            chartArea.AxisY.LabelStyle.Format = "0.##"; // Định dạng số trên trục Y
        }


        //load lại trang
        private void LoadLaiTrang()
        {
            _lstDoanhThu = new List<DoanhThu>();
            _lstDoanhThu = _doanhThuBLL.LayDanhSachDoanhThu(maSanPham);
            HienThiDanhSachDoanhThu(_lstDoanhThu);
            HienThiDoanhThuTheoLoaiDoanhThu(_lstDoanhThu);
            LoadComboboxLoaiDoanhThu();
            HienThiBieuDo3LoaiDoanhThu(chart_doanhThuDuong, _doanhThuBLL.TinhTiLeTangTruongTheoLoai(maSanPham));
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
                    maSanPham = _lstSanPham.FirstOrDefault()?.MaSanPham.ToString();

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
        // Hiển thị doanh thu theo loại doanh thu lên biểu đồ Pie
        private void HienThiDoanhThuTheoLoaiDoanhThu(List<DoanhThu> _lstDoanhThu)
        {
            // Xóa dữ liệu cũ
            chart_doanhThu.Series.Clear();
            chart_doanhThu.Titles.Clear();
            chart_doanhThu.ChartAreas[0].RecalculateAxesScale();

            // Gắn nhãn cho biểu đồ
            chart_doanhThu.Titles.Add("Doanh thu theo loại doanh thu");
            // tăng kích thước chữ
            chart_doanhThu.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);

            // Tính toán tổng doanh thu theo loại
            var doanhThuTheoLoai = _lstDoanhThu
                .GroupBy(x => x.LoaiDoanhThu.TenLoaiDoanhThu)
                .Select(group => new { Loai = group.Key, TongDoanhThu = group.Sum(x => x.SoTien ?? 0) })
                .ToList();
            decimal tongTien = _lstDoanhThu.Sum(x => x.SoTien ?? 0);
            txt_tongTien.Text = $"Tổng tiền: {tongTien:N0} VNĐ";
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

            decimal tongTien = _lstDoanhThu.Sum(x => x.SoTien ?? 0);
            txt_tongTien.Text = $"Tổng tiền: {tongTien:N0} VNĐ";

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
            dgv_dsDoanhThu.Columns["ThoiGian"].DefaultCellStyle.Format = "MM/yyyy";

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
            // tiền căn phải 
            dgv_dsDoanhThu.Columns["SoTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // Căn phải
            //ẩn các cột không can thiệp
            dgv_dsDoanhThu.Columns["LoaiDoanhThu"].Visible = false;
        }
        private void HienThiDanhSachDoanhThu(List<DoanhThu> lstDoanhThu)
        {
            try
            {
                dgv_dsDoanhThu.DataSource = null;
                _lstDoanhThu = lstDoanhThu;

                if (_lstDoanhThu != null && _lstDoanhThu.Count > 0)
                {
                    dgv_dsDoanhThu.DataSource = _lstDoanhThu;
                    KhoiTaoDgvDoanhThu();
                    themCotSoThuTu(dgv_dsDoanhThu);

                    // Gán sự kiện RowPostPaint để thêm số thứ tự
                    dgv_dsDoanhThu.RowPostPaint -= dgvSanPham_RowPostPaint;
                    dgv_dsDoanhThu.RowPostPaint += dgvSanPham_RowPostPaint;

                    // Tính tổng số tiền
                    decimal tongTien = _lstDoanhThu.Sum(x => x.SoTien ?? 0);
                    txt_tongTien.Text = $"Tổng tiền: {tongTien:N0} VNĐ";

                    // Xác định tháng và năm có doanh thu cao nhất
                    var doanhThuCaoNhat = _lstDoanhThu.OrderByDescending(x => x.SoTien).FirstOrDefault();
                    if (doanhThuCaoNhat != null && doanhThuCaoNhat.ThoiGian.HasValue)
                    {
                        // Lấy tháng và năm có doanh thu cao nhất
                        int thangCaoNhat = doanhThuCaoNhat.ThoiGian.Value.Month;
                        int namCaoNhat = doanhThuCaoNhat.ThoiGian.Value.Year;

                        // Lưu thông tin tháng và năm vào Tag của DataGridView
                        dgv_dsDoanhThu.Tag = new { Thang = thangCaoNhat, Nam = namCaoNhat };

                        // Gán sự kiện CellFormatting để tô màu dòng
                        dgv_dsDoanhThu.CellFormatting -= Dgv_dsDoanhThu_CellFormatting;
                        dgv_dsDoanhThu.CellFormatting += Dgv_dsDoanhThu_CellFormatting;
                    }

                    dgv_dsDoanhThu.Invalidate();
                    dgv_dsDoanhThu.Refresh();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void Dgv_dsDoanhThu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && dgv_dsDoanhThu.Rows[e.RowIndex].DataBoundItem is DoanhThu doanhThu)
                {
                    // Lấy thông tin tháng và năm có doanh thu cao nhất từ Tag
                    var thangNamCaoNhat = dgv_dsDoanhThu.Tag as dynamic;
                    if (thangNamCaoNhat != null)
                    {
                        int thangCaoNhat = thangNamCaoNhat.Thang;
                        int namCaoNhat = thangNamCaoNhat.Nam;

                        // Kiểm tra nếu tháng và năm hiện tại trong dòng là tháng và năm có doanh thu cao nhất
                        if (doanhThu.ThoiGian.HasValue)
                        {
                            DateTime thoiGian = doanhThu.ThoiGian.Value;
                            if (thoiGian.Month == thangCaoNhat && thoiGian.Year == namCaoNhat)
                            {
                                dgv_dsDoanhThu.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Blue;
                                dgv_dsDoanhThu.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                            }
                            else
                            {
                                dgv_dsDoanhThu.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                                dgv_dsDoanhThu.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
