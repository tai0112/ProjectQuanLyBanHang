using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectQuanLyBanHang.Models
{
    public class GPU
    {
        [Key]
        [DisplayName("Mã GPU")]
        public int GpuId { get; set; }
        [DisplayName("Tên GPU")]
        public string TenGpu { get; set; }
        [DisplayName("Nhà sản xuất")]
        public string HangSX { get; set; }
        public virtual ICollection<SanPhamChiTiet> SanPhamChiTiets { get; set; }
    }
}