using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web;

namespace ProjectQuanLyBanHang.Models
{
    public class SanPhamChiTiet
    {
        [Key]
        public int SanPhamChiTietId { get; set; }
        [DisplayName("Sản phẩm ID")]
        [Required]
        public int SanPhamId { get; set; }
        [DisplayName("Màu sắc")]
        [Required]
        public string MauSac { get; set; }
        [DisplayName("Số lượng đã bán")]
        public int SoLuongDaBan { get; set; }
        [DisplayName("Giá tiền")]
        [Required]
        public int GiaTien { get; set; }
        [DisplayName("RAM")]
        [Required]
        public int RamId { get; set; }
        [DisplayName("CPU")]
        [Required]
        public int CpuId { get; set; }
        [DisplayName("GPU")]
        [Required]
        public int GpuId { get; set; }
        [DisplayName("SSD")]
        public int SSD { get; set; } = 512;
        public virtual SanPham SanPham { get; set; }
        public virtual Ram Ram { get; set; }
        public virtual CPU CPU { get; set; }
        public virtual GPU Gpu { get; set; }
        public virtual ICollection<GioHangChiTiet> GioHangChiTiets { get; set; }
        
    }
}