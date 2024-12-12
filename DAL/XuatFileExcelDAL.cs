using ClosedXML.Excel;
using DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class XuatFileExcelDAL
    {
        public string XuatFileExcel(List<GiangVienDTO> lstGiangVien, List<string> uniqueColumns, int[,] resultMatrix, List<LichThiDTO> lstLichThi, string filePath)
        {
            // Đường dẫn ảnh logo từ thư mục Images
            string logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "logo.png");

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Lich Gac Thi");

                // Thêm logo
                try
                {
                    var picture = worksheet.AddPicture(logoPath)
                        .MoveTo(worksheet.Cell(1, 1)) // Di chuyển ảnh tới ô A1
                        .Scale(0.8); // Thay đổi kích thước logo
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi thêm ảnh: " + ex.Message);
                }

                // Tạo tiêu đề lớn (mô phỏng text box bằng cách merge cells)
                worksheet.Range(1, 2, 3, 14).Merge(); // Merge ngang
                worksheet.Cell(1, 2).Value = "BỘ CÔNG THƯƠNG\nTRƯỜNG ĐẠI HỌC CÔNG THƯƠNG TP. HCM";
                worksheet.Cell(1, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                    .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                    .Alignment.SetWrapText(true) // Xuống dòng tự động
                    .Font.SetBold(true)
                    .Font.FontSize = 18; // Chỉnh kích thước font


                // Định dạng tiêu đề để không bị đè
                worksheet.Row(1).Height = 35; // Tăng chiều cao hàng
                worksheet.Row(2).Height = 35;


                worksheet.Cell(10, 1).Value = "Ngày thi";
                // Tăng chiều cao hàng cho tiêu đề "Ngày thi"
                worksheet.Row(10).Height = 30; // Đặt chiều cao hàng 10 thành 30
                worksheet.Cell(10, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                    .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                    .Font.SetBold(true)
                    .Border.SetOutsideBorder(XLBorderStyleValues.Thin);
                worksheet.Cell(11, 1).Value = "Thứ";
                worksheet.Row(11).Height = 20;// Đặt chiều cao hàng "Thứ" 
                worksheet.Cell(12, 1).Value = "Tiết";
                worksheet.Cell(13, 1).Value = "Số ca gác thi cần cấp";
                worksheet.Cell(14, 1).Value = "Số ca gác thi đã cấp";
                worksheet.Cell(15, 1).Value = "Số ca gác thi chưa cấp";
                // Định dạng tiêu đề hàng dọc và thêm border
                for (int i = 10; i <= 15; i++)
                {
                    worksheet.Cell(i, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Font.SetBold(true)
                        .Border.SetOutsideBorder(XLBorderStyleValues.Thin);
                    worksheet.Cell(i, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Font.SetBold(true)
                        .Border.SetOutsideBorder(XLBorderStyleValues.Thin);
                }

                int startCol = 3;
                string previousDate = "";
                int mergeStartCol = startCol;

                int tongCaCanCap = lstLichThi.Sum(t=>t.SoGVCanCap);
                int tongCaDaCap = 0;
                int tongCaChuaCap = 0;


                for (int i = 0; i < uniqueColumns.Count; i++)
                {
                    string[] parts = uniqueColumns[i].Split(' ');
                    string dateString = parts[0];
                    string tietString = parts[1];

                    DateTime date = DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    string thu = date.ToString("dddd", new CultureInfo("vi-VN"));

                    worksheet.Cell(10, startCol + i).Value = date.ToString("dd/MM/yyyy");
                    worksheet.Cell(11, startCol + i).Value = thu;
                    worksheet.Cell(12, startCol + i).Value = tietString;

                    if (dateString == previousDate)
                    {
                        worksheet.Range(10, mergeStartCol, 10, startCol + i).Merge();
                        worksheet.Range(11, mergeStartCol, 11, startCol + i).Merge();
                    }
                    else
                    {
                        mergeStartCol = startCol + i;
                        previousDate = dateString;
                    }

                    worksheet.Cell(10, startCol + i).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Border.SetOutsideBorder(XLBorderStyleValues.Thin);
                    worksheet.Cell(11, startCol + i).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Border.SetOutsideBorder(XLBorderStyleValues.Thin);
                    worksheet.Cell(12, startCol + i).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                    var lichThi = lstLichThi.FirstOrDefault(lt => lt.Ngay == date && string.Format("{0}-{1}", lt.TietBatDau, lt.TietKetThuc) == tietString);
                    int soCaCanCap = lichThi?.SoGVCanCap ?? 0;

                    worksheet.Cell(13, startCol + i).Value = soCaCanCap;

                    int soCaDaCap = 0;
                    for (int j = 0; j < lstGiangVien.Count; j++)
                    {
                        if (resultMatrix[j, i] == 1)
                        {
                            soCaDaCap++;
                        }
                    }
                    int soCaChuaCap = soCaCanCap - soCaDaCap;

                    worksheet.Cell(14, startCol + i).Value = soCaDaCap;
                    worksheet.Cell(15, startCol + i).Value = Math.Abs(soCaChuaCap);

                    tongCaDaCap += soCaDaCap;
                    tongCaChuaCap += soCaChuaCap;
                    // Căn giữa và thêm border cho các dữ liệu cột
                    for (int k = 13; k <= 15; k++)
                    {
                        worksheet.Cell(k, startCol + i).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                            .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                            .Border.SetOutsideBorder(XLBorderStyleValues.Thin);
                    }
                }
                worksheet.Cell(13, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                       .Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                worksheet.Cell(14, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                worksheet.Cell(15, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                worksheet.Cell(13, 2).Value = tongCaCanCap;
                worksheet.Cell(14, 2).Value = tongCaDaCap;
                worksheet.Cell(15, 2).Value = tongCaChuaCap;

                // Tăng chiều rộng cột sau khi thiết lập các tiêu đề cột
                for (int col = 2; col <= uniqueColumns.Count + 1; col++) // Bắt đầu từ cột 2 (Cột đầu tiên là "Ngày thi")
                {
                    worksheet.Column(col).Width = 9; // Tăng chiều rộng cột
                }
                // Đặt chiều rộng cho cột A
                worksheet.Column(1).Width = 25; // Đặt chiều rộng đủ lớn cho nội dung


                // Dữ liệu giảng viên bắt đầu từ hàng 17
                int startRow = 17;
                for (int i = 0; i < lstGiangVien.Count; i++)
                {
                    int Tonglichgac = lstGiangVien[i].LichGacThi.Count();
                    worksheet.Cell(startRow + i, 2).Value = Tonglichgac;
                    worksheet.Cell(startRow + i, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Border.SetOutsideBorder(XLBorderStyleValues.Thin);
                    worksheet.Cell(startRow + i, 1).Value = lstGiangVien[i].TenGiangVien;
                    worksheet.Cell(startRow + i, 1).Style
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                    for (int j = 0; j < uniqueColumns.Count; j++)
                    {
                        worksheet.Cell(startRow + i, startCol + j).Value = resultMatrix[i, j] == 1 ? "X" : "";
                        worksheet.Cell(startRow + i, startCol + j).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                            .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                            .Border.SetOutsideBorder(XLBorderStyleValues.Thin);
                    }


                }
                workbook.SaveAs(filePath);

                return filePath;
            }
        }

    }
}
