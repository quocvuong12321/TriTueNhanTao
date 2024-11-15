using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using DTO;
namespace DAL
{
    public class LichThiDAL
    {
        public List<LichThiDTO> DocFileLichThi(string path) {
            List<LichThiDTO> lstLichThi = new List<LichThiDTO>();
            using(var workbook = new XLWorkbook(path))
            {
                var worksheet = workbook.Worksheet(1);
                for (int colIndex = 5; colIndex <= worksheet.ColumnsUsed().Count()+2; colIndex++)
                {

                    var column = worksheet.Column(colIndex);
                    int ngayThi = int.Parse(column.Cell(3).Value.ToString());
                    DateTime NgayThi;
                    //string valueNgayThi = worksheet.Cell(column.Cell(2).Address).Value.ToString();
                    if (ngayThi == 1)
                    {
                        NgayThi = new DateTime(2004,11,04);
                    }
                    else
                    {
                        NgayThi = new DateTime(2004, 11, 04).AddDays(ngayThi-1);
                    }
                    string tiet = column.Cell(4).Value.ToString();
                    string[] tietRange = tiet.Split(new string[] { " → " }, StringSplitOptions.None);
                    int tietBatDau = int.Parse(tietRange[0]);
                    int tietKetThuc = int.Parse(tietRange[1]);
                    int soGVCanCap = int.Parse(column.Cell(5).Value.ToString());
                    LichThiDTO lt = new LichThiDTO(NgayThi, tietBatDau, tietKetThuc, soGVCanCap);
                    lstLichThi.Add(lt);
                }
            }
            return lstLichThi;
        }
    }
}
