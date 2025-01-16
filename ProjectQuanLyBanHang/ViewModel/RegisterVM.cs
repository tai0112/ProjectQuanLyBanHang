using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectQuanLyBanHang.ViewModel
{
    public class RegisterVM
    {
        [Required]
        public string HoVaTen { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string SDT { get; set; }
        public DateTime? NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
    }
}