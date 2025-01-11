using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectQuanLyBanHang.Models
{
    public class GioHangChiTiet
    {
        [Key, Column(Order = 0)]
        [DisplayName("Mã giỏ hàng")]
        public int GioHangId { get; set; }
        [Key, Column(Order = 1)]
        [DisplayName("Mã sản phẩm")]
        public int? SanPhamChiTietId { get; set; }
        [DisplayName("Số lượng")]
        public int? SoLuong { get; set; }
        [DisplayName("Thành tiền")]
        public float ThanhTien { get; set; } = 0;
        public virtual SanPhamChiTiet SanPhamChiTiet { get; set; }
        public virtual GioHang GioHang{ get; set; }

    }
}