using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectQuanLyBanHang.Models
{
    public class NhaCungCap
    {

        [Key]
        [DisplayName("Mã nhà cung cấp")]
        [Required]
        public string MaNhaCungCap { get; set; }
        [DisplayName("Tên nhà cung cấp")]
        [Required]
        public string TenNhaCungCap { get; set; }
        [DisplayName("Ảnh nhà cung cấp")]
        public string AnhNhaCungCap { get; set; }
    }
}