using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectQuanLyBanHang.Filters;
using ProjectQuanLyBanHang.Models;

namespace ProjectQuanLyBanHang.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class GioHangChiTietsController : Controller
    {
        private QuanLyBanHangDbContext db = new QuanLyBanHangDbContext();

        // GET: GioHangChiTiets
        public ActionResult Index()
        {
            var gioHangChiTiets = db.gioHangChiTiets.Include(g => g.GioHang).Include(g => g.SanPhamChiTiet);
            return View(gioHangChiTiets.ToList());
        }

        // GET: GioHangChiTiets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioHangChiTiet gioHangChiTiet = db.gioHangChiTiets.Find(id);
            if (gioHangChiTiet == null)
            {
                return HttpNotFound();
            }
            return View(gioHangChiTiet);
        }

        // GET: GioHangChiTiets/Create
        public ActionResult Create()
        {
            ViewBag.GioHangId = new SelectList(db.gioHangs, "GioHangId", "GioHangId");
            ViewBag.SanPhamChiTietId = new SelectList(db.sanPhamChiTiets, "SanPhamChiTietId", "MauSac");
            return View();
        }

        // POST: GioHangChiTiets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GioHangId,SanPhamChiTietId,SoLuong,ThanhTien")] GioHangChiTiet gioHangChiTiet)
        {
            if (ModelState.IsValid)
            {
                db.gioHangChiTiets.Add(gioHangChiTiet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GioHangId = new SelectList(db.gioHangs, "GioHangId", "GioHangId", gioHangChiTiet.GioHangId);
            ViewBag.SanPhamChiTietId = new SelectList(db.sanPhamChiTiets, "SanPhamChiTietId", "MauSac", gioHangChiTiet.SanPhamChiTietId);
            return View(gioHangChiTiet);
        }

        // GET: GioHangChiTiets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioHangChiTiet gioHangChiTiet = db.gioHangChiTiets.Find(id);
            if (gioHangChiTiet == null)
            {
                return HttpNotFound();
            }
            ViewBag.GioHangId = new SelectList(db.gioHangs, "GioHangId", "GioHangId", gioHangChiTiet.GioHangId);
            ViewBag.SanPhamChiTietId = new SelectList(db.sanPhamChiTiets, "SanPhamChiTietId", "MauSac", gioHangChiTiet.SanPhamChiTietId);
            return View(gioHangChiTiet);
        }

        // POST: GioHangChiTiets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GioHangId,SanPhamChiTietId,SoLuong,ThanhTien")] GioHangChiTiet gioHangChiTiet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gioHangChiTiet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GioHangId = new SelectList(db.gioHangs, "GioHangId", "GioHangId", gioHangChiTiet.GioHangId);
            ViewBag.SanPhamChiTietId = new SelectList(db.sanPhamChiTiets, "SanPhamChiTietId", "MauSac", gioHangChiTiet.SanPhamChiTietId);
            return View(gioHangChiTiet);
        }

        // GET: GioHangChiTiets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioHangChiTiet gioHangChiTiet = db.gioHangChiTiets.Find(id);
            if (gioHangChiTiet == null)
            {
                return HttpNotFound();
            }
            return View(gioHangChiTiet);
        }

        // POST: GioHangChiTiets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GioHangChiTiet gioHangChiTiet = db.gioHangChiTiets.Find(id);
            db.gioHangChiTiets.Remove(gioHangChiTiet);
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
