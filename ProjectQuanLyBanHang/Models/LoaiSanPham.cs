using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectQuanLyBanHang.Models
{
    public class LoaiSanPham
    {
        [Key]
        [DisplayName("Mã loại sản phẩm")]
        public int MaLoaiSanPham { get; set; }
        [Required]
        [DisplayName("Tên loại sản phẩm")]
        public string TenLoaiSanPham { get; set; }
        [DisplayName("Ảnh loại sản phẩm")]
        public string AnhLoaiSanPham { get; set; }
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}