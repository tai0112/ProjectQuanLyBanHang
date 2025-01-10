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
    public class AnhSanPhamsController : Controller
    {
        private QuanLyBanHangDbContext db = new QuanLyBanHangDbContext();

        // GET: AnhSanPhams
        public ActionResult Index()
        {
            var anhSanPhams = db.anhSanPhams;
            return View(anhSanPhams.ToList());
        }

        // GET: AnhSanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnhSanPham anhSanPham = db.anhSanPhams.Where(o => o.SanPham.SanPhamId == id).FirstOrDefault();
            if (anhSanPham == null)
            {
                return HttpNotFound();
            }
            return View(anhSanPham);
        }

        // GET: AnhSanPhams/Create
        public ActionResult Create()
        {
            ViewBag.SanPhamId = new SelectList(db.sanPhams, "SanPhamId", "MaSanPham");
            return View();
        }

        // POST: AnhSanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnhSanPhamId,TenAnh,SanPhamId,UrlAnh,NgayCapNhat")] AnhSanPham anhSanPham)
        {
            if (ModelState.IsValid)
            {
                db.anhSanPhams.Add(anhSanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SanPhamId = new SelectList(db.sanPhams, "SanPhamId", "MaSanPham", anhSanPham.SanPhamId);
            return View(anhSanPham);
        }

        // GET: AnhSanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnhSanPham anhSanPham = db.anhSanPhams.Find(id);
            if (anhSanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.SanPhamId = new SelectList(db.sanPhams, "SanPhamId", "MaSanPham", anhSanPham.SanPhamId);
            return View(anhSanPham);
        }

        // POST: AnhSanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnhSanPhamId,TenAnh,SanPhamId,UrlAnh,NgayCapNhat")] AnhSanPham anhSanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anhSanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SanPhamId = new SelectList(db.sanPhams, "SanPhamId", "MaSanPham", anhSanPham.SanPhamId);
            return View(anhSanPham);
        }

        // GET: AnhSanPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnhSanPham anhSanPham = db.anhSanPhams.Find(id);
            if (anhSanPham == null)
            {
                return HttpNotFound();
            }
            return View(anhSanPham);
        }

        // POST: AnhSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnhSanPham anhSanPham = db.anhSanPhams.Find(id);
            db.anhSanPhams.Remove(anhSanPham);
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
