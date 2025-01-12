using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectQuanLyBanHang.Filters;
using ProjectQuanLyBanHang.Models;
using WebGrease.Css.Extensions;

namespace ProjectQuanLyBanHang.Controllers
{
    public class TrangChuController : Controller
    {
        // GET: TrangChu
        QuanLyBanHangDbContext db = new QuanLyBanHangDbContext();
        public ActionResult TrangChu()
        {
            var loaiSanPham = db.loaiSanPhams.ToList();
            var laptop = db.sanPhamChiTiets.Where(o => o.SanPham.TrangThai == true).ToList();
            ViewBag.LoaiSanPham = loaiSanPham; 
            return View(laptop);
        }
    }
}