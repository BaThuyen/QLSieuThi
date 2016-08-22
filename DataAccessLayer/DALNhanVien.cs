using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALNhanVien
    {
        SmarketDataContext db = new SmarketDataContext();

        public IQueryable layNCC()
        {
            IQueryable nccs = db.NCCs;
            return nccs;
        }

        public IQueryable layPhieuNhap()
        {
            IQueryable phieuNhaps = db.PHIEUNHAPs;
            return phieuNhaps;
        }

        public IQueryable layQuayHang()
        {
            IQueryable quayHangs = db.QUAYHANGs;
            return quayHangs;
        }

        public IQueryable layLoaiHang()
        {
            IQueryable loaiHangs = db.LOAIHANGs;
            return loaiHangs;
        }

        public IQueryable layHangHoa()
        {
            IQueryable hangHoas = db.HANGHOAs;
            return hangHoas;
        }

        public string[] layMaNCC()
        {
            int size = db.NCCs.Count();
            string[] list = new string[size];
            IQueryable nccs = db.NCCs;
            int i = 0;
            foreach (NCC ncc in nccs)
            {
                list[i] = ncc.MaNCC;
                i++;
            }
            return list;
        }

        public string[] layMaHH()
        {
            int size = db.HANGHOAs.Count();
            string[] list = new string[size];
            IQueryable hangHoas = db.HANGHOAs;
            int i = 0;
            foreach (HANGHOA hh in hangHoas)
            {
                list[i] = hh.MaHH;
                i++;
            }
            return list;
        }

        public bool themPhieuNhap(string maPN, string maNV, string ncc, int soLuong, DateTime ngayNhap, string maHH, float donGia, float chietKhau, float tongTien)
        {
            PHIEUNHAP pn = new PHIEUNHAP();
            pn.MaPN = maPN;
            pn.MaNV = maNV;
            pn.MaNCC = ncc;
            pn.NgayNhap = ngayNhap;
            pn.TongTienPN = tongTien;

            CT_PN ct = new CT_PN();
            ct.MaPN = maPN;
            ct.MaHH = maHH;
            ct.SLuong = soLuong;
            ct.ChietKhau = chietKhau;
            ct.DonGia = donGia;

            IQueryable dsHang = db.HANGHOAs;
            try
            {
                db.PHIEUNHAPs.InsertOnSubmit(pn);
                db.CT_PNs.InsertOnSubmit(ct);
                foreach (HANGHOA hh in dsHang)
                {
                    if (hh.MaHH.ToLower() == maHH.ToLower()) hh.SoLuong += soLuong;
                }
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool themQuayHang(string maQH, string tenQH)
        {
            QUAYHANG qh = new QUAYHANG();
            qh.MaQH = maQH;
            qh.TenQH = tenQH;

            try
            {
                db.QUAYHANGs.InsertOnSubmit(qh);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string[] layMaQH()
        {
            int size = db.QUAYHANGs.Count();
            string[] list = new string[size];
            IQueryable quayHangs = db.QUAYHANGs;
            int i = 0;
            foreach (QUAYHANG qh in quayHangs)
            {
                list[i] = qh.MaQH;
                i++;
            }
            return list;
        }

        public string[] layMaLH()
        {
            int size = db.LOAIHANGs.Count();
            string[] list = new string[size];
            IQueryable loaiHangs = db.LOAIHANGs;
            int i = 0;
            foreach (LOAIHANG lh in loaiHangs)
            {
                list[i] = lh.MaLH;
                i++;
            }
            return list;
        }

        public bool themLoaiHang(string maLH, string tenLH, string maQH)
        {
            LOAIHANG lh = new LOAIHANG();
            lh.MaLH = maLH;
            lh.TenLH = tenLH;
            lh.MaQH = maQH;

            try
            {
                db.LOAIHANGs.InsertOnSubmit(lh);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool themHangHoa(string maHH, string tenHH, DateTime hanSD, string nhaSX, string maLH)
        {
            HANGHOA hh = new HANGHOA();
            hh.MaHH = maHH;
            hh.TenHH = tenHH;
            hh.HanSD = hanSD;
            hh.NhaSX = nhaSX;
            hh.MaLH = maLH;
            hh.SoLuong = 0;

            try
            {
                db.HANGHOAs.InsertOnSubmit(hh);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool themNCC(string maNCC, string tenNCC, string sdt, string diaChi, string email, string fax)
        {
            NCC ncc = new NCC();
            ncc.MaNCC = maNCC;
            ncc.tenNCC = tenNCC;
            ncc.SDT = sdt;
            ncc.DiaChi = diaChi;
            ncc.email = email;
            ncc.fax = fax;

            try
            {
                db.NCCs.InsertOnSubmit(ncc);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
