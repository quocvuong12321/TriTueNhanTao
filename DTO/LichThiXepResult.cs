using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LichThiXepResult
    {
        public LichThiDTO LichThi { get; set; }
        public List<GiangVienDTO> GiangViens { get; set; }
        public LichThiXepResult(LichThiDTO lichThi)
        {
            LichThi = lichThi;
            GiangViens = new List<GiangVienDTO>();
        }

        
    }
}
