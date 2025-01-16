using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjectQuanLyBanHang.Models;

namespace ProjectQuanLyBanHang.Identity
{
    public class AppUser : IdentityUser
    {
        public string HoVaTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string AnhDaiDien { get; set; }

    }
}