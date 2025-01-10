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
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(TaiKhoan taiKhoan)
        {
            var login = db.taiKhoans.Where(o => o.TenDangNhap == taiKhoan.TenDangNhap && o.MatKhau == taiKhoan.MatKhau).FirstOrDefault();
            if (taiKhoan.TenDangNhap == "admin" && taiKhoan.MatKhau == "admin")
            {
                TempData["Success"] = "Đăng nhập thành công";
                Session["AccountId"] = taiKhoan.TaiKhoanId;
            }
            TempData["Error"] = "Đăng nhập thất bại";
            return RedirectToAction("TrangChu", "TrangChu");
        }

        public ActionResult Logout()
        {
            Session["AccountId"] = null;
            return RedirectToAction("TrangChu", "TrangChu");
        }
    }
}