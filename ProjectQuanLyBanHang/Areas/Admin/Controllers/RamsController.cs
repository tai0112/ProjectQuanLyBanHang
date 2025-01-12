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
    public class RamsController : Controller
    {
        private QuanLyBanHangDbContext db = new QuanLyBanHangDbContext();

        // GET: Rams
        public ActionResult Index()
        {
            return View(db.rams.ToList());
        }

        // GET: Rams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ram ram = db.rams.Find(id);
            if (ram == null)
            {
                return HttpNotFound();
            }
            return View(ram);
        }

        // GET: Rams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RamId,LoaiRam,MoTa,DungLuongRam,NhaSX")] Ram ram)
        {
            if (ModelState.IsValid)
            {
                db.rams.Add(ram);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ram);
        }

        // GET: Rams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ram ram = db.rams.Find(id);
            if (ram == null)
            {
                return HttpNotFound();
            }
            return View(ram);
        }

        // POST: Rams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RamId,LoaiRam,MoTa,DungLuongRam,NhaSX")] Ram ram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ram);
        }

        // GET: Rams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ram ram = db.rams.Find(id);
            if (ram == null)
            {
                return HttpNotFound();
            }
            return View(ram);
        }

        // POST: Rams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ram ram = db.rams.Find(id);
            db.rams.Remove(ram);
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
