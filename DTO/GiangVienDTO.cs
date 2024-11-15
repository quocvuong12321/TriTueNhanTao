using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GiangVienDTO
    {
        public string TenGiangVien { get; set; }
        public List<LichDayDTO> LichDay { get; set; }
        public List<LichThiDTO> LichGacThi { get; set; }
        public GiangVienDTO(string TenGiangVien, List<LichDayDTO> LichDay)
        {
            this.TenGiangVien = TenGiangVien;
            this.LichDay = LichDay;
            LichGacThi = new List<LichThiDTO>();
        }

        public GiangVienDTO(string TenGiangVien)
        {
            this.TenGiangVien = TenGiangVien;
            LichDay = new List<LichDayDTO>();
            LichGacThi = new List<LichThiDTO>();
        }

        public bool KiemTraTrungLichDay(LichThiDTO lt)
        {
            foreach (var lichday in LichDay)
            {
                if (lt.Ngay.ToShortDateString() == lichday.Ngay.ToShortDateString() && lt.TietBatDau >= lichday.TietBatDau && lt.TietKetThuc <= lichday.TietKetThuc)
                {
                    return false;
                }

            }
            return true;
        }

        public bool ThemLichGacThi(LichThiDTO lt, int SoLichGac)
        {
            if (LichGacThi.Count < SoLichGac)
            {
                LichGacThi.Add(lt);
                return true;
            }
            return false;

        }

        public int GetKhoangCachGanNhat(LichThiDTO lichthimoi)
        {
            int khoangCachNganNhat = 1000;
            foreach (var lichthi in LichGacThi)
            {
                // Nếu lịch mới bắt đầu sau lịch cũ, tính khoảng cách giữa lịch mới và lịch cũ
                if (lichthimoi.Ngay ==lichthi.Ngay && lichthimoi.TietBatDau > lichthi.TietKetThuc)
                {
                    int khoangCach = lichthimoi.TietBatDau - lichthi.TietKetThuc;
                    khoangCachNganNhat = Math.Min(khoangCach, khoangCachNganNhat);
                }
                // Nếu lịch mới kết thúc trước lịch cũ, tính khoảng cách giữa lịch mới và lịch cũ
                else if (lichthimoi.Ngay == lichthi.Ngay && lichthimoi.TietKetThuc < lichthi.TietBatDau)
                {
                    int khoangCach = lichthi.TietBatDau - lichthimoi.TietKetThuc;
                    khoangCachNganNhat = Math.Min(khoangCach, khoangCachNganNhat);
                }
                // Nếu hai lịch trùng nhau hoặc liền kề (không có khoảng cách), đặt khoảng cách thành 0
                else
                {
                    khoangCachNganNhat = 0;
                    break;
                }

            }
            return khoangCachNganNhat == 1000 ? 1000 : khoangCachNganNhat;
        }
    }
}
