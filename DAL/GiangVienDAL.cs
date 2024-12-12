using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using ClosedXML.Excel;
using System.Globalization;

namespace DAL
{
    public class GiangVienDAL
    {
        public void LoadFileGiangVien(string path, List<GiangVienDTO> lstGiangVien)
        {
            if (lstGiangVien == null)
                throw new ArgumentNullException(nameof(lstGiangVien), "Danh sách giảng viên không được để null.");

            if(String.IsNullOrEmpty(path))
            {
                return;
                //throw new ArgumentNullException("Đường dẫn không hợp lệ");
            }

            using (var workbook = new XLWorkbook(path))
            {
                var worksheet = workbook.Worksheet(1);
                DateTime ngay = DateTime.MinValue; // Biến lưu ngày hiện tại

                // Duyệt từng hàng trong sheet
                foreach (var row in worksheet.RowsUsed())
                {
                    var firstCell = row.Cell(1).Value.ToString().Trim();

                    if (IsDateCell(firstCell))
                    {
                        ngay = DateTime.Parse(firstCell);
                        continue;
                    }

                    if (int.TryParse(firstCell, out _))
                    {
                        // Nếu không phải dòng ngày, xử lý dữ liệu giảng viên
                        string tengiangvien = row.Cell(10).Value.ToString().Trim();
                        string valueTiet = row.Cell(9).Value.ToString().Trim();

                        // Bỏ qua dòng không có dữ liệu tiết học
                        if (string.IsNullOrEmpty(tengiangvien) || string.IsNullOrEmpty(valueTiet))
                            continue;

                        string[] arrTiet = valueTiet.Split(new string[] { " → " }, StringSplitOptions.None);
                        int tietbatdau = int.Parse(arrTiet[0]);
                        int tietketthuc = int.Parse(arrTiet[1]);

                        // Tìm giảng viên trong danh sách

                        GiangVienDTO gv = lstGiangVien.FirstOrDefault(t => t.TenGiangVien.Equals(tengiangvien));
                        if (gv != null)
                        {
                            // Nếu giảng viên đã tồn tại, thêm lịch dạy mới
                            gv.LichDay.Add(new LichDayDTO(ngay, tietbatdau, tietketthuc));
                        }
                        else
                        {
                            // Nếu giảng viên chưa tồn tại, tạo mới
                            LichDayDTO newld = new LichDayDTO(ngay, tietbatdau, tietketthuc);
                            GiangVienDTO newgv = new GiangVienDTO(tengiangvien);
                            newgv.LichDay.Add(newld);
                            lstGiangVien.Add(newgv);
                        }
                    }
                    else { continue; }
                }
            }
        }


        private bool IsDateCell(string cellValue)
        {
            // Kiểm tra nếu chuỗi trống hoặc null
            if (string.IsNullOrWhiteSpace(cellValue))
                return false;

            // Kiểm tra xem có phải định dạng ngày tháng hợp lệ không
            return DateTime.TryParseExact(
                cellValue,
                new[] { "dd/MM/yyyy", "MM/dd/yyyy", "yyyy-MM-dd" }, // Các định dạng ngày hợp lệ
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _);
        }

    }
}
