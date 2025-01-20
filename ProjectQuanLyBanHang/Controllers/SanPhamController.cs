using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngleSharp.Html;
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
                SanPhamChiTiet randomProduct = db.sanPhamChiTiets.Where(o => o.SanPham.TrangThai == true && o.SanPham.LoaiSanPham.MaLoaiSanPham == sanPham.SanPham.MaLoaiSanPham).OrderBy(o => o.SanPham.LoaiSanPham.MaLoaiSanPham).Skip(random).FirstOrDefault();
                lstSanPhamChiTiet.Add(randomProduct);
            }
            ViewBag.ProductSimilar = lstSanPhamChiTiet;
            return View(sanPham);
        }

        public ActionResult ToanBoSanPham(int maLoaiSanPham, string tinhTrangHang, string NhaCungCap, string ram, string ssd)
        {
            string ncc = "";
            ViewBag.MaLoaiSanPham = maLoaiSanPham;
            if (!string.IsNullOrEmpty(NhaCungCap))
            {
                ncc = NhaCungCap;
            }
            ViewBag.NhaCungCap = new SelectList(db.nhaCungCaps, "MaNhaCungCap", "TenNhaCungCap", ncc);
            ViewBag.ram = new SelectList(
            new List<SelectListItem>
            {
                new SelectListItem { Text = "Ram", Value = "" },
                new SelectListItem { Text = "8 GB", Value = "8" },
                new SelectListItem { Text = "16 GB", Value = "16" },
                new SelectListItem { Text = "32 GB", Value = "32" },
                new SelectListItem { Text = "64 GB", Value = "64" },
                new SelectListItem { Text = "128 GB", Value = "128" }
            }, "Value", "Text", ram);

            ViewBag.tinhTrangHang = new SelectList(
            new List<SelectListItem>
            {
                new SelectListItem { Text = "Tình trạng", Value = "" },
                new SelectListItem { Text = "Còn hàng", Value = "ConHang" },
                new SelectListItem { Text = "Hết hàng", Value = "HetHang" }
            }, "Value", "Text", tinhTrangHang);

            ViewBag.ssd = new SelectList(
            new List<SelectListItem>
            {
                new SelectListItem { Text = "SSD", Value = "" },
                new SelectListItem { Text = "258 GB", Value = "258" },
                new SelectListItem { Text = "512 GB", Value = "512" },
                new SelectListItem { Text = "1 TB", Value = "1024" },
                new SelectListItem { Text = "2 TB", Value = "2048" }
            }, "Value", "Text", ssd);


            var sanPhamTheoLoai = db.sanPhamChiTiets.Where(o => o.SanPham.MaLoaiSanPham == maLoaiSanPham && o.SanPham.TrangThai == true);

            if (!string.IsNullOrEmpty(tinhTrangHang))
            {
                if (tinhTrangHang == "ConHang")
                {
                    sanPhamTheoLoai = sanPhamTheoLoai.Where(o => o.SoLuong > 0);
                }else
                {
                    sanPhamTheoLoai = sanPhamTheoLoai.Where(o => o.SoLuong == 0);
                }
            }

            if (!string.IsNullOrEmpty(NhaCungCap))
            {
                sanPhamTheoLoai = sanPhamTheoLoai.Where(o => o.SanPham.NhaCungCap.MaNhaCungCap == NhaCungCap);
            }

            if (!string.IsNullOrEmpty(ram))
            {
                int ramInt = int.Parse(ram);
                sanPhamTheoLoai = sanPhamTheoLoai.Where(o => o.Ram.DungLuongRam  == ramInt);
            }

            if (!string.IsNullOrEmpty(ssd))
            {
                int ssdInt = int.Parse(ssd);
                sanPhamTheoLoai = sanPhamTheoLoai.Where(o => o.SSD == ssdInt);
            }

            return View(sanPhamTheoLoai.ToList());
        }

    }
}