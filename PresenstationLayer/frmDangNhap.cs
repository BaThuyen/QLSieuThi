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
    public partial class frmDangNhap : Form
    {
        BLL bus = new BLL();

        public frmDangNhap()
        {
            InitializeComponent();
        }
        
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string checkLog = bus.dangNhap(txtAccount.Text, txtPassword.Text);
            if (rdbQuanLy.Checked)
            {
                if (checkLog == "QL")
                {
                }
                else MessageBox.Show("Sai thông tin đăng nhập!", "Lỗi",  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (rdbNhanVien.Checked)
            {
                if (checkLog == "NV")
                {
                    frmNhanVien form = new frmNhanVien(txtAccount.Text);
                    form.Show();
                }
                else MessageBox.Show("Sai thông tin đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (checkLog == "TN")
                {
                }
                else MessageBox.Show("Sai thông tin đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
