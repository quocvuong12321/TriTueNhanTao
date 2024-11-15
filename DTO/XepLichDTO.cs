using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class XepLichDTO
    {
        public List<GiangVienDTO> LstGiangVien { get; set; }
        public List<LichThiDTO> LstLichThi { get; set; }
        public XepLichDTO(List<GiangVienDTO> lstGiangVien,List<LichThiDTO> lstLichThi)
        {
            LstGiangVien = lstGiangVien;
            LstLichThi = lstLichThi;
        }
    }
}
