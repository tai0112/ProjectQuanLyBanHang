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
using System.Web.UI.WebControls;
using ProjectQuanLyBanHang.Models;

namespace ProjectQuanLyBanHang.Controllers
{
    public class TaiKhoanController : Controller
    {
        private QuanLyBanHangDbContext db = new QuanLyBanHangDbContext();
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

                var taiKhoan = new TaiKhoan();
                taiKhoan.MaTaiKhoan = user.Id;
                taiKhoan.Email = user.Email;
                taiKhoan.TenDangNhap = user.UserName;
                taiKhoan.MatKhau = user.PasswordHash;
                taiKhoan.GioiTinh = user.GioiTinh;
                taiKhoan.DienThoai = user.PhoneNumber;
                taiKhoan.Email = user.Email;
                taiKhoan.NgaySinh = (DateTime)user.NgaySinh;

                var gioHang = new GioHang();
                gioHang.TaiKhoanId = taiKhoan.TaiKhoanId;
                var gioHangChiTiet = new GioHangChiTiet();
                gioHangChiTiet.GioHangId = gioHang.GioHangId;
                

                IdentityResult identity = userManager.Create(user);
                if (identity.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");
                    //Tạo một đối tượng xác thực nhằm thao tác với xác thực
                    var authenManager = HttpContext.GetOwinContext().Authentication;

                    //Tạo một đối tượng nhận dạng, dùng để lưu thông tin người dùng trong quá trình đăng nhập
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                    //Thực hiện đăng nhập người dùng với thông tin đã tạo ở trên
                    authenManager.SignIn(new AuthenticationProperties(), userIdentity);

                }else
                {

                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult DangKyMoi(RegisterVM rvm)
        {
            if (ModelState.IsValid)
            {
                var appDbContext = new AppDbContext();
                var userStore = new AppUserStore(appDbContext);
                var userManager = new AppUserManager(userStore);
                string passHash = Crypto.HashPassword(rvm.Password);
                var user = new AppUser()
                {
                    UserName = rvm.UserName,
                    Email = rvm.Email,
                    PasswordHash = passHash,
                };

                IdentityResult identity = userManager.Create(user);
                if (identity.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");

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