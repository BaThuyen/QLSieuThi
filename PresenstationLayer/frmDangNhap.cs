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
            if (bus.dangNhap(txtAccount.Text, txtPassword.Text))
                MessageBox.Show("a");
            else
            {
                MessageBox.Show("");
            }
        }
    }
}
