using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectQuanLyBanHang.Models
{
    public class Ram
    {
        [Key]
        [DisplayName("Mã RAM")]
        public int RamId { get; set; }
        [DisplayName("Loại RAM")]
        [Required]
        public string LoaiRam { get; set; }
        [DisplayName("Mô tả")]
        [Required]
        public string MoTa { get; set; }
        [DisplayName("Dung lượng RAM")]
        [Required]
        public int DungLuongRam { get; set; }
        [Required]
        [DisplayName("Nhà sản xuất")]
        public string NhaSX { get; set; }
        public virtual ICollection<SanPhamChiTiet> SanPhamChiTiets { get; set; }
    }
}