using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class DataAccessObject
    {
        public class NhanVien
        {
            private string maNV;

            public string MaNV
            {
                get { return maNV; }
                set { maNV = value; }
            }

            private string tenNV;

            public string TenNV
            {
                get { return tenNV; }
                set { tenNV = value; }
            }
            private string gioiTinh;

            public string GioiTinh
            {
                get { return gioiTinh; }
                set { gioiTinh = value; }
            }
            private DateTime ngaySinh;

            public DateTime NgaySinh
            {
                get { return ngaySinh; }
                set { ngaySinh = value; }
            }
            private string diaChi;

            public string DiaChi
            {
                get { return diaChi; }
                set { diaChi = value; }
            }
            private string sdt;

            public string Sdt
            {
                get { return sdt; }
                set { sdt = value; }
            }
            private string matKhau;

            public string MatKhau
            {
                get { return matKhau; }
                set { matKhau = value; }
            }
            private string chucVu;

            public string ChucVu
            {
                get { return chucVu; }
                set { chucVu = value; }
            }
        }
    }
}
