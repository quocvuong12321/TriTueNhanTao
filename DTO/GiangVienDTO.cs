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

        public override bool Equals(object obj)
        {
            if (obj is GiangVienDTO other)
            {
                return this.TenGiangVien == other.TenGiangVien;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return TenGiangVien.GetHashCode();
        }

        public bool KiemTraTrungLichDay(LichThiDTO lt)
        {
            foreach (var lichday in LichDay)
            {
                if (lt.Ngay.Date == lichday.Ngay.Date)
                {
                    if ((lichday.TietKetThuc >= lt.TietBatDau && lichday.TietKetThuc <= lt.TietKetThuc) ||
                    (lt.TietKetThuc >= lichday.TietBatDau && lt.TietKetThuc <= lichday.TietKetThuc) ||
                    (lichday.TietBatDau >= lt.TietBatDau && lichday.TietBatDau <= lt.TietKetThuc) ||
                    (lt.TietBatDau >= lichday.TietBatDau && lt.TietBatDau <= lichday.TietKetThuc))
                        return true;
                }
            }
            return false;
        }

        public bool KiemTraTrungLichThi(LichThiDTO lt2)
        {
            foreach (var lt1 in LichGacThi)
            {
                if (lt1.Ngay.Date == lt2.Ngay.Date)
                {
                    // Kiểm tra xem tiết học có chồng lấn hay không
                    if ((lt1.TietKetThuc >= lt2.TietBatDau && lt1.TietKetThuc <= lt2.TietKetThuc) ||
                        (lt2.TietKetThuc >= lt1.TietBatDau && lt2.TietKetThuc <= lt1.TietKetThuc) ||
                        (lt1.TietBatDau >= lt2.TietBatDau && lt1.TietBatDau <= lt2.TietKetThuc) ||
                        (lt2.TietBatDau >= lt1.TietBatDau && lt2.TietBatDau <= lt1.TietKetThuc))
                    {
                        return true;  // Nếu có chồng lấn, trả về true (lịch thi trùng)
                    }
                }
            }
            return false;  // Nếu không trùng lịch
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

        public bool ThemLichGacThi(LichThiDTO lt)
        {
            LichGacThi.Add(lt);
            return true;
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

            // Tổng hợp khoảng cách, với trọng số ngày để ưu tiên khoảng cách theo ngày
            return ngayKhoangCach*2 + tietKhoangCach;
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
