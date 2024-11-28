using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL
{
    public class GiangVienBLL
    {
        GiangVienDAL gvDAL = new GiangVienDAL();
        public List<GiangVienDTO> LoadFileGiangVien(string path)
        {
            return gvDAL.LoadFileGiangVien(path);
        }
    }
}
