﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class XepLichBLL
    {
        public XepLichDAL xlDAL = new XepLichDAL();
        public List<LichThiXepResult> xepLichGacThi(List<LichThiDTO> LstLichThi, List<GiangVienDTO> LstGiangVien)
        {
            return xlDAL.xepLichGacThi(LstLichThi, LstGiangVien);
        }

        public int[,] chuyenDoiXepLichSangMang(List<LichThiXepResult> ketquaxeplich, List<GiangVienDTO> lstgiangvien)
        {
            return xlDAL.chuyenDoiXepLichSangMang(ketquaxeplich, lstgiangvien);
        }

       
    }
}