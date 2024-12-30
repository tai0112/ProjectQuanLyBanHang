using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectQuanLyBanHang.Models;

namespace ProjectQuanLyBanHang.Controllers
{
    public class HoaDonChiTietsController : Controller
    {
        private QuanLyBanHangDbContext db = new QuanLyBanHangDbContext();

        // GET: HoaDonChiTiets
        public ActionResult Index()
        {
            var hoaDonChiTiets = db.hoaDonChiTiets.Include(h => h.HoaDon).Include(h => h.SanPham);
            return View(hoaDonChiTiets.ToList());
        }

        // GET: HoaDonChiTiets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonChiTiet hoaDonChiTiet = db.hoaDonChiTiets.Find(id);
            if (hoaDonChiTiet == null)
            {
                return HttpNotFound();
            }
            return View(hoaDonChiTiet);
        }

        // GET: HoaDonChiTiets/Create
        public ActionResult Create()
        {
            ViewBag.HoaDonId = new SelectList(db.hoaDons, "HoaDonId", "MaHoaDon");
            ViewBag.SanPhamId = new SelectList(db.sanPhams, "SanPhamId", "MaSanPham");
            return View();
        }

        // POST: HoaDonChiTiets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HoaDonId,SanPhamId,SoLuong,ThanhTien")] HoaDonChiTiet hoaDonChiTiet)
        {
            if (ModelState.IsValid)
            {
                db.hoaDonChiTiets.Add(hoaDonChiTiet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HoaDonId = new SelectList(db.hoaDons, "HoaDonId", "MaHoaDon", hoaDonChiTiet.HoaDonId);
            ViewBag.SanPhamId = new SelectList(db.sanPhams, "SanPhamId", "MaSanPham", hoaDonChiTiet.SanPhamId);
            return View(hoaDonChiTiet);
        }

        // GET: HoaDonChiTiets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonChiTiet hoaDonChiTiet = db.hoaDonChiTiets.Find(id);
            if (hoaDonChiTiet == null)
            {
                return HttpNotFound();
            }
            ViewBag.HoaDonId = new SelectList(db.hoaDons, "HoaDonId", "MaHoaDon", hoaDonChiTiet.HoaDonId);
            ViewBag.SanPhamId = new SelectList(db.sanPhams, "SanPhamId", "MaSanPham", hoaDonChiTiet.SanPhamId);
            return View(hoaDonChiTiet);
        }

        // POST: HoaDonChiTiets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HoaDonId,SanPhamId,SoLuong,ThanhTien")] HoaDonChiTiet hoaDonChiTiet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDonChiTiet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HoaDonId = new SelectList(db.hoaDons, "HoaDonId", "MaHoaDon", hoaDonChiTiet.HoaDonId);
            ViewBag.SanPhamId = new SelectList(db.sanPhams, "SanPhamId", "MaSanPham", hoaDonChiTiet.SanPhamId);
            return View(hoaDonChiTiet);
        }

        // GET: HoaDonChiTiets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonChiTiet hoaDonChiTiet = db.hoaDonChiTiets.Find(id);
            if (hoaDonChiTiet == null)
            {
                return HttpNotFound();
            }
            return View(hoaDonChiTiet);
        }

        // POST: HoaDonChiTiets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoaDonChiTiet hoaDonChiTiet = db.hoaDonChiTiets.Find(id);
            db.hoaDonChiTiets.Remove(hoaDonChiTiet);
            db.SaveChanges();
            return RedirectToAction("Index");
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
