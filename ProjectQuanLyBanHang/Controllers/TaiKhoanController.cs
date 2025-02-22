﻿using System;
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
using System.Diagnostics;

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
            try
            {
                if (ModelState.IsValid)
                {
                    var appDbContext = new AppDbContext();
                    var userStore = new AppUserStore(appDbContext);
                    var userManager = new AppUserManager(userStore);
                    var passHarsh = Crypto.HashPassword(register.Password);

                    var user = new AppUser()
                    {
                        HoVaTen = register.HoVaTen,
                        Email = register.Email,
                        UserName = register.UserName,
                        PasswordHash = passHarsh,
                        NgaySinh = register.NgaySinh,
                        GioiTinh = register.GioiTinh,
                        PhoneNumber = register.SDT
                    };

                    var taiKhoan = new TaiKhoan();
                    taiKhoan.HoVaTen = user.HoVaTen;
                    taiKhoan.MaTaiKhoan = user.Id;
                    taiKhoan.Email = user.Email;
                    taiKhoan.TenDangNhap = user.UserName;
                    taiKhoan.MatKhau = user.PasswordHash;
                    taiKhoan.GioiTinh = user.GioiTinh;
                    taiKhoan.DienThoai = user.PhoneNumber;
                    taiKhoan.Email = user.Email;
                    taiKhoan.NgaySinh = (DateTime)user.NgaySinh;
                    db.taiKhoans.Add(taiKhoan);
                    db.SaveChanges();

                    IdentityResult identity = userManager.Create(user);
                    if (identity.Succeeded)
                    {
                        TempData["Success"] = "Tạo tài khoản thành công";
                    }
                }

                return RedirectToAction("DangNhap", "TaiKhoan");

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return View();
            }
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
                    var taiKhoanId = db.taiKhoans.Where(o => o.MaTaiKhoan == user.Id).First().TaiKhoanId;
                    Session["TaiKhoanId"] = taiKhoanId;
                    if (userManager.IsInRole(user.Id, "Admin"))
                    {
                        return RedirectToAction("Index", "TrangChu", new { area = "Admin" });
                    }
                    else
                    {
                        return RedirectToAction("TrangChu", "TrangChu");
                    }
                }
            }
            return View();
        }

        public ActionResult DangXuat()
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            authenManager.SignOut();
            Session["SoLuongSanPham"] = null;
            return RedirectToAction("TrangChu", "TrangChu");
        }
    }
}