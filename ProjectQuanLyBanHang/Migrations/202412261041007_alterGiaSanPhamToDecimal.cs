namespace ProjectQuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterGiaSanPhamToDecimal : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SanPhams", "MaNhaCungCap", "dbo.NhaCungCaps");
            DropForeignKey("dbo.TaiKhoans", "MaVaiTro", "dbo.VaiTroes");
            DropIndex("dbo.SanPhams", new[] { "MaNhaCungCap" });
            DropIndex("dbo.TaiKhoans", new[] { "MaVaiTro" });
            AlterColumn("dbo.SanPhams", "MaSanPham", c => c.String(nullable: false));
            AlterColumn("dbo.SanPhams", "TenSanPham", c => c.String(nullable: false));
            AlterColumn("dbo.SanPhams", "MoTa", c => c.String(nullable: false));
            AlterColumn("dbo.SanPhams", "MaNhaCungCap", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.TaiKhoans", "MaTaiKhoan", c => c.String(nullable: false));
            AlterColumn("dbo.TaiKhoans", "TenDangNhap", c => c.String(nullable: false));
            AlterColumn("dbo.TaiKhoans", "MatKhau", c => c.String(nullable: false));
            AlterColumn("dbo.TaiKhoans", "DienThoai", c => c.String(nullable: false));
            AlterColumn("dbo.TaiKhoans", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.TaiKhoans", "MaVaiTro", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.TaiKhoans", "AnhDaiDien", c => c.String(nullable: false));
            AlterColumn("dbo.HoaDonChiTiets", "ThanhTien", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.VaiTroes", "TenVaiTro", c => c.String(nullable: false));
            AlterColumn("dbo.LoaiSanPhams", "TenLoaiSanPham", c => c.String(nullable: false));
            AlterColumn("dbo.LoaiSanPhams", "AnhLoaiSanPham", c => c.String(nullable: false));
            AlterColumn("dbo.NhaCungCaps", "TenNhaCungCap", c => c.String(nullable: false));
            AlterColumn("dbo.NhaCungCaps", "AnhNhaCungCap", c => c.String(nullable: false));
            AlterColumn("dbo.SanPhamChiTiets", "MauSac", c => c.String(nullable: false));
            AlterColumn("dbo.Rams", "LoaiRam", c => c.String(nullable: false));
            AlterColumn("dbo.Rams", "MoTa", c => c.String(nullable: false));
            AlterColumn("dbo.Rams", "NhaSX", c => c.String(nullable: false));
            CreateIndex("dbo.SanPhams", "MaNhaCungCap");
            CreateIndex("dbo.TaiKhoans", "MaVaiTro");
            AddForeignKey("dbo.SanPhams", "MaNhaCungCap", "dbo.NhaCungCaps", "MaNhaCungCap", cascadeDelete: true);
            AddForeignKey("dbo.TaiKhoans", "MaVaiTro", "dbo.VaiTroes", "MaVaiTro", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaiKhoans", "MaVaiTro", "dbo.VaiTroes");
            DropForeignKey("dbo.SanPhams", "MaNhaCungCap", "dbo.NhaCungCaps");
            DropIndex("dbo.TaiKhoans", new[] { "MaVaiTro" });
            DropIndex("dbo.SanPhams", new[] { "MaNhaCungCap" });
            AlterColumn("dbo.Rams", "NhaSX", c => c.String());
            AlterColumn("dbo.Rams", "MoTa", c => c.String());
            AlterColumn("dbo.Rams", "LoaiRam", c => c.String());
            AlterColumn("dbo.SanPhamChiTiets", "MauSac", c => c.String());
            AlterColumn("dbo.NhaCungCaps", "AnhNhaCungCap", c => c.String());
            AlterColumn("dbo.NhaCungCaps", "TenNhaCungCap", c => c.String());
            AlterColumn("dbo.LoaiSanPhams", "AnhLoaiSanPham", c => c.String());
            AlterColumn("dbo.LoaiSanPhams", "TenLoaiSanPham", c => c.String());
            AlterColumn("dbo.VaiTroes", "TenVaiTro", c => c.String());
            AlterColumn("dbo.HoaDonChiTiets", "ThanhTien", c => c.Int(nullable: false));
            AlterColumn("dbo.TaiKhoans", "AnhDaiDien", c => c.String());
            AlterColumn("dbo.TaiKhoans", "MaVaiTro", c => c.String(maxLength: 128));
            AlterColumn("dbo.TaiKhoans", "Email", c => c.String());
            AlterColumn("dbo.TaiKhoans", "DienThoai", c => c.String());
            AlterColumn("dbo.TaiKhoans", "MatKhau", c => c.String());
            AlterColumn("dbo.TaiKhoans", "TenDangNhap", c => c.String());
            AlterColumn("dbo.TaiKhoans", "MaTaiKhoan", c => c.String());
            AlterColumn("dbo.SanPhams", "MaNhaCungCap", c => c.String(maxLength: 128));
            AlterColumn("dbo.SanPhams", "MoTa", c => c.String());
            AlterColumn("dbo.SanPhams", "TenSanPham", c => c.String());
            AlterColumn("dbo.SanPhams", "MaSanPham", c => c.String());
            CreateIndex("dbo.TaiKhoans", "MaVaiTro");
            CreateIndex("dbo.SanPhams", "MaNhaCungCap");
            AddForeignKey("dbo.TaiKhoans", "MaVaiTro", "dbo.VaiTroes", "MaVaiTro");
            AddForeignKey("dbo.SanPhams", "MaNhaCungCap", "dbo.NhaCungCaps", "MaNhaCungCap");
        }
    }
}
