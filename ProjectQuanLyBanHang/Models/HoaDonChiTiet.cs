using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectQuanLyBanHang.Models
{
    public class HoaDonChiTiet
    {
        [Key, Column(Order = 0)]
        [Required]
        [DisplayName("Mã hóa đơn")]
        public int HoaDonId { get; set; }
        [Required]
        [Key, Column(Order = 1)]
        [DisplayName("Mã sản phẩm")]
        public int SanPhamId { get; set; }
        [DisplayName("Số lượng")]
        [Required]
        public int SoLuong { get; set; }
        [DisplayName("Thành tiền")]
        [Required]
        public decimal ThanhTien { get; set; }
        public virtual SanPham SanPham { get; set; }
        public virtual HoaDon HoaDon{ get; set; }
    }
}