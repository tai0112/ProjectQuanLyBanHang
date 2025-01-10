using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace ProjectQuanLyBanHang.Models
{
    public class DataProvider
    {
        private static QuanLyBanHangDbContext _context = null;
        private static QuanLyBanHangDbContext db = new QuanLyBanHangDbContext();
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

        public static void DeleteImage(string fileName, string folderPath)
        {
            string filePath = Path.Combine(folderPath, fileName);
            if (System.IO.File.Exists(filePath))
            {
                try
                {
                    System.IO.File.Delete(filePath);
                    Debug.WriteLine("Delete image success");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error: " + ex.Message);
                }
            }
        }

        public static void DeleteMultipleImage(string folderPath, ICollection<AnhSanPham> files)
        {
            AnhSanPham anhSanPham;
            if(files.Count > 0)
            {
                foreach (var file in files)
                {
                    anhSanPham = db.anhSanPhams.Where(o => o.AnhSanPhamId == file.AnhSanPhamId).FirstOrDefault();
                    db.anhSanPhams.Remove(anhSanPham);
                    DeleteImage(file.UrlAnh, folderPath);
                }
            }else
            {
                return;
            }
        }

    }
}