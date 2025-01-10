using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectQuanLyBanHang.Models.BusinessClass
{
    public class SanPhamBusiness
    {
        public List<SanPham> GetAll()
        {
            return DataProvider.Context.sanPhams.ToList();
        }

        public SanPham Get(string id)
        {
            return DataProvider.Context.sanPhams.Where(o => o.MaSanPham == id).FirstOrDefault();
        }

        public bool Add(SanPham sanPham)
        {
            try
            {

                return true;
            }catch (Exception ex)
            {

            }
            return false;
        }
    }
}