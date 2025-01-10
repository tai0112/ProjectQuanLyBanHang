using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectQuanLyBanHang.ViewModel;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using ProjectQuanLyBanHang.Identity;

namespace ProjectQuanLyBanHang.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoan
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(RegisterVM register)
        {
            if (ModelState.IsValid)
            {
                var appDbContext = new AppDbContext();
                var userStore = new AppUserStore(appDbContext);
                var userManager = new AppUserManager(userStore);
                var passHarsh = Crypto.HashPassword(register.Password);
                var user = new AppUser()
                {
                    Email = register.Email,
                    UserName = register.UserName,
                    PasswordHash = passHarsh,
                    NgaySinh = register.NgaySinh,
                    GioiTinh = register.GioiTinh,
                    PhoneNumber = register.SDT
                };

                IdentityResult identity = userManager.Create(user);
                if (identity.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");
                    var authenManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                }
            }
            return View();
        }

        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(LoginVM lvm)
        {
            if (ModelState.IsValid)
            {
                var appDbContext = new AppDbContext();

                //Giao tiếp với cơ sở dữ liệu
                var userStore = new AppUserStore(appDbContext);

                //Dùng cung cấp các phương thức và logic như tạo người dùng mới, gán vai trò,...
                var userManager = new AppUserManager(userStore);

                var user = userManager.Find(lvm.UserName, lvm.Password);
                if (user != null)
                {
                    var authenManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                    return RedirectToAction("TrangChu", "TrangChu");
                }
            }
            return View();
        }

        public ActionResult DangXuat()
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            authenManager.SignOut();
            return RedirectToAction("TrangChu", "TrangChu");
        }
    }
}