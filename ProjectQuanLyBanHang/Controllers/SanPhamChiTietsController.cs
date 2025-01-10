using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AngleSharp.Text;
using ProjectQuanLyBanHang.Models;

namespace ProjectQuanLyBanHang.Controllers
{
    public class SanPhamChiTietsController : Controller
    {
        private QuanLyBanHangDbContext db = new QuanLyBanHangDbContext();

        // GET: SanPhamChiTiets
        public ActionResult Index(string search, string searchType, string priceRange, string priceRangeMin, string priceRangeMax)
        {
            var sanPhamChiTiets = db.sanPhamChiTiets.Include(s => s.CPU).Include(s => s.Gpu).Include(s => s.Ram).Include(s => s.SanPham);
            int priceMax = 0, priceMin = 0;
            if (int.TryParse(priceRangeMin, out priceMin))
            {
                sanPhamChiTiets = db.sanPhamChiTiets.Where(o => o.GiaTien >= priceMin);
            }

            if (int.TryParse(priceRangeMax, out priceMax))
            {
                if (priceMax > 9600000)
                {
                    sanPhamChiTiets = db.sanPhamChiTiets.Where(o => o.GiaTien <= priceMax);
                }
            }


            if (!String.IsNullOrEmpty(search))
            {
                if (!String.IsNullOrEmpty(searchType))
                {
                    switch (searchType)
                    {
                        case "SanPhamId":
                            sanPhamChiTiets = sanPhamChiTiets.Where(o => o.SanPham.MaSanPham == search);
                            break;
                        case "GPU":
                            sanPhamChiTiets = sanPhamChiTiets.Where(o => o.Gpu.TenGpu.Contains(search));
                            break;
                        case "RAM":
                            int ram = 0;
                            if (int.TryParse(search, out ram))
                            {
                                sanPhamChiTiets = sanPhamChiTiets.Where(o => o.Ram.DungLuongRam == ram);
                            }
                            else
                            {
                                TempData["erorr"] = "Bạn nhập sai kiểu dữ liệu tìm kiếm cho RAM";
                            }
                            break;
                        case "SSD":
                            int ssd = 0;
                            if (int.TryParse(search, out ssd))
                            {
                                sanPhamChiTiets = sanPhamChiTiets.Where(o => o.SSD == ssd);
                            }
                            else
                            {
                                TempData["erorr"] = "Bạn nhập sai kiểu dữ liệu tìm kiếm cho SSD";
                            }
                            break;
                        case "MauSac":
                            sanPhamChiTiets = sanPhamChiTiets.Where(o => o.MauSac == search);
                            break;
                    }
                }
                else
                {
                    sanPhamChiTiets = db.sanPhamChiTiets.Where(o => o.SanPham.MaSanPham == search);
                }

            }

            ViewBag.priceMin = priceMin;
            ViewBag.priceMax = priceMax;
            ViewBag.SoLuongTimDuoc = sanPhamChiTiets.Count();

            return View(sanPhamChiTiets.OrderBy(o => o.SanPham.MaSanPham).ToList());
        }

        // GET: SanPhamChiTiets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPhamChiTiet sanPhamChiTiet = db.sanPhamChiTiets.Find(id);
            if (sanPhamChiTiet == null)
            {
                return HttpNotFound();
            }
            return View(sanPhamChiTiet);
        }

        // GET: SanPhamChiTiets/Create
        public ActionResult Create(int? id)
        {
            var ramList = db.rams.OrderBy(o => o.DungLuongRam).Select(r => new
            {
                RamId = r.RamId,
                DisplayValue = r.DungLuongRam + "GB - " + r.LoaiRam + " - " + r.NhaSX
            }).ToList();

            ViewBag.RamId = new SelectList(ramList, "RamId", "DisplayValue");
            ViewBag.CpuId = new SelectList(db.cpus, "CpuId", "TenCpu");
            ViewBag.GpuId = new SelectList(db.gpus, "GpuId", "TenGpu");
            ViewBag.RamId = new SelectList(ramList, "RamId", "DisplayValue");
            ViewBag.SanPhamId = new SelectList(db.sanPhams.Where(o => o.SanPhamId == id), "SanPhamId", "MaSanPham");
            return View();
        }

        public ActionResult SanPhamChiTiet(int id)
        {
            var sanPhamChiTiet = db.sanPhamChiTiets.Where(o => o.SanPhamChiTietId == id).FirstOrDefault();
            foreach (var item in sanPhamChiTiet.SanPham.AnhSanPhams)
            {
                
            }
            return View(sanPhamChiTiet);
        }

        // POST: SanPhamChiTiets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SanPhamChiTietId,SanPhamId,MauSac,SoLuongDaBan,GiaTien,RamId,CpuId,GpuId,SSD")] SanPhamChiTiet sanPhamChiTiet)
        {
            if (ModelState.IsValid)
            {
                db.sanPhamChiTiets.Add(sanPhamChiTiet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CpuId = new SelectList(db.cpus, "CpuId", "TenCpu", sanPhamChiTiet.CpuId);
            ViewBag.GpuId = new SelectList(db.gpus, "GpuId", "TenGpu", sanPhamChiTiet.GpuId);
            ViewBag.RamId = new SelectList(db.rams, "RamId", "LoaiRam", sanPhamChiTiet.RamId);
            ViewBag.SanPhamId = new SelectList(db.sanPhams, "SanPhamId", "MaSanPham", sanPhamChiTiet.SanPhamId);
            return View(sanPhamChiTiet);
        }

        // GET: SanPhamChiTiets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPhamChiTiet sanPhamChiTiet = db.sanPhamChiTiets.Find(id);
            if (sanPhamChiTiet == null)
            {
                return HttpNotFound();
            }
            ViewBag.CpuId = new SelectList(db.cpus, "CpuId", "TenCpu", sanPhamChiTiet.CpuId);
            ViewBag.GpuId = new SelectList(db.gpus, "GpuId", "TenGpu", sanPhamChiTiet.GpuId);
            ViewBag.RamId = new SelectList(db.rams, "RamId", "LoaiRam", sanPhamChiTiet.RamId);
            ViewBag.SanPhamId = new SelectList(db.sanPhams, "SanPhamId", "MaSanPham", sanPhamChiTiet.SanPhamId);
            return View(sanPhamChiTiet);
        }

        // POST: SanPhamChiTiets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SanPhamChiTietId,SanPhamId,MauSac,SoLuongDaBan,GiaTien,RamId,CpuId,GpuId,SSD")] SanPhamChiTiet sanPhamChiTiet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPhamChiTiet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CpuId = new SelectList(db.cpus, "CpuId", "TenCpu", sanPhamChiTiet.CpuId);
            ViewBag.GpuId = new SelectList(db.gpus, "GpuId", "TenGpu", sanPhamChiTiet.GpuId);
            ViewBag.RamId = new SelectList(db.rams, "RamId", "LoaiRam", sanPhamChiTiet.RamId);
            ViewBag.SanPhamId = new SelectList(db.sanPhams, "SanPhamId", "MaSanPham", sanPhamChiTiet.SanPhamId);
            return View(sanPhamChiTiet);
        }

        // GET: SanPhamChiTiets/Delete/5
        public ActionResult Delete(int? id)
        {
            SanPhamChiTiet sanPhamChiTiet = db.sanPhamChiTiets.Find(id);
            db.sanPhamChiTiets.Remove(sanPhamChiTiet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddToCart()
        {

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
