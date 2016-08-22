using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class PasswordSalt
    {
        public string createSalt(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            System.Security.Cryptography.SHA256Managed sha256 = new System.Security.Cryptography.SHA256Managed();
            byte[] hash = sha256.ComputeHash(bytes);
            string saltPassword = "";
            foreach (byte x in hash)
            {
                saltPassword += String.Format("{0:x2}", x);
            }
            return saltPassword;
        }
    }
}
