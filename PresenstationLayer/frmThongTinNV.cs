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
    public partial class frmThongTinNV : Form
    {
        private string maNV;
        BLL bus = new BLL();
        public frmThongTinNV(string maNV)
        {
            this.maNV = maNV;
            InitializeComponent();
        }

        private void frmThongTinNV_Load(object sender, EventArgs e)
        {
            string[] nv = new string[8];
            nv = bus.layNhanVien(maNV);

            txtMaNV.Text = maNV;
            txtHoTen.Text = nv[1];
            if (nv[2].ToLower() == "nam") rdbNam.Checked = true;
            else rdbNu.Checked = true;
            dtpNgaySinh.Text = nv[3];
            txtDiaChi.Text = nv[4];
            txtSDT.Text = nv[5];
            if (nv[7] == "QL") lblChucVu.Text = "Quản lý";
            else if (nv[7] == "NV") lblChucVu.Text = "Nhân viên";
            else lblChucVu.Text = "Thu ngân";
        }

        private void btnLuuTT_Click(object sender, EventArgs e)
        {
            string gioiTinh = "Nam";
            if(rdbNu.Checked) gioiTinh = "Nữ";
            if (txtHoTen.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "")
                MessageBox.Show("Không để trống Thông tin", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else
            {
                bus.suaNhanVien(maNV, txtHoTen.Text, gioiTinh, dtpNgaySinh.Text, txtDiaChi.Text, txtSDT.Text);
                MessageBox.Show("Đã lưu thông tin", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnMatKhau_Click(object sender, EventArgs e)
        {
            if (txtMK.Text == "" || txtMKmoi.Text == "" || txtNhapLai.Text == "")
            {
                MessageBox.Show("Không để trống Thông tin!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (txtMKmoi.Text != txtNhapLai.Text)
            {
                MessageBox.Show("Mật khẩu mới không khớp!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if(bus.doiMatKhau(maNV, txtMK.Text, txtMKmoi.Text))
                {
                    MessageBox.Show("Đã đổi Mật khẩu", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sai Mật khẩu!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
    }
}
