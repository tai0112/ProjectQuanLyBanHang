using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Ganss.Xss;
using PagedList;
using Microsoft.Win32.SafeHandles;
using ProjectQuanLyBanHang.Models;
using System.Data.Common;
using System.Diagnostics;
using AngleSharp.Io;
using System.Web.DynamicData;
using ProjectQuanLyBanHang.Filters;

namespace ProjectQuanLyBanHang.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class SanPhamsController : Controller
    {
        QuanLyBanHangDbContext db = new QuanLyBanHangDbContext();
        public ActionResult Index(int? page, string search, string searchType, string status, string picture)
        {
            if (page == null)
            {
                page = 1;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var sanPhams = db.sanPhams.Include(s => s.NhaCungCap);
            if (status == "pass")
            {
                sanPhams = db.sanPhams.Where(o => o.TrangThai == true);
            }
            else if (status == "notPass")
            {
                sanPhams = db.sanPhams.Where(o => o.TrangThai != true);
            }

            if (picture == "picture")
            {
                sanPhams = db.sanPhams.Where(o => o.AnhSanPhams.Count() > 0);
            }
            else if (picture == "notPicture")
            {
                sanPhams = db.sanPhams.Where(o => o.AnhSanPhams.Count == 0);
            }

            if (!string.IsNullOrEmpty(search))
            {
                if (!string.IsNullOrEmpty(searchType))
                {
                    switch (searchType)
                    {
                        case "SanPhamId":
                            sanPhams = sanPhams.Where(o => o.MaSanPham == search);
                            break;
                        case "MaNhaCungCap":
                            sanPhams = sanPhams.Where(o => o.NhaCungCap.TenNhaCungCap == search);
                            break;
                        case "TenSanPham":
                            sanPhams = sanPhams.Where(o => o.TenSanPham.Contains(search));
                            break;
                        case "NgayDuyet":
                            sanPhams = sanPhams.Where(o => DbFunctions.TruncateTime(o.NgayCapNhat) == DateTime.Parse(search));
                            break;
                        case "NgayTao":
                            sanPhams = sanPhams.Where(o => DbFunctions.TruncateTime(o.NgayTao) == DateTime.Parse(search));
                            break;
                        case "NgayCapNhat":
                            sanPhams = sanPhams.Where(o => DbFunctions.TruncateTime(o.NgayCapNhat) == DateTime.Parse(search));
                            break;
                    }
                }
                else
                {
                    sanPhams = sanPhams.Where(o => o.TenSanPham.Contains(search));
                }
            }
            ViewBag.SoLuongTimDuoc = sanPhams.Count();
            
            return View(sanPhams.OrderBy(o => o.MaSanPham).ToPagedList(pageNumber, pageSize));
        }

        

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.sanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        public ActionResult Create()
        {
            ViewBag.MaNhaCungCap = new SelectList(db.nhaCungCaps, "MaNhaCungCap", "TenNhaCungCap");
            ViewBag.MaLoaiSanPham = new SelectList(db.loaiSanPhams, "MaLoaiSanPham", "TenLoaiSanPham");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SanPhamId,MaSanPham,TenSanPham,MoTa,TrangThai,MaNhaCungCap,MaLoaiSanPham")] SanPham sanPham, IEnumerable<HttpPostedFileBase> fAnhSanPham)
        {
            //Lưu lại danh sách ảnh ban đầu
            if (ModelState.IsValid)
            {
                int checkMa = db.sanPhams.Count(o => o.MaSanPham == sanPham.MaSanPham);
                if (checkMa == 0)
                {
                    //Kiểm tra nếu phần file của ảnh sản phẩm trống thì thực hiện sửa đổi hình ảnh còn không thì giữ nguyên
                    if (fAnhSanPham != null && fAnhSanPham.FirstOrDefault() != null)
                    {
                        AnhSanPham anhSanPham = null;
                        string imageName;
                        foreach (HttpPostedFileBase file in fAnhSanPham)
                        {
                            imageName = System.IO.Path.GetFileName(file.FileName);
                            string path = Path.Combine("~/Content/Images/AnhSanPham", imageName);
                            if (System.IO.File.Exists(path))
                            {
                                TempData["Error"] = "Ảnh sản phẩm đã tồn tại";
                            }
                            else
                            {
                                file.SaveAs(Server.MapPath(path));
                                anhSanPham = new AnhSanPham(sanPham.TenSanPham, sanPham.SanPhamId, imageName);
                                db.anhSanPhams.Add(anhSanPham);
                            }
                        }
                    }
                    //Tránh tấn công XSS
                    var sanitizer = new HtmlSanitizer();
                    var sanitizerContent = sanitizer.Sanitize(sanPham.MoTa);
                    sanPham.MoTa = sanitizerContent;
                    //Cập nhật thời gian được duyệt
                    if (sanPham.TrangThai == true)
                    {
                        DateTime ngayCapNhat = DateTime.Now;
                        sanPham.NgayDuyet = ngayCapNhat.ToLocalTime();
                    }
                    db.sanPhams.Add(sanPham);
                    db.SaveChanges();
                    TempData["Success"] = "Thêm thành công sản phẩm";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = "Mã sản phẩm đã tồn tại";
                }
            }
            ViewBag.MaNhaCungCap = new SelectList(db.nhaCungCaps, "MaNhaCungCap", "TenNhaCungCap", sanPham.MaNhaCungCap);
            ViewBag.MaLoaiSanPham = new SelectList(db.loaiSanPhams, "MaLoaiSanPham", "TenLoaiSanPham", sanPham.MaLoaiSanPham);
            return View(sanPham);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.sanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNhaCungCap = new SelectList(db.nhaCungCaps, "MaNhaCungCap", "TenNhaCungCap", sanPham.MaNhaCungCap);
            ViewBag.MaLoaiSanPham = new SelectList(db.loaiSanPhams, "MaLoaiSanPham", "TenLoaiSanPham", sanPham.MaLoaiSanPham);
            return View(sanPham);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SanPhamId,MaSanPham,TenSanPham,MoTa,TrangThai,MaNhaCungCap,NgayTao,MaLoaiSanPham")] SanPham sanPham, IEnumerable<HttpPostedFileBase> fAnhSanPham)
        {
            var anhSanPhams = db.anhSanPhams.Where(o => o.AnhSanPhamId == sanPham.SanPhamId).ToList();
            if (ModelState.IsValid)
            {
                if (fAnhSanPham != null && fAnhSanPham.FirstOrDefault() != null)
                {
                    string path = Server.MapPath("~/Content/Images/AnhSanPham/");
                    AnhSanPham anhSanPham;
                    DataProvider.DeleteMultipleImage(path, anhSanPhams);
                    string imageName;
                    foreach (HttpPostedFileBase file in fAnhSanPham)
                    {
                        imageName = System.IO.Path.GetFileName(file.FileName);
                        string folderPath = Path.Combine("~/Content/Images/AnhSanPham", imageName);
                        file.SaveAs(Server.MapPath(folderPath));
                        anhSanPham = new AnhSanPham(sanPham.TenSanPham, sanPham.SanPhamId, imageName);
                        db.anhSanPhams.Add(anhSanPham);
                    }
                }
                sanPham.NgayCapNhat = DateTime.Now;
                if (sanPham.TrangThai)
                {
                    sanPham.NgayDuyet = DateTime.Now;
                }
                db.Entry(sanPham).State = EntityState.Modified;
                TempData["Success"] = "Sửa thành công sản phẩm";
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNhaCungCap = new SelectList(db.nhaCungCaps, "MaNhaCungCap", "TenNhaCungCap", sanPham.MaNhaCungCap);
            ViewBag.MaLoaiSanPham = new SelectList(db.loaiSanPhams, "MaLoaiSanPham", "TenLoaiSanPham", sanPham.MaLoaiSanPham);
            return View(sanPham);
        }

        public ActionResult Delete(int? id)
        {
            SanPham sanPham = db.sanPhams.Find(id);
            var anhSanPhams = db.anhSanPhams.Where(o => o.SanPhamId == id).ToList();
            string path = Server.MapPath("~/Content/Images/AnhSanPham/");
            DataProvider.DeleteMultipleImage(path, anhSanPhams);
            db.sanPhams.Remove(sanPham);
            db.SaveChanges();
            TempData["Success"] = "Xóa thành công sản phẩm";
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
