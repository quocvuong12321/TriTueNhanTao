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
        public List<LichThiXepResult> xepLichGacThi(List<LichThiDTO> LstLichThi,List<GiangVienDTO> LstGiangVien)
        {
            List<LichThiXepResult> ketquaxeplich = new List<LichThiXepResult>();
            List<LichThiDTO> Cathidaxep = new List<LichThiDTO>();
            Cathichuaxep = new List<LichThiDTO>();
            //Chiến lượt sắp xếp heuristic cho LichThi
            //OrderByDescending(t => t.SoGVCanCap).ThenBy(t => t.Ngay).
            //OrderBy(t=>t.Ngay).ThenByDescending(t=>t.SoGVCanCap).
            List<LichThiDTO> danhsachlichthi = LstLichThi.OrderByDescending(t => t.SoGVCanCap).ThenBy(t => t.Ngay).ToList();
            int Solichtoida = danhsachlichthi.Sum(t => t.SoGVCanCap) / LstGiangVien.Count() + 1;
            foreach (LichThiDTO lichthi in danhsachlichthi)
            {
                int sogvdaxep = 0;
                //Chiến lượt sắp xếp heuristic cho giảng viên
                var sortedgiangvien = LstGiangVien
                    .OrderBy(gv => gv.GetKhoangCachGanNhat(lichthi))
                    .ThenBy(gv => gv.LichGacThi.Count())
                    .ToList();

                var ketqua = new LichThiXepResult(lichthi);
                foreach (var giangvien in sortedgiangvien)
                {
                    if (lichthi.SoGVCanCap == 0) break;
                    if (giangvien.ThemLichGacThi(lichthi, Solichtoida))
                    {
                        sogvdaxep++;
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

        public List<LichThiDTO> KiemTraXepHetChua()
        {
            if (Cathichuaxep.Count() > 0)
            {
                return Cathichuaxep;
            }
            return new List<LichThiDTO>();
        }
    }
}
