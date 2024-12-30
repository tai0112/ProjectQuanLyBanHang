using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ProjectQuanLyBanHang.Models;

namespace ProjectQuanLyBanHang.Controllers
{
    public class NhaCungCapsController : Controller
    {
        QuanLyBanHangDbContext db = new QuanLyBanHangDbContext();
        // GET: NhaCungCaps
        public ActionResult Index()
        {
            return View(db.nhaCungCaps.ToList());
        }

        // GET: NhaCungCaps/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaCungCap nhaCungCap = db.nhaCungCaps.Find(id);
            if (nhaCungCap == null)
            {
                return HttpNotFound();
            }
            return View(nhaCungCap);
        }

        // GET: NhaCungCaps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhaCungCaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NhaCungCap nhaCungCap, HttpPostedFileBase fAnhNhaCungCap)
        {
            if (ModelState.IsValid)
            {
                if (fAnhNhaCungCap != null && fAnhNhaCungCap.ContentLength > 0)
                {
                    string imageName = System.IO.Path.GetFileName(fAnhNhaCungCap.FileName);
                    fAnhNhaCungCap.SaveAs(Server.MapPath("~/Content/Images/AnhNhaCungCap/" + imageName));
                    nhaCungCap.AnhNhaCungCap = imageName;
                }
                if (nhaCungCap != null)
                {
                    db.nhaCungCaps.Add(nhaCungCap);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(nhaCungCap);
        }

        // GET: NhaCungCaps/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaCungCap nhaCungCap = db.nhaCungCaps.Find(id);
            if (nhaCungCap == null)
            {
                return HttpNotFound();
            }
            return View(nhaCungCap);
        }

        // POST: NhaCungCaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNhaCungCap,TenNhaCungCap,AnhNhaCungCap")] NhaCungCap nhaCungCap, HttpPostedFileBase fAnhNhaCungCap)
        {
            NhaCungCap ncc = db.nhaCungCaps.Find(nhaCungCap.MaNhaCungCap);
            string preImg = ncc.AnhNhaCungCap;
            db.Entry(ncc).State = EntityState.Detached;
            db.nhaCungCaps.Attach(nhaCungCap);
            if (ModelState.IsValid)
            {
                string path = Server.MapPath("~/Content/Images/AnhNhaCungCap/");
                if (fAnhNhaCungCap != null)
                {
                    DataProvider.DeleteImage(preImg, path);
                    string fileName = System.IO.Path.GetFileName(fAnhNhaCungCap.FileName);
                    fAnhNhaCungCap.SaveAs(Server.MapPath("~/Content/Images/AnhNhaCungCap/" + fileName));
                    nhaCungCap.AnhNhaCungCap = fileName;
                }else
                {
                    nhaCungCap.AnhNhaCungCap = preImg;
                }
                db.Entry(nhaCungCap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhaCungCap);
        }

        // GET: NhaCungCaps/Delete/5
        public ActionResult Delete(string id)
        {
            NhaCungCap nhaCungCap = db.nhaCungCaps.Find(id);
            string fileName = nhaCungCap.AnhNhaCungCap;
            string folderPath = Server.MapPath("~/Content/Images/AnhNhaCungCap");
            DataProvider.DeleteImage(fileName, folderPath);
            db.nhaCungCaps.Remove(nhaCungCap);
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
