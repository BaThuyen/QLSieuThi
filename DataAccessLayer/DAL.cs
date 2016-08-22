﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObject;
using System.Resources;

namespace DataAccessLayer
{
    public class DAL
    {
        SmarketDataContext db = new SmarketDataContext();

        public bool dangNhap(string maNV, string matKhau)
        {
            IQueryable list = db.NHANVIENs;
            foreach (NHANVIEN temp in list)
            {
                if (maNV.ToLower() == temp.MaNV.ToLower() && matKhau == temp.MatKhau) return true;
            }
            return false;       
        }
    }
}