using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectQuanLyBanHang.Filters;
using ProjectQuanLyBanHang.Identity;

namespace ProjectQuanLyBanHang.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class TaiKhoansController : Controller
    {
        // GET: Admin/TaiKhoans
        AppDbContext db = new AppDbContext();
        public ActionResult Index()
        {
            var listUsers = db.Users.ToList();
            return View(listUsers);
        }
    }
}