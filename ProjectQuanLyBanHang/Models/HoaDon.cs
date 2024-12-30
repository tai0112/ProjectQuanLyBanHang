using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectQuanLyBanHang.Models
{
    public class HoaDon
    {
        [Key]
        public int HoaDonId { get; set; }
        [DisplayName("Mã tài khoản")]
        public int TaiKhoanId { get; set; }
        [Required]
        [DisplayName("Mã hóa đơn")]
        public string MaHoaDon { get; set; }
        [Required]
        [DisplayName("Tên hóa đơn")]
        public string TenHoaDon { get; set; }
        [DisplayName("Thành tiền")]
        public decimal ThanhTien { get; set; }
        [DisplayName("Trạng thái")]
        public bool TrangThai { get; set; }
        [DisplayName("Ngày thanh toán")]
        public DateTime NgayThanhToan { get; set; }
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets{ get; set; }
    }
}