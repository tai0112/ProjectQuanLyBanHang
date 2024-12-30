using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectQuanLyBanHang.Models
{
    public class QuanLyBanHangDbContext : DbContext
    {
        public QuanLyBanHangDbContext() : base("QuanLyBanHangConnect")
        {
            
        }

        public DbSet<AnhSanPham> anhSanPhams { get; set; }
        public DbSet<GioHang> gioHangs{ get; set; }
        public DbSet<GioHangChiTiet> gioHangChiTiets { get; set; }
        public DbSet<HoaDon> hoaDons { get; set; }
        public DbSet<HoaDonChiTiet> hoaDonChiTiets { get; set; }
        public DbSet<LoaiSanPham> loaiSanPhams { get; set; }
        public DbSet<NhaCungCap> nhaCungCaps { get; set; }
        public DbSet<SanPham> sanPhams { get; set; }
        public DbSet<SanPhamChiTiet> sanPhamChiTiets { get; set; }
        public DbSet<TaiKhoan> taiKhoans { get; set; }
        public DbSet<VaiTro> vaiTros { get; set; }
        public DbSet<Ram> rams { get; set; }
        public DbSet<CPU> cpus { get; set; }
        public DbSet<GPU> gpus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Cấu hình Cascade Delete
            modelBuilder.Entity<SanPham>()
                .HasMany(sp => sp.AnhSanPhams)
                .WithRequired(ap => ap.SanPham)
                .HasForeignKey(ap => ap.SanPhamId)
                .WillCascadeOnDelete(true);
        }

    }

}