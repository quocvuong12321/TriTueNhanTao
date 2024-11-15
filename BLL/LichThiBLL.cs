using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class LichThiBLL
    {
        LichThiDAL ltDAL = new LichThiDAL();
        public List<LichThiDTO> DocFileLichThi(string path)
        {
            return ltDAL.DocFileLichThi(path);
        }
    }
}
