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
    }
}
