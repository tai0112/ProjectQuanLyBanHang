using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectQuanLyBanHang.Filters;

namespace ProjectQuanLyBanHang.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class TrangChuController : Controller
    {
        // GET: Admin/TrangChu
        public ActionResult Index()
        {
            return View();
        }
    }
}