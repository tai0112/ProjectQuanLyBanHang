using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using Microsoft.AspNet.Identity;
using ProjectQuanLyBanHang.Filters;
using ProjectQuanLyBanHang.Identity;
using ProjectQuanLyBanHang.Models;
using ProjectQuanLyBanHang.Models.Business;

namespace ProjectQuanLyBanHang.Controllers
{
    [MyAuthenFilter]
    public class GioHangController : Controller
    {
        QuanLyBanHangDbContext db = new QuanLyBanHangDbContext();
        GioHangBusiness ghBus = new GioHangBusiness();
        AppDbContext adb = new AppDbContext();
        // GET: GioHang
        public TaiKhoan LayMaTaiKhoan()
        {
            string maTaiKhoan = User.Identity.GetUserId();
            return db.taiKhoans.Where(o => o.MaTaiKhoan == maTaiKhoan).First();
        }

        public ActionResult ThemVaoGioHang(int sanPhamId, bool giamSoLuong = false, bool tangSoLuong = false)
        {   
            ghBus.ThemSanPhamVaoGio(LayMaTaiKhoan().TaiKhoanId, sanPhamId, giamSoLuong, tangSoLuong);
            db.SaveChanges();
            return Redirect("GioHang");
        }

        public ActionResult GioHang(string userId)
        {
            if (userId == null)
            {
                userId = LayMaTaiKhoan().MaTaiKhoan;
            }
            Session["SoLuongSanPham"] = db.gioHangChiTiets.Where(o => o.GioHang.TaiKhoan.MaTaiKhoan == userId).Sum(o => o.SoLuong);
            var gioHang = db.gioHangs.Where(o => o.TaiKhoan.MaTaiKhoan == userId).FirstOrDefault();
            var gioHangChiTiet = db.gioHangChiTiets.Where(o => o.GioHangId == gioHang.GioHangId);
            return View(gioHangChiTiet.ToList());
        }
    }
}