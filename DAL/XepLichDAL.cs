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
        public List<LichThiXepResult> xepLichGacThi(List<LichThiDTO> LstLichThi,List<GiangVienDTO> LstGiangVien)
        {
            List<LichThiXepResult> ketquaxeplich = new List<LichThiXepResult>();
            List<LichThiDTO> Cathidaxep = new List<LichThiDTO>();
            List<LichThiDTO> danhsachlichthi = LstLichThi.OrderByDescending(t => t.SoGVCanCap).ThenBy(t => t.Ngay).ToList();
            int Solichtoida = danhsachlichthi.Sum(t => t.SoGVCanCap) / LstGiangVien.Count() + 1;
            foreach (LichThiDTO lichthi in danhsachlichthi)
            {
                int sogvdaxep = 0;
                var sortedgiangvien = LstGiangVien
                    .OrderBy(gv => gv.LichGacThi.Count())
                    //.ThenBy(gv => gv.GetKhoangCachGanNhat(lichthi))
                    .ToList();

                var ketqua = new LichThiXepResult(lichthi);
                foreach (var giangvien in sortedgiangvien)
                {
                    if (sogvdaxep >= lichthi.SoGVCanCap) break;
                    if (giangvien.ThemLichGacThi(lichthi, Solichtoida))
                    {
                        sogvdaxep++;
                        ketqua.GiangViens.Add(giangvien);
                    }
                }
                if (sogvdaxep == lichthi.SoGVCanCap)
                {
                    Cathidaxep.Add(lichthi);
                    LstLichThi.Remove(lichthi);
                    ketquaxeplich.Add(ketqua);
                }
            }

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

        //public int TinhDiemLichDaXep(List<LichThiXepResult> danhSachLichThiDaXep,List<GiangVienDTO> LstGiangVien)
        //{
        //    int tongDiem = 0;
        //    int diemThuongLienKe = 10;     // Điểm thưởng nếu lịch thi liên tiếp nhau

        //    //foreach (var lichThi in danhSachLichThiDaXep)
        //    //{
        //    //    foreach (var giangVien in LstGiangVien)
        //    //    {
        //    //        // Kiểm tra ràng buộc mềm: liên tục giữa các ca thi
        //    //        int khoangCach = giangVien.GetKhoangCachGanNhat(lichThi);
        //    //        if (khoangCach == 1)
        //    //        {
        //    //            tongDiem += diemThuongLienKe; // Thưởng nếu ca thi liên kề
        //    //        }
        //    //        else if (khoangCach > 1 && khoangCach != int.MaxValue)
        //    //        {
        //    //            tongDiem += diemThuongLienKe / khoangCach; // Thưởng giảm dần nếu khoảng cách xa hơn
        //    //        }
        //    //    }
        //    //}

        //    foreach(var giangvien in LstGiangVien)
        //    {
        //        foreach(var lt in giangvien.LichGacThi)
        //        {
        //            int khoangcach = giangvien.GetKhoangCachGanNhat(lt);
        //            if (khoangcach == 1)
        //            {
        //                tongDiem+= diemThuongLienKe;
        //            }
        //            else if(khoangcach>1 && khoangcach!= int.MaxValue)
        //            {
        //                tongDiem += diemThuongLienKe / khoangcach;
        //            }
        //        }
        //    }


        //    return tongDiem;
        //}

        
    }
}
