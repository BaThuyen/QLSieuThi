using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;

namespace PresenstationLayer
{
    public partial class frmNhanVien : Form
    {
        BLLNhanVien bus = new BLLNhanVien();
        private string maNV;
        public frmNhanVien(string maNV)
        {
            this.maNV = maNV;
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            // MenuScrip
            tsiNhanVien.Text = "Nhân viên: " + maNV;

            // Lấy thông tin tab NCC
            dgvNCC.DataSource = bus.layNCC();

            // Lấy thông tin tab Phiếu nhập
            string[] maNCCs = bus.layMaNCC();

            for (int i = 0; i < maNCCs.Length; i++)
            {
                cbbNCC.Items.Add(maNCCs[i]);
                cbbNhaSX.Items.Add(maNCCs[i]);
            }

            dgvPhieuNhap.DataSource = bus.layPhieuNhap();
            txtMaPN.Text = "PN" + dgvPhieuNhap.RowCount.ToString();

            string[] maHangHoas = bus.layMaHH();
            for (int i = 0; i < maHangHoas.Length; i++)
            {
                cbbMaHH.Items.Add(maNCCs[i]);
            }

            //
            dgvHangHoa.DataSource = bus.layHangHoa();
            string[] maLHs = bus.layMaLH();

            for (int i = 0; i < maLHs.Length; i++)
            {
                cbbMaLH.Items.Add(maLHs[i]);
            }

            //
            dgvQuayHang.DataSource = bus.layQuayHang();

            //
            dgvLoaiHang.DataSource = bus.layLoaiHang();
            string[] maQHs = bus.layMaQH();

            for (int i = 0; i < maQHs.Length; i++)
            {
                cbbMaQH.Items.Add(maQHs[i]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongTinNV form = new frmThongTinNV(maNV);
            form.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThem_Click(object sender, EventArgs e)
        {
            bool them = bus.themNCC(txtMaNCC.Text, txtTenNCC.Text, txtSdtNCC.Text, txtDiaChiNCC.Text, txtEmailNCC.Text, txtFaxNCC.Text);
            if (them)
            {
                MessageBox.Show("Đã thêm Nhà cung cấp");
                dgvNCC.DataSource = bus.layNCC();
            }
            else
            {
                MessageBox.Show("Thêm Lỗi");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNhap_Click(object sender, EventArgs e)
        {
            bool nhap = bus.themPhieuNhap(txtMaPN.Text, maNV, cbbNCC.Text, int.Parse(txtSoLuong.Text), dtpNgayNhap.Text,
                cbbMaHH.Text, float.Parse(txtDonGia.Text), float.Parse(txtChietKhau.Text), float.Parse(txtTongTien.Text));
            if (nhap)
            {
                MessageBox.Show("Đã thêm Phiếu nhập");
                dgvPhieuNhap.DataSource = bus.layPhieuNhap();
            }
            else
            {
                MessageBox.Show("Dữ liệu lỗi, vui lòng kiểm tra lại");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtChietKhau_TextChanged(object sender, EventArgs e)
        {
            float tongTien = (int.Parse(txtDonGia.Text) * float.Parse(txtDonGia.Text) * (100 - int.Parse(txtChietKhau.Text))) / 100;
            txtTongTien.Text = tongTien.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThemQH_Click(object sender, EventArgs e)
        {
            bool them = bus.themQuayHang(txtMaQH.Text, txtTenQH.Text);
            if(them)
            {
                MessageBox.Show("Đã thêm Quầy Hàng");
                dgvQuayHang.DataSource = bus.layQuayHang();
                dgvQuayHang.Refresh();
            }
            else
            {
                MessageBox.Show("Thêm Lỗi");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThemLH_Click(object sender, EventArgs e)
        {
            bool them = bus.themLoaiHang(txtMaLH.Text, txtTenLH.Text, txtMaQH.Text);
            if (them)
            {
                MessageBox.Show("Đã thêm Loại Hàng");
                dgvLoaiHang.DataSource = bus.layLoaiHang();
            }
            else
            {
                MessageBox.Show("Thêm Lỗi");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThemHH_Click(object sender, EventArgs e)
        {
            bool them = bus.themHangHoa(txtMaHH.Text, txtTenHH.Text, dtpHanSD.Text, cbbNhaSX.Text, cbbMaLH.Text);
            if (them)
            {
                MessageBox.Show("Đã thêm Hàng hóa");
                dgvHangHoa.DataSource = bus.layHangHoa();
                dgvHangHoa.Refresh();
            }
            else
            {
                MessageBox.Show("Thêm Lỗi");
            }
        }

    }
}
