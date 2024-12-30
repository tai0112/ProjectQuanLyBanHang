using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectQuanLyBanHang.Models
{
    public class AnhSanPham
    {
        [Key]
        [Required]
        [DisplayName("Id ảnh sản phẩm")]
        public int AnhSanPhamId { get; set; }
        [Required]
        [DisplayName("Tên ảnh")]
        public string TenAnh { get; set; }
        public int SanPhamId { get; set; }
        [Required]
        [DisplayName("Đường dẫn ảnh")]
        public string UrlAnh { get; set; }
        [DisplayName("Ngày cập nhật")]
        public DateTime NgayCapNhat { get; set; } = DateTime.Now;
        public virtual SanPham SanPham { get; set; }
        public AnhSanPham(string tenAnh, int sanPhamId, string urlAnh)
        {
            TenAnh = tenAnh;
            SanPhamId = sanPhamId;
            UrlAnh = urlAnh;
        }
        public AnhSanPham()
        {
            
        }
    }
}