using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;

namespace DataAccessLayer
{
    public class DAL
    {
        SmarketDataContext db = new SmarketDataContext();

        public string dangNhap(string maNV, string matKhau)
        {
            IQueryable list = db.NHANVIENs;
            foreach (NHANVIEN temp in list)
            {
                if (maNV.ToLower() == temp.MaNV.ToLower() && matKhau == temp.MatKhau) return temp.ChucVu;
            }
            return "";
        }

        public NHANVIEN layNhanVien(string maNV)
        {
            IQueryable dsNV = db.NHANVIENs;
            foreach (NHANVIEN nv in dsNV)
            {
                if (nv.MaNV.ToLower() == maNV.ToLower()) return nv;
            }
            return null;
        }

        public void suaNhanVien(string maNV, string tenNV, string gioiTinh, DateTime ngaySinh, string diaChi, string sdt)
        {
            var dsNV = from c in db.NHANVIENs
                       where c.MaNV.ToLower() == maNV.ToLower()
                       select c;
            foreach (NHANVIEN nv in dsNV)
            {
                nv.TenNV = tenNV;
                nv.GioiTinh = gioiTinh;
                nv.NgaySinh = ngaySinh;
                nv.DiaChi = diaChi;
                nv.SDT = sdt;
            }
            db.SubmitChanges();
        }

        public bool doiMatKhau(string maNV, string matKhau, string matKhauMoi)
        {
            IQueryable list = db.NHANVIENs;
            foreach (NHANVIEN temp in list)
            {
                if (maNV.ToLower() == temp.MaNV.ToLower() && matKhau == temp.MatKhau)
                {
                    temp.MatKhau = matKhauMoi;
                    db.SubmitChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
