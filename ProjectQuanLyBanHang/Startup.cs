using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjectQuanLyBanHang.Identity;

[assembly: OwinStartup(typeof(ProjectQuanLyBanHang.Startup))]

namespace ProjectQuanLyBanHang
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/TaiKhoan/DangNhap")
            });
            this.CreateRolesAndUsers();
        }

        public void CreateRolesAndUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new AppDbContext()));

            var appDbContext = new AppDbContext();
            var appUserStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(appUserStore);

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
            }

            if (userManager.FindByName("admin") == null)
            {
                var user = new AppUser();
                user.UserName = "admin";
                user.Email = "admin@gmail.com";
                string userPass = "admin123";

                var checkUser = userManager.Create(user, userPass);

                if (checkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }

            if (userManager.FindByName("manager") == null)
            {
                var user = new AppUser();
                user.UserName = "manager";
                user.Email = "manager@gmail.com";
                string userPass = "manager123";

                var checkUser = userManager.Create(user, userPass);

                if (checkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Manager");
                }
            }

        }


    }
}
