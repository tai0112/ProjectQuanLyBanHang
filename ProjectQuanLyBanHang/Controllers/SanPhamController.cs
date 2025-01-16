using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using ProjectQuanLyBanHang.Models;

namespace ProjectQuanLyBanHang.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        QuanLyBanHangDbContext db = new QuanLyBanHangDbContext();
        public ActionResult ChiTietSanPham(int id)
        {
            var sanPham = db.sanPhamChiTiets.Where(o => o.SanPhamChiTietId == id).FirstOrDefault();
            return View(sanPham);
        }
    }
}