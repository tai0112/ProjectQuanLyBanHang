using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectQuanLyBanHang.Models;

namespace ProjectQuanLyBanHang.Controllers
{
    public class DangNhapController : Controller
    {
        QuanLyBanHangDbContext db = new QuanLyBanHangDbContext();
        // GET: DangNhap
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TaiKhoan taiKhoan)
        {
            var login = db.taiKhoans.Where(o => o.TenDangNhap == taiKhoan.TenDangNhap && o.MatKhau == taiKhoan.MatKhau).FirstOrDefault();
            TempData["Login"] = "Chào đón";
            if (login != null)
            {
                TempData["type"] = "Đăng nhập thành công";
            }
            TempData["type"] = "Đăng nhập thất bại";
            return View();
        }
    }
}