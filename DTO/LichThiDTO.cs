using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LichThiDTO
    {
        public DateTime Ngay { get; set; }
        public int TietBatDau { get; set; }
        public int TietKetThuc { get; set; }
        public int SoGVCanCap { get; set; }

        public LichThiDTO(DateTime ngay, int tietbd, int tietkb, int SoGVCanCap)
        {
            Ngay = ngay;
            TietBatDau = tietbd;
            TietKetThuc = tietkb;
            this.SoGVCanCap = SoGVCanCap;
        }
    }
}
