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
                for (int i = 10; i <= worksheet.RowsUsed().Count(); i++)
                {
                    int j = 5;
                    var row = worksheet.Row(i);
                    string tengiangvien = row.Cell(2).Value.ToString();
                    var rowtiet = worksheet.Row(6);
                    GiangVienDTO gv = new GiangVienDTO(tengiangvien);
                    int count = row.Cells().Count();
                    while (j <= count)
                    {
                        if (rowtiet.Cell(j).Value.ToString() == "end")
                            break;
                        if (row.Cell(j).Value.ToString() == "x")
                        {
                            DateTime lastDate = new DateTime();
                            string getvaluelastdate;

                            var mergedRange = worksheet.MergedRanges.FirstOrDefault(r => r.Contains(rowtiet.Cell(j).Address.ToString()));

                            if (mergedRange != null)
                            {
                                getvaluelastdate = mergedRange.FirstCell().GetValue<string>();
                            }
                            else
                            {
                                getvaluelastdate = rowtiet.Cell(j).GetValue<string>();
                            }

                            if (!string.IsNullOrEmpty(getvaluelastdate))
                            {
                                //lastDate = DateTime.Parse(getvaluelastdate);
                                lastDate = Convert.ToDateTime(getvaluelastdate);

                            }
                            string valueTiet = worksheet.Row(8).Cell(j).Value.ToString();
                            string[] arrTiet = valueTiet.Split(new string[] { "→" }, StringSplitOptions.None);
                            int tietbatdau = int.Parse(arrTiet[0]);
                            int tietketthuc = int.Parse(arrTiet[1]);
                            LichDayDTO ld = new LichDayDTO(lastDate, tietbatdau, tietketthuc);
                            gv.LichDay.Add(ld);
                        }
                        j++;
                    }
                    lstGiangVien.Add(gv);
                }
            }
            return lstGiangVien;
        }
    }
}
