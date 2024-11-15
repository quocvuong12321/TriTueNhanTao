using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using ClosedXML.Excel;
namespace DAL
{
    public class GiangVienDAL
    {
        public List<GiangVienDTO> LoadFileGiangVien(string path)
        {
            List<GiangVienDTO> lstGiangVien = new List<GiangVienDTO>();
            using (var workbook = new XLWorkbook(path))
            {
                var worksheet = workbook.Worksheet(1);
                for(int i = 9; i <= worksheet.RowsUsed().Count();i++)
                {
                    var row = worksheet.Row(i);
                    string tengiangvien = row.Cell(10).Value.ToString();
                    DateTime ngay = DateTime.Parse(worksheet.Row(8).Cell(1).Value.ToString());
                    string valueTiet = row.Cell(9).Value.ToString();
                    string[] arrTiet = valueTiet.Split(new string[] { " → " }, StringSplitOptions.None);
                    int tietbatdau = int.Parse(arrTiet[0]);
                    int tietketthuc = int.Parse(arrTiet[1]);
                    GiangVienDTO gv = lstGiangVien.FirstOrDefault(t => t.TenGiangVien.Equals(tengiangvien));
                    if(gv!= null)
                    {
                        gv.LichDay.Add(new LichDayDTO(ngay, tietbatdau, tietketthuc));
                    }
                    else
                    {
                        LichDayDTO newld = new LichDayDTO(ngay, tietbatdau, tietketthuc);
                        GiangVienDTO newgv = new GiangVienDTO(tengiangvien);
                        newgv.LichDay.Add(newld);
                        lstGiangVien.Add(newgv);
                    }
                }
            }
            return lstGiangVien;
        }
    }
}
