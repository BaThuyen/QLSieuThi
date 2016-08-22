using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BLLNhanVien
    {
        DALNhanVien data = new DALNhanVien();
        public IQueryable layNCC()
        {
            return data.layNCC();
        }

        public IQueryable layPhieuNhap()
        {
            return data.layPhieuNhap();
        }

        public IQueryable layQuayHang()
        {
            return data.layQuayHang();
        }

        public IQueryable layLoaiHang()
        {
            return data.layLoaiHang();
        }

        public IQueryable layHangHoa()
        {
            return data.layHangHoa();
        }

        public bool themNCC(string maNCC, string tenNCC, string sdt, string diaChi, string email, string fax)
        {
            return data.themNCC(maNCC, tenNCC, sdt, diaChi, email, fax);
        }

        public bool themPhieuNhap(string maPN, string maNV, string ncc, int soLuong, string ngayNhap, string maHH, float donGia, float chietKhau, float tongTien)
        {
            return data.themPhieuNhap(maPN, maNV, ncc, soLuong, Convert.ToDateTime(ngayNhap), maHH, donGia, chietKhau, tongTien);
        }

        public bool themQuayHang(string maQH, string tenQH)
        {
            return data.themQuayHang(maQH, tenQH);
        }

        public bool themLoaiHang(string maLH, string tenLH, string maQH)
        {
            return data.themLoaiHang(maLH, tenLH, maQH);
        }

        public bool themHangHoa(string maHH, string tenHH, string hanSD, string nhaSX, string maLH)
        {
            return data.themHangHoa(maHH, tenHH, Convert.ToDateTime(hanSD), nhaSX, maLH);
        }

        public string[] layMaNCC()
        {
            return data.layMaNCC();
        }

        public string[] layMaHH()
        {
            return data.layMaHH();
        }

        public string[] layMaQH()
        {
            return data.layMaQH();
        }

        public string[] layMaLH()
        {
            return data.layMaLH();
        }
    }
}
