using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ProjectQuanLyBanHang.Filters;
using ProjectQuanLyBanHang.Identity;
using ProjectQuanLyBanHang.Models;
using WebGrease.Css.Extensions;

namespace ProjectQuanLyBanHang.Controllers
{
    public class TrangChuController : Controller
    {
        // GET: TrangChu
        QuanLyBanHangDbContext db = new QuanLyBanHangDbContext();
        AppDbContext userDb = new AppDbContext();
        public ActionResult TrangChu()
        {
            if (User.Identity.IsAuthenticated && !User.IsInRole("Admin"))
            {
                var userIdentity = User.Identity.GetUserId();
                var gioHang = db.gioHangs.Where(o => o.TaiKhoan.MaTaiKhoan == userIdentity).FirstOrDefault();
                var sanPhamTrongGio = db.gioHangChiTiets.Count(o => o.GioHangId == gioHang.GioHangId);
                ViewBag.SanPhamTrongGio = sanPhamTrongGio;
            }
            var loaiSanPham = db.loaiSanPhams.ToList();
            var laptop = db.sanPhamChiTiets.Where(o => o.SanPham.TrangThai == true).ToList();
            ViewBag.LoaiSanPham = loaiSanPham;
            return View(laptop);
        }
    }
}