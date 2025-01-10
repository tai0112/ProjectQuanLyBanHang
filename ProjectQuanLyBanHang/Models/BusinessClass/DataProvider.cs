using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectQuanLyBanHang.Models.BusinessClass
{
    public class DataProvider
    {
        private static QuanLyBanHangDbContext _context = null;

        public static QuanLyBanHangDbContext Context
        {
            get
            {
                if(_context == null)
                {
                    _context = new QuanLyBanHangDbContext();
                }
                return _context;
            }
        }
    }
}