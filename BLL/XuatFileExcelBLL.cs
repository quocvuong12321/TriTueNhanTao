using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class XuatFileExcelBLL
    {
        private XuatFileExcelDAL xuatFileDAL = new XuatFileExcelDAL();

        public string XuatFileExcel(List<GiangVienDTO> lstGiangVien, List<string> uniqueColumns, int[,] resultMatrix, List<LichThiDTO> lstLichThi, string filePath)
        {
            return xuatFileDAL.XuatFileExcel(lstGiangVien, uniqueColumns, resultMatrix,lstLichThi, filePath);
        }




    }
}
