using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DTO
{
    public class LichDayDTO
    {
        public DateTime Ngay { get; set; }
        public int TietBatDau { get; set; }
        public int TietKetThuc { get; set; }

        public LichDayDTO(DateTime ngay, int tietbatdau, int tietketthuc)
        {
            Ngay = ngay;
            TietBatDau = tietbatdau;
            TietKetThuc = tietketthuc;
        }
    }
}
