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
        public List<LichThiDTO> DocFileLichThi(string path)
        {
            List<LichThiDTO> lstLichThi = new List<LichThiDTO>();
            using (var workbook = new XLWorkbook(path))
            {
                var worksheet = workbook.Worksheet(1);
                for (int colIndex = 5; colIndex <= worksheet.ColumnsUsed().Count() ; colIndex++)
                {

                    var column = worksheet.Column(colIndex);
                    DateTime lastDate = new DateTime();
                    string getvaluelastdate;

                    var mergedRange = worksheet.MergedRanges.FirstOrDefault(r => r.Contains(column.Cell(6).Address.ToString()));

                    if (mergedRange != null)
                    {
                        getvaluelastdate = mergedRange.FirstCell().GetValue<string>();
                    }
                    else
                    {
                        getvaluelastdate = column.Cell(6).GetValue<string>();
                    }

                    if (!string.IsNullOrEmpty(getvaluelastdate))
                    {
                        lastDate = DateTime.Parse(getvaluelastdate);
                    }
                    string tiet = column.Cell(8).Value.ToString();
                    string[] tietRange = tiet.Split(new string[] { " → " }, StringSplitOptions.None);
                    int tietBatDau = int.Parse(tietRange[0]);
                    int tietKetThuc = int.Parse(tietRange[1]);
                    int soGVCanCap = int.Parse(column.Cell(9).Value.ToString());
                    LichThiDTO lt = new LichThiDTO(lastDate, tietBatDau, tietKetThuc, soGVCanCap);
                    lstLichThi.Add(lt);
                }
            }
            return lstLichThi;
        }
    }
}
