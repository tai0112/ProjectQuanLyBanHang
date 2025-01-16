using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ProjectQuanLyBanHang.Identity;
using ProjectQuanLyBanHang.Models;
using ProjectQuanLyBanHang.Models.Business;

namespace ProjectQuanLyBanHang.Controllers
{
    public class GioHangController : Controller
    {
        QuanLyBanHangDbContext db = new QuanLyBanHangDbContext();
        GioHangBusiness ghBus = new GioHangBusiness();
        AppDbContext adb = new AppDbContext();
        // GET: GioHang
        public ActionResult ThemVaoGioHang(int sanPhamId)
        {
            string maTaiKhoan = User.Identity.GetUserId();
            var user = db.taiKhoans.Where(o => o.MaTaiKhoan == maTaiKhoan).First();
            ghBus.ThemSanPhamVaoGio(user.TaiKhoanId, sanPhamId);
            db.SaveChanges();
            return RedirectToAction("TrangChu","TrangChu");
        }
    }
}