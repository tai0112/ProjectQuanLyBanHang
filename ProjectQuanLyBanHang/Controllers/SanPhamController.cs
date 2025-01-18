using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngleSharp.Io;
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
            var sanPhamLienQuan = db.sanPhamChiTiets.Where(o => o.SanPham.LoaiSanPham.MaLoaiSanPham == sanPham.SanPham.LoaiSanPham.MaLoaiSanPham).Count();
            List<SanPhamChiTiet> lstSanPhamChiTiet = new List<SanPhamChiTiet>();
            for (int i = 0; i < 3; i++)
            {
                var random = new Random().Next(0, sanPhamLienQuan);
                SanPhamChiTiet randomProduct = db.sanPhamChiTiets.Where(o => o.SanPham.TrangThai == true).OrderBy(o => o.SanPham.LoaiSanPham.MaLoaiSanPham).Skip(random).FirstOrDefault();
                lstSanPhamChiTiet.Add(randomProduct);
            }
            //var similarProduct = lstSanPhamChiTiet.Select(o => new{o.SanPham.TenSanPham, o.SanPham.MaSanPham, o.SanPham.AnhSanPhams.First().UrlAnh, o.SanPhamChiTietId, o.GiaTien}).ToList();
            ViewBag.ProductSimilar = lstSanPhamChiTiet;
            return View(sanPham);
        }
    }
}