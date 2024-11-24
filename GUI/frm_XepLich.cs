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
    public partial class frm_XepLich : Form
    {
        XepLichBLL xlBLL = new XepLichBLL();
        LichThiBLL ltBLL = new LichThiBLL();
        GiangVienBLL gvBLL = new GiangVienBLL();
        public List<LichThiDTO> lstLichThi;
        public List<GiangVienDTO> lstGiangVien;


        private List<string> Uniquecolumns;
        private int[,] ketquaxep;

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
            string path = DocFileDialog(ofd_DocFile);
            txt_Path.Clear();
            txt_Path.Text = path;
            lstGiangVien = gvBLL.LoadFileGiangVien(path);
            dgv_XepLich.DataSource = null;
            dgv_XepLich.DataSource = lstGiangVien;
            MessageBox.Show("Thành công");
        }

        private void btn_XepLich_Click(object sender, EventArgs e)
        {
            List<LichThiDTO> dsLichThi = lstLichThi
                .Select(lich => new LichThiDTO(lich.Ngay, lich.TietBatDau, lich.TietKetThuc, lich.SoGVCanCap))
                .ToList(); 
            List<LichThiXepResult> lstKqXep = xlBLL.xepLichGacThi(dsLichThi, lstGiangVien);
            ketquaxep = xlBLL.chuyenDoiXepLichSangMang(lstKqXep, lstGiangVien);
            Uniquecolumns = lstKqXep.
                OrderBy(t => t.LichThi.Ngay).ThenBy(t => t.LichThi.TietBatDau).
                Select(kq => string.Format("{0:dd/MM/yyyy} {1}-{2}", kq.LichThi.Ngay, kq.LichThi.TietBatDau, kq.LichThi.TietKetThuc)).
                Distinct().
                ToList();

            dgv_XepLich.DataSource = null;
            HienThiLichThiTrenDataGridView(dgv_XepLich, ketquaxep, lstGiangVien, Uniquecolumns);

            txt_Diem.Clear();
            txt_Diem.Text = XepLichBLL.DanhGiaLichThi(lstKqXep).ToString() + " Điểm";

            if(xlBLL.LayDanhSachLichChuaXep().Count() > 0)
            {
                MessageBox.Show("Xếp lịch thành công, còn "+ xlBLL.LayDanhSachLichChuaXep().Count().ToString()+ " lịch chưa xếp được");
            }
            else
            {
                MessageBox.Show("Xếp lịch thành công");
            }
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

        private void btn_XuatFileExcell_Click(object sender, EventArgs e)
        {
            if (Uniquecolumns == null || ketquaxep == null)
            {
                MessageBox.Show("Vui lòng xếp lịch trước khi xuất file Excel.");
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Chọn nơi lưu file";
                saveFileDialog.FileName = "LichGacThi.xlsx"; // Tên mặc định

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    XuatFileExcelBLL xuatFileBLL = new XuatFileExcelBLL();
                    xuatFileBLL.XuatFileExcel(lstGiangVien, Uniquecolumns, ketquaxep, lstLichThi, filePath);

                    MessageBox.Show($"Đã xuất file Excel thành công tại {filePath}");
                }
            }
        }
    }
}
