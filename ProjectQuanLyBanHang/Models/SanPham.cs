using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectQuanLyBanHang.Models
{
    public class SanPham
    {
        [Key]
        [DisplayName("Sản phẩm ID")]
        public int SanPhamId { get; set; }
        [Required]
        [DisplayName("Mã sản phẩm")]
        public string MaSanPham { get; set; }
        [DisplayName("Tên sản phẩm")]
        [Required]
        public string TenSanPham { get; set; }
        [AllowHtml]
        [DisplayName("Mô tả")]
        public string MoTa { get; set; }
        [Required]
        [DisplayName("Trạng thái")]
        public bool TrangThai { get; set; }
        [Required]
        [DisplayName("Mã nhà cung cấp")]
        public string MaNhaCungCap { get; set; }
        [DisplayName("Ngày tạo")]
        public DateTime NgayTao { get; set; } = DateTime.Now;
        [DisplayName("Ngày cập nhật")]
        public DateTime NgayCapNhat { get; set; } = DateTime.Now;
        [DisplayName("Ngày duyệt")]
        public DateTime? NgayDuyet { get; set; }
        [DisplayName("Loại sản phẩm")]
        public int MaLoaiSanPham { get; set; } = 11;
        public virtual LoaiSanPham LoaiSanPham { get; set; }
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        public virtual ICollection<AnhSanPham> AnhSanPhams { get; set; }
        public virtual ICollection<SanPhamChiTiet> SanPhamChiTiets { get; set; }
        public virtual NhaCungCap NhaCungCap { get; set; }
    }
}