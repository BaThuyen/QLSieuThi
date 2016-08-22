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
        public bool dangNhap(string maNV, string matKhau)
        {
            return data.dangNhap(maNV, matKhau);
        }
    }
}
