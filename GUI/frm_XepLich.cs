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
using BLL;
namespace GUI
{
    public partial class frm_XepLich : Form
    {
        GiangVienBLL gvBLL = new GiangVienBLL();
        XepLichBLL xlBLL = new XepLichBLL();
        LichThiBLL ltBLL = new LichThiBLL();
        public List<LichThiDTO> lstLichThi;
        public List<GiangVienDTO> lstGiangVien;

        public frm_XepLich()
        {
            InitializeComponent();
            lstLichThi = new List<LichThiDTO>();

        }

        private void frm_XepLich_Load(object sender, EventArgs e)
        {

        }

        private string DocFileDialog(OpenFileDialog open)
        {
            string filePath;
            open = new OpenFileDialog();
            open.Filter = "Excel Files (*.xlsx;*.xls)|*.xlsx;*.xls|All Files (*.*)|*.*"; // Lọc theo loại file
            open.Title = "Chọn một file excel";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn của file đã chọn
                filePath = open.FileName;
                // Nếu cần sử dụng đường dẫn này trong ứng dụng, bạn có thể gán nó vào một biến hoặc xử lý
                // Ví dụ: Đọc file Excel hoặc lưu trữ nó
                return filePath;
            }
            return "";
        }

        private void btn_LoadLichThi_Click(object sender, EventArgs e)
        {
            string path = DocFileDialog(ofd_DocFile);
            txt_Path.Clear();
            txt_Path.Text = path;
            lstLichThi = ltBLL.DocFileLichThi(path);
            dgv_XepLich.DataSource = null;
            dgv_XepLich.DataSource = lstLichThi;
            MessageBox.Show("Thành công");

        }

        private void btn_LoadGiangVien_Click(object sender, EventArgs e)
        {
            lstGiangVien = new List<GiangVienDTO>()
            {
                new GiangVienDTO("Phùng Thế Bảo", new List<LichDayDTO> { new LichDayDTO(new DateTime(2024, 11, 05), 1, 3) }),
                new GiangVienDTO("Ngô Dương Hà", new List<LichDayDTO> { new LichDayDTO(new DateTime(2024, 11, 04), 7, 11) }),
                new GiangVienDTO("Lê Hồng Sơn", new List<LichDayDTO> { new LichDayDTO(new DateTime(2024, 11, 06), 4, 6), new LichDayDTO(new DateTime(2024, 11, 06), 7, 9) }),
                new GiangVienDTO("Trần Thị Mai", new List<LichDayDTO> { new LichDayDTO(new DateTime(2024, 11, 05), 1, 5), new LichDayDTO(new DateTime(2024, 11, 08), 7, 9) }),
                new GiangVienDTO("Nguyễn Văn An", new List<LichDayDTO> { new LichDayDTO(new DateTime(2024, 11, 04), 1, 5), new LichDayDTO(new DateTime(2024, 11, 06), 4, 6) }),
                new GiangVienDTO("Phạm Thị Bình", new List<LichDayDTO> { new LichDayDTO(new DateTime(2024, 11, 05), 1, 3), new LichDayDTO(new DateTime(2024, 11, 09), 7, 9) }),
                new GiangVienDTO("Đỗ Minh Hòa", new List<LichDayDTO> { new LichDayDTO(new DateTime(2024, 11, 06), 7, 11), new LichDayDTO(new DateTime(2024, 11, 08), 1, 3) }),
                 new GiangVienDTO("Vũ Khắc Minh", new List<LichDayDTO> { new LichDayDTO(new DateTime(2024, 11, 07), 1, 3), new LichDayDTO(new DateTime(2024, 11, 05), 7, 9) }),
                 new GiangVienDTO("Trần Thanh Tâm", new List<LichDayDTO> { new LichDayDTO(new DateTime(2024, 11, 08), 1, 5), new LichDayDTO(new DateTime(2024, 11, 06), 10, 12) }),
                 new GiangVienDTO("Bùi Thị Lan", new List<LichDayDTO> { new LichDayDTO(new DateTime(2024, 11, 04), 7, 11), new LichDayDTO(new DateTime(2024, 11, 06), 1, 3) })
             };

            MessageBox.Show("Thành công");

            //string path = DocFileDialog(ofd_DocFile);
            //txt_Path.Clear();
            //txt_Path.Text = path;
            //lstGiangVien = gvBLL.LoadFileGiangVien(path);
            //dgv_XepLich.DataSource = null;
            //dgv_XepLich.DataSource = lstGiangVien;
        }

        private void btn_XepLich_Click(object sender, EventArgs e)
        {
            
            List<LichThiXepResult> lstKqXep = xlBLL.xepLichGacThi(lstLichThi, lstGiangVien);
            int[,] ketquaxep = xlBLL.chuyenDoiXepLichSangMang(lstKqXep, lstGiangVien);
            List<string> Uniquecolumns = lstKqXep.
                OrderBy(t => t.LichThi.Ngay).ThenBy(t => t.LichThi.TietBatDau).
                Select(kq => string.Format("{0:dd/MM/yy} {1}-{2}", kq.LichThi.Ngay, kq.LichThi.TietBatDau, kq.LichThi.TietKetThuc)).
                Distinct().
                ToList();

            dgv_XepLich.DataSource = null;

            HienThiLichThiTrenDataGridView(dgv_XepLich, ketquaxep, lstGiangVien, Uniquecolumns);

        }

        public void HienThiLichThiTrenDataGridView(DataGridView dgv, int[,] resultMatrix, List<GiangVienDTO> LstGiangVien, List<string> uniqueColumns)
        {
            // 1. Xóa các cột và hàng cũ (nếu có)
            dgv.Columns.Clear();
            dgv.Rows.Clear();

            // 2. Thêm cột vào DataGridView với các tiêu đề là cặp Ngày - Tiết Bắt Đầu - Tiết Kết Thúc
            dgv.Columns.Add("GiangVien", "Giảng Viên"); // Cột đầu tiên là Tên giảng viên
            foreach (var columnTitle in uniqueColumns)
            {
                dgv.Columns.Add(columnTitle, columnTitle);
            }

            // 3. Thêm dữ liệu cho từng giảng viên vào từng hàng
            for (int i = 0; i < LstGiangVien.Count; i++)
            {
                // Tạo hàng mới cho giảng viên
                var row = new DataGridViewRow();
                row.CreateCells(dgv);

                // Điền tên giảng viên vào ô đầu tiên của hàng
                row.Cells[0].Value = LstGiangVien[i].TenGiangVien;

                // Điền dữ liệu vào các cột lịch thi
                for (int j = 0; j < uniqueColumns.Count; j++)
                {
                    row.Cells[j + 1].Value = resultMatrix[i, j] == 1 ? "X" : ""; // Đánh "X" nếu có lịch gác, ngược lại để trống
                }

                // Thêm hàng vào DataGridView
                dgv.Rows.Add(row);
            }
        }
    }
}