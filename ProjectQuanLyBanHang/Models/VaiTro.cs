using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectQuanLyBanHang.Models
{
    public class VaiTro
    {
        [Key]
        [DisplayName("Mã vai trò")]
        public string MaVaiTro { get; set; }
        [Required]
        [DisplayName("Tên vai trò")]
        public string TenVaiTro { get; set; }
        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
    }
}