using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BLL
    {
        DAL data = new DAL();
        PasswordSalt salt = new PasswordSalt();
        public string dangNhap(string maNV, string matKhau)
        {
            matKhau = salt.createSalt(matKhau);
            return data.dangNhap(maNV, matKhau);
        }

        public string[] layNhanVien(string maNV)
        {
            NHANVIEN nvTemp = data.layNhanVien(maNV);
            string[] nv = new string[8];

            nv[0] = nvTemp.MaNV;
            nv[1] = nvTemp.TenNV;
            nv[2] = nvTemp.GioiTinh;
            nv[3] = nvTemp.NgaySinh.ToString();
            nv[4] = nvTemp.DiaChi;
            nv[5] = nvTemp.SDT;
            nv[6] = nvTemp.MatKhau;
            nv[7] = nvTemp.ChucVu;

            return nv;
        }

        public void suaNhanVien(string maNV, string tenNV, string gioiTinh, string ngaySinh, string diaChi, string sdt)
        {
            data.suaNhanVien(maNV, tenNV, gioiTinh, Convert.ToDateTime(ngaySinh), diaChi, sdt);
        }

        public bool doiMatKhau(string maNV, string matKhau, string matKhauMoi)
        {
            return data.doiMatKhau(maNV, salt.createSalt(matKhau), salt.createSalt(matKhauMoi));
        }
    }
}
