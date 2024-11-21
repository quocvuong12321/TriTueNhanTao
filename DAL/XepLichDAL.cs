using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class XepLichDAL
    {
        List<LichThiDTO> Cathichuaxep;
        List<LichThiXepResult> ketquaxeplich;
        public List<LichThiXepResult> xepLichGacThi(List<LichThiDTO> LstLichThi,List<GiangVienDTO> LstGiangVien)
        {
            /*List<LichThiXepResult>*/ ketquaxeplich = new List<LichThiXepResult>();
            List<LichThiDTO> Cathidaxep = new List<LichThiDTO>();
            Cathichuaxep = new List<LichThiDTO>();
            //Chiến lượt sắp xếp heuristic cho LichThi
            //OrderByDescending(t => t.SoGVCanCap).ThenBy(t => t.Ngay).
            //OrderBy(t=>t.Ngay).ThenByDescending(t=>t.SoGVCanCap).
            List<LichThiDTO> danhsachlichthi = LstLichThi.OrderByDescending(t => t.SoGVCanCap).ThenBy(t=>t.Ngay).ThenBy(t=>t.TietBatDau).ThenBy(t=>t.TietKetThuc).ToList();
            int Solichtoida = danhsachlichthi.Sum(t => t.SoGVCanCap) / LstGiangVien.Count() + 1;
            foreach (LichThiDTO lichthi in danhsachlichthi)
            {
                //int sogvdaxep = 0;
                //Chiến lượt sắp xếp heuristic cho giảng viên
                var sortedgiangvien = LstGiangVien
                    .Where(gv=>gv.KiemTraTrungLichDay(lichthi) == false)
                    .Where(gv=>gv.KiemTraTrungLichThi(lichthi)==false)
                    .OrderBy(gv => gv.GetKhoangCachGanNhat(lichthi))
                    .ThenBy(gv => gv.LichGacThi.Count())
                    .ToList();

                var ketqua = new LichThiXepResult(lichthi);
                foreach (var giangvien in sortedgiangvien)
                {
                    if (lichthi.SoGVCanCap == 0) break;
                    if (giangvien.ThemLichGacThi(lichthi, Solichtoida))
                    {
                        //sogvdaxep++;
                        ketqua.GiangViens.Add(giangvien);
                        lichthi.SoGVCanCap--;
                    }
                   
                }
                if (lichthi.SoGVCanCap == 0)
                {
                    Cathidaxep.Add(lichthi);
                    ketquaxeplich.Add(ketqua);
                }
            }
            Cathichuaxep = LstLichThi.Except(Cathidaxep).ToList();

            bool kq = XepLichBacktracking(Cathichuaxep, LstGiangVien, Solichtoida);

            return ketquaxeplich;
        }

        public int[,] chuyenDoiXepLichSangMang(List<LichThiXepResult> ketquaxeplich,List<GiangVienDTO> lstgiangvien)
        {
            var Uniquecolumns = ketquaxeplich.
                OrderBy(t=>t.LichThi.Ngay).
                ThenBy(t=>t.LichThi.TietBatDau).
                Select(kq => new { kq.LichThi.Ngay, kq.LichThi.TietBatDau, kq.LichThi.TietKetThuc }).
                ToList();

            var columnIndexMap = Uniquecolumns.
                Select((val, index) => new { val, index }).
                ToDictionary(x => x.val, x => x.index);

            // 2. Khởi tạo mảng 2 chiều với số hàng là số giảng viên và số cột là số lịch thi duy nhất
            int[,] resultMatrix = new int[lstgiangvien.Count, Uniquecolumns.Count];

            foreach(var kq in ketquaxeplich)
            {
                var lich = new { kq.LichThi.Ngay, kq.LichThi.TietBatDau, kq.LichThi.TietKetThuc };

                int columnindex = columnIndexMap[lich];

                foreach(var gv in kq.GiangViens)
                {
                    int rowIndex = lstgiangvien.IndexOf(gv);
                    resultMatrix[rowIndex, columnindex] = 1;
                }
            }
            return resultMatrix;
        }

        public static int DanhGiaLichThi(List<LichThiXepResult> danhSachKetQua)
        {
            int tongDiem = 0;

            foreach (var lichThiResult in danhSachKetQua)
            {
                foreach (var giangVien in lichThiResult.GiangViens)
                {
                    // Tính tổng khoảng cách giữa lịch thi hiện tại và các lịch gác thi đã có của giảng viên
                    int diemDanhGia = giangVien.LichGacThi
                        .Select(lichGacThi => GiangVienDTO.TinhKhoangCach(lichThiResult.LichThi, lichGacThi))
                        .Sum();

                    // Cộng điểm đánh giá vào tổng điểm
                    tongDiem += diemDanhGia;
                }
            }
            return tongDiem; // Điểm càng thấp càng tốt
        }

        public List<LichThiDTO> LayDanhSachLichChuaXep()
        {
            if (Cathichuaxep.Count() > 0)
            {
                return Cathichuaxep;
            }
            return new List<LichThiDTO>();
        }

        public bool XepLichBacktracking(List<LichThiDTO> Cathichuaxep, List<GiangVienDTO> LstGiangVien, int Solichtoida)
        {
            // Kiểm tra nếu không còn ca thi nào cần xếp
            if (Cathichuaxep.Count == 0)
                return true; // Nếu không còn ca thi, tức là đã xếp xong

            // Lấy ca thi đầu tiên trong danh sách
            LichThiDTO lichthi = Cathichuaxep[0];

            // Lọc giảng viên có thể xếp cho ca thi này
            var sortedGiangVien = LstGiangVien
                .Where(gv => gv.KiemTraTrungLichThi(lichthi) == false) // Kiểm tra xem giảng viên có lịch thi trùng không
                .Where(gv => gv.KiemTraTrungLichDay(lichthi) == false) // Kiểm tra xem giảng viên có lịch dạy trùng không
                .OrderBy(gv => gv.GetKhoangCachGanNhat(lichthi)) // Chọn giảng viên gần nhất với ca thi
                .ThenBy(gv => gv.LichGacThi.Count()) // Giảng viên ít lịch nhất sẽ được ưu tiên
                .ToList();

            // Thử từng giảng viên để xếp lịch
            foreach (var giangvien in sortedGiangVien)
            {
                if (lichthi.SoGVCanCap > 0)
                {
                    // Thử xếp ca thi cho giảng viên
                    if (giangvien.ThemLichGacThi(lichthi))
                    {
                        // Nếu thành công, giảm số lượng giảng viên cần thiết cho ca thi này
                        lichthi.SoGVCanCap--;

                        var kq = ketquaxeplich.FirstOrDefault(t => t.LichThi == lichthi);
                        if (kq != null)
                        {
                            kq.GiangViens.Add(giangvien);
                        }
                        else
                        {
                            LichThiXepResult kq1 = new LichThiXepResult(lichthi);
                            kq1.GiangViens.Add(giangvien);
                            ketquaxeplich.Add(kq1);
                        }
                        Cathichuaxep.RemoveAt(0);
                        // Đệ quy tiếp tục thử xếp lịch cho ca thi tiếp theo trong danh sách
                        if (XepLichBacktracking(Cathichuaxep.Skip(1).ToList(), LstGiangVien, Solichtoida))
                        {
                            return true; // Nếu xếp lịch thành công cho tất cả các ca thi còn lại
                        }

                        // Nếu không thành công, quay lại và thử giảng viên khác
                        giangvien.LichGacThi.Remove(lichthi);// Xóa lịch thi đã thử gán
                        lichthi.SoGVCanCap++; // Khôi phục lại số giảng viên cần thiết cho ca thi này
                    }

                }
            }
            // Nếu không thể xếp lịch cho ca thi này với bất kỳ giảng viên nào, trả về false
            return false;
        }
    }
}
