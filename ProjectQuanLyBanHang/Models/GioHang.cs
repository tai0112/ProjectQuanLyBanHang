using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectQuanLyBanHang.Models
{
    public class GioHang
    {
        [Key]
        [DisplayName("Mã giỏ hàng")]
        public int GioHangId { get; set; }
        [Required]
        [DisplayName("Mã tài khoản")]
        public int TaiKhoanId { get; set; }
        [Required]
        [DisplayName("Thành tiền")]
        public decimal ThanhTien { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
        public virtual ICollection<GioHangChiTiet> GioHangChiTiets{ get; set; }
    }
}