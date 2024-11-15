using ClosedXML.Excel;
using DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class XuatFileExcelDAL
    {
        public string XuatFileExcel(List<GiangVienDTO> lstGiangVien, List<string> uniqueColumns, int[,] resultMatrix, List<LichThiDTO> lstLichThi, string filePath)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Lich Gac Thi");

                worksheet.Cell(1, 1).Value = "BỘ CÔNG THƯƠNG";
                worksheet.Cell(2, 1).Value = "TRƯỜNG ĐẠI HỌC CÔNG THƯƠNG TP. HCM";

                worksheet.Cell(4, 1).Value = "Ngày thi";
                worksheet.Cell(5, 1).Value = "Thứ";
                worksheet.Cell(6, 1).Value = "Tiết";
                worksheet.Cell(7, 1).Value = "Số ca gác thi cần cấp";
                worksheet.Cell(8, 1).Value = "Số ca gác thi đã cấp";
                worksheet.Cell(9, 1).Value = "Số ca gác thi chưa cấp";

                int startCol = 2;
                string previousDate = "";
                int mergeStartCol = startCol;

                for (int i = 0; i < uniqueColumns.Count; i++)
                {
                    string[] parts = uniqueColumns[i].Split(' ');
                    string dateString = parts[0];
                    string tietString = parts[1];

                    DateTime date = DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    string thu = date.ToString("dddd", new CultureInfo("vi-VN"));

                    worksheet.Cell(4, startCol + i).Value = date.ToString("dd/MM/yyyy");
                    worksheet.Cell(5, startCol + i).Value = thu;
                    worksheet.Cell(6, startCol + i).Value = tietString;

                    if (dateString == previousDate)
                    {
                        worksheet.Range(4, mergeStartCol, 4, startCol + i).Merge();
                        worksheet.Range(5, mergeStartCol, 5, startCol + i).Merge();
                    }
                    else
                    {
                        mergeStartCol = startCol + i;
                        previousDate = dateString;
                    }

                    // Tìm số ca gác thi cần cấp từ danh sách lstLichThi dựa trên ngày và tiết
                    var lichThi = lstLichThi.FirstOrDefault(lt => lt.Ngay == date && $"{lt.TietBatDau}-{lt.TietKetThuc}" == tietString);
                    int soCaCanCap = lichThi?.SoGVCanCap ?? 0;

                    worksheet.Cell(7, startCol + i).Value = soCaCanCap;

                    // Tính toán số ca gác thi đã cấp và chưa cấp
                    int soCaDaCap = 0;
                    for (int j = 0; j < lstGiangVien.Count; j++)
                    {
                        if (resultMatrix[j, i] == 1)
                        {
                            soCaDaCap++;
                        }
                    }
                    int soCaChuaCap = soCaCanCap - soCaDaCap;

                    worksheet.Cell(8, startCol + i).Value = soCaDaCap;
                    worksheet.Cell(9, startCol + i).Value = soCaChuaCap;
                }

                // Đổ dữ liệu giảng viên và lịch gác thi vào các hàng
                int startRow = 10;
                for (int i = 0; i < lstGiangVien.Count; i++)
                {
                    worksheet.Cell(startRow + i, 1).Value = lstGiangVien[i].TenGiangVien;
                    for (int j = 0; j < uniqueColumns.Count; j++)
                    {
                        worksheet.Cell(startRow + i, startCol + j).Value = resultMatrix[i, j] == 1 ? "X" : "";
                    }
                }

                // Định dạng bảng
                worksheet.Columns().AdjustToContents();

                workbook.SaveAs(filePath);

                return filePath;
            }
        }





    }
}
