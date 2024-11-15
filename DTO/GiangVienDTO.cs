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
        public static int TinhKhoangCach(LichThiDTO lich1, LichThiDTO lich2)
        {
            // Khoảng cách theo ngày (số ngày giữa hai lịch thi)
            int ngayKhoangCach = Math.Abs((lich1.Ngay - lich2.Ngay).Days);

            // Khoảng cách theo tiết, chỉ tính nếu cùng ngày
            int tietKhoangCach = 0;
            if (lich1.Ngay == lich2.Ngay)
            {
                if (lich1.TietKetThuc < lich2.TietBatDau)
                {
                    // Nếu lịch 1 kết thúc trước lịch 2 bắt đầu
                    tietKhoangCach = lich2.TietBatDau - lich1.TietKetThuc;
                }
                else if (lich2.TietKetThuc < lich1.TietBatDau)
                {
                    // Nếu lịch 2 kết thúc trước lịch 1 bắt đầu
                    tietKhoangCach = lich1.TietBatDau - lich2.TietKetThuc;
                }
                else
                {
                    // Nếu hai lịch chồng chéo nhau
                    tietKhoangCach = 0;
                }
            }

            // Tổng hợp khoảng cách, với trọng số ngày (10) để ưu tiên khoảng cách theo ngày
            return ngayKhoangCach * 5 + tietKhoangCach;
        }

        public int GetKhoangCachGanNhat(LichThiDTO lichthiMoi)
        {
            if (LichGacThi.Count == 0)
            {
                // Nếu giảng viên chưa có lịch gác thi, coi như khoảng cách là vô cực (ưu tiên cho việc nhận lịch mới).
                return int.MaxValue;
            }

            // Tìm khoảng cách nhỏ nhất giữa lịch mới và các lịch gác thi đã có.
            return LichGacThi
                .Select(lichthi => TinhKhoangCach(lichthi, lichthiMoi))
                .Min();
        }
    }
}
