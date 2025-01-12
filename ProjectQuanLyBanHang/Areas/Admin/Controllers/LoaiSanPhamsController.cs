using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Generator;
using ProjectQuanLyBanHang.Filters;
using ProjectQuanLyBanHang.Models;

namespace ProjectQuanLyBanHang.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class LoaiSanPhamsController : Controller
    {
        QuanLyBanHangDbContext db = new QuanLyBanHangDbContext();
        // GET: LoaiSanPhams
        public ActionResult Index()
        {
            return View(db.loaiSanPhams.ToList());
        }

        // GET: LoaiSanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSanPham loaiSanPham = db.loaiSanPhams.Find(id);
            if (loaiSanPham == null)
            {
                return HttpNotFound();
            }
            return View(loaiSanPham);
        }

        // GET: LoaiSanPhams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiSanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoaiSanPham,TenLoaiSanPham")] LoaiSanPham loaiSanPham, HttpPostedFileBase fAnhLoaiSanPham)
        {
            if (ModelState.IsValid)
            {
                if (fAnhLoaiSanPham != null && fAnhLoaiSanPham.ContentLength > 0)
                {
                    string imageName = System.IO.Path.GetFileName(fAnhLoaiSanPham.FileName);
                    fAnhLoaiSanPham.SaveAs(Server.MapPath("~/Content/Images/AnhLoaiSanPham/" + imageName));
                    loaiSanPham.AnhLoaiSanPham = imageName;
                }   

                if (loaiSanPham != null)
                {
                    db.loaiSanPhams.Add(loaiSanPham);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(loaiSanPham);
        }

        // GET: LoaiSanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSanPham loaiSanPham = db.loaiSanPhams.Find(id);
            if (loaiSanPham == null)
            {
                return HttpNotFound();
            }
            return View(loaiSanPham);
        }

        // POST: LoaiSanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoaiSanPham,TenLoaiSanPham,AnhLoaiSanPham")] LoaiSanPham loaiSanPham, HttpPostedFileBase fAnhLoaiSanPham)
        {
            string folderPath = Server.MapPath("~/Content/Images/AnhLoaiSanPham/");
            if (ModelState.IsValid)
            {
                string preImage = "";
                LoaiSanPham lsp = db.loaiSanPhams.Find(loaiSanPham.MaLoaiSanPham);
                //Lưu lại thông tin hình ảnh trước để so sáng nếu không cập nhật lại ảnh thì sử dụng lại
                preImage = lsp.AnhLoaiSanPham;
                //Dùng để bỏ qua thực thể lsp giúp entity không theo dõi nữa giúp tránh xung đột bên dưới
                db.Entry(lsp).State = EntityState.Detached;
                //Theo dõi thực thể loaiSanPham và đánh dấu là chưa sửa đổi
                db.loaiSanPhams.Attach(loaiSanPham);

                if (fAnhLoaiSanPham != null)
                {
                    string imageName = System.IO.Path.GetFileName(fAnhLoaiSanPham.FileName);
                    fAnhLoaiSanPham.SaveAs(Server.MapPath("~/Content/Images/AnhLoaiSanPham/" + imageName));

                    if(!String.IsNullOrEmpty(preImage))
                    {
                        DataProvider.DeleteImage(preImage, folderPath);
                    }
                    loaiSanPham.AnhLoaiSanPham = imageName;
                }else
                {
                    loaiSanPham.AnhLoaiSanPham = preImage;
                }

                if (lsp != null)
                {
                    db.Entry(loaiSanPham).State = EntityState.Modified;
                }else
                {
                    db.loaiSanPhams.Add(lsp);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiSanPham);
        }

        // GET: LoaiSanPhams/Delete/5
        public ActionResult Delete(int id)
        {
            LoaiSanPham loaiSanPham = db.loaiSanPhams.Find(id);
            string fileName = loaiSanPham.AnhLoaiSanPham;
            string folderPath = Server.MapPath("~/Content/Images/AnhLoaiSanPham/");
            DataProvider.DeleteImage(fileName, folderPath);
            db.loaiSanPhams.Remove(loaiSanPham);
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
