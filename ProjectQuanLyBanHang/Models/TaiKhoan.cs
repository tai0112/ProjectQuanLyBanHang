using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectQuanLyBanHang.Models
{
    public class TaiKhoan
    {
        [Key]
        [DisplayName("Tài khoản ID")]
        public int TaiKhoanId { get; set; }
        [DisplayName("Mã tài khoản")]
        [Required]
        public string MaTaiKhoan { get; set; }
        [Required]
        [DisplayName("Họ và tên")]
        public string HoVaTen { get; set; }
        [DisplayName("Tên đăng nhập")]
        [Required]
        public string TenDangNhap { get; set; }
        [DisplayName("Mật khẩu")]
        [DataType(DataType.Password)]
        [Required]
        public string MatKhau { get; set; }
        [DisplayName("Điện thoại")]
        [Required]
        [Phone]
        public string DienThoai { get; set; }
        [DisplayName("Địa chỉ email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [DisplayName("Giới tính")]
        [Required]
        public bool GioiTinh { get; set; }
        [DisplayName("Ngày tạo")]
        public DateTime NgayTao { get; set; } = DateTime.Now;
        [DisplayName("Ngày sinh")]
        [Required]
        public DateTime NgaySinh { get; set; }
        [DisplayName("Ảnh đại diện")]
        public string AnhDaiDien { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}