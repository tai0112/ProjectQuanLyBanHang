using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectQuanLyBanHang.Models
{
    public class CPU
    {
        [Key]
        [DisplayName("Mã CPU")]
        public int CpuId { get; set; }
        [DisplayName("Tên CPU")]
        public string TenCpu { get; set; }
        [DisplayName("Nhà sản xuất")]
        public string NhaSX { get; set; }
        [DisplayName("Mô tả")]
        public string MoTa { get; set; }
        public virtual ICollection<SanPhamChiTiet> SanPhamChiTiets { get; set; }
    }
}