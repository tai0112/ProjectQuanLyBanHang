namespace ProjectQuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnhSanPhams",
                c => new
                    {
                        AnhSanPhamId = c.Int(nullable: false, identity: true),
                        TenAnh = c.String(nullable: false),
                        SanPhamId = c.Int(nullable: false),
                        UrlAnh = c.String(nullable: false),
                        NgayCapNhat = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AnhSanPhamId)
                .ForeignKey("dbo.SanPhams", t => t.SanPhamId, cascadeDelete: true)
                .Index(t => t.SanPhamId);
            
            CreateTable(
                "dbo.SanPhams",
                c => new
                    {
                        SanPhamId = c.Int(nullable: false, identity: true),
                        MaSanPham = c.String(),
                        TenSanPham = c.String(),
                        MoTa = c.String(),
                        TrangThai = c.Boolean(nullable: false),
                        MaNhaCungCap = c.String(maxLength: 128),
                        NgayTao = c.DateTime(nullable: false),
                        NgayCapNhat = c.DateTime(nullable: false),
                        NgayDuyet = c.DateTime(nullable: false),
                        LoaiSanPham_MaLoaiSanPham = c.Int(),
                    })
                .PrimaryKey(t => t.SanPhamId)
                .ForeignKey("dbo.LoaiSanPhams", t => t.LoaiSanPham_MaLoaiSanPham)
                .ForeignKey("dbo.NhaCungCaps", t => t.MaNhaCungCap)
                .Index(t => t.MaNhaCungCap)
                .Index(t => t.LoaiSanPham_MaLoaiSanPham);
            
            CreateTable(
                "dbo.GioHangChiTiets",
                c => new
                    {
                        GioHangId = c.Int(nullable: false),
                        SanPhamId = c.Int(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        ThanhTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.GioHangId, t.SanPhamId })
                .ForeignKey("dbo.GioHangs", t => t.GioHangId, cascadeDelete: true)
                .ForeignKey("dbo.SanPhams", t => t.SanPhamId, cascadeDelete: true)
                .Index(t => t.GioHangId)
                .Index(t => t.SanPhamId);
            
            CreateTable(
                "dbo.GioHangs",
                c => new
                    {
                        GioHangId = c.Int(nullable: false, identity: true),
                        TaiKhoanId = c.Int(nullable: false),
                        ThanhTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GioHang_GioHangId = c.Int(),
                    })
                .PrimaryKey(t => t.GioHangId)
                .ForeignKey("dbo.GioHangs", t => t.GioHang_GioHangId)
                .ForeignKey("dbo.TaiKhoans", t => t.TaiKhoanId, cascadeDelete: true)
                .Index(t => t.TaiKhoanId)
                .Index(t => t.GioHang_GioHangId);
            
            CreateTable(
                "dbo.TaiKhoans",
                c => new
                    {
                        TaiKhoanId = c.Int(nullable: false, identity: true),
                        MaTaiKhoan = c.String(),
                        TenDangNhap = c.String(),
                        MatKhau = c.String(),
                        DienThoai = c.String(),
                        Email = c.String(),
                        MaVaiTro = c.String(maxLength: 128),
                        GioiTinh = c.Boolean(nullable: false),
                        NgayTao = c.DateTime(nullable: false),
                        NgaySinh = c.DateTime(nullable: false),
                        AnhDaiDien = c.String(),
                    })
                .PrimaryKey(t => t.TaiKhoanId)
                .ForeignKey("dbo.VaiTroes", t => t.MaVaiTro)
                .Index(t => t.MaVaiTro);
            
            CreateTable(
                "dbo.HoaDons",
                c => new    
                    {
                        HoaDonId = c.Int(nullable: false, identity: true),
                        TaiKhoanId = c.Int(nullable: false),
                        MaHoaDon = c.String(nullable: false),
                        TenHoaDon = c.String(nullable: false),
                        ThanhTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TrangThai = c.Boolean(nullable: false),
                        NgayThanhToan = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.HoaDonId)
                .ForeignKey("dbo.TaiKhoans", t => t.TaiKhoanId, cascadeDelete: true)
                .Index(t => t.TaiKhoanId);
            
            CreateTable(
                "dbo.HoaDonChiTiets",
                c => new
                    {
                        HoaDonId = c.Int(nullable: false),
                        SanPhamId = c.Int(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        ThanhTien = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HoaDonId, t.SanPhamId })
                .ForeignKey("dbo.HoaDons", t => t.HoaDonId, cascadeDelete: true)
                .ForeignKey("dbo.SanPhams", t => t.SanPhamId, cascadeDelete: true)
                .Index(t => t.HoaDonId)
                .Index(t => t.SanPhamId);
            
            CreateTable(
                "dbo.VaiTroes",
                c => new
                    {
                        MaVaiTro = c.String(nullable: false, maxLength: 128),
                        TenVaiTro = c.String(),
                    })
                .PrimaryKey(t => t.MaVaiTro);
            
            CreateTable(
                "dbo.LoaiSanPhams",
                c => new
                    {
                        MaLoaiSanPham = c.Int(nullable: false, identity: true),
                        TenLoaiSanPham = c.String(),
                        AnhLoaiSanPham = c.String(),
                    })
                .PrimaryKey(t => t.MaLoaiSanPham);
            
            CreateTable(
                "dbo.NhaCungCaps",
                c => new
                    {
                        MaNhaCungCap = c.String(nullable: false, maxLength: 128),
                        TenNhaCungCap = c.String(),
                        AnhNhaCungCap = c.String(),
                    })
                .PrimaryKey(t => t.MaNhaCungCap);
            
            CreateTable(
                "dbo.SanPhamChiTiets",
                c => new
                    {
                        SanPhamChiTietId = c.Int(nullable: false, identity: true),
                        SanPhamId = c.Int(nullable: false),
                        CauHinhId = c.Int(nullable: false),
                        MauSac = c.String(),
                        SoLuongDaBan = c.Int(nullable: false),
                        GiaTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SanPhamChiTietId)
                .ForeignKey("dbo.CauHinhs", t => t.CauHinhId, cascadeDelete: true)
                .ForeignKey("dbo.SanPhams", t => t.SanPhamId, cascadeDelete: true)
                .Index(t => t.SanPhamId)
                .Index(t => t.CauHinhId);
            
            CreateTable(
                "dbo.CauHinhs",
                c => new
                    {
                        CauHinhId = c.Int(nullable: false, identity: true),
                        Ram = c.Int(nullable: false),
                        Cpu = c.String(nullable: false),
                        Gpu = c.String(nullable: false),
                        BoNho = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CauHinhId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanPhamChiTiets", "SanPhamId", "dbo.SanPhams");
            DropForeignKey("dbo.SanPhamChiTiets", "CauHinhId", "dbo.CauHinhs");
            DropForeignKey("dbo.SanPhams", "MaNhaCungCap", "dbo.NhaCungCaps");
            DropForeignKey("dbo.SanPhams", "LoaiSanPham_MaLoaiSanPham", "dbo.LoaiSanPhams");
            DropForeignKey("dbo.GioHangChiTiets", "SanPhamId", "dbo.SanPhams");
            DropForeignKey("dbo.GioHangChiTiets", "GioHangId", "dbo.GioHangs");
            DropForeignKey("dbo.GioHangs", "TaiKhoanId", "dbo.TaiKhoans");
            DropForeignKey("dbo.TaiKhoans", "MaVaiTro", "dbo.VaiTroes");
            DropForeignKey("dbo.HoaDons", "TaiKhoanId", "dbo.TaiKhoans");
            DropForeignKey("dbo.HoaDonChiTiets", "SanPhamId", "dbo.SanPhams");
            DropForeignKey("dbo.HoaDonChiTiets", "HoaDonId", "dbo.HoaDons");
            DropForeignKey("dbo.GioHangs", "GioHang_GioHangId", "dbo.GioHangs");
            DropForeignKey("dbo.AnhSanPhams", "SanPhamId", "dbo.SanPhams");
            DropIndex("dbo.SanPhamChiTiets", new[] { "CauHinhId" });
            DropIndex("dbo.SanPhamChiTiets", new[] { "SanPhamId" });
            DropIndex("dbo.HoaDonChiTiets", new[] { "SanPhamId" });
            DropIndex("dbo.HoaDonChiTiets", new[] { "HoaDonId" });
            DropIndex("dbo.HoaDons", new[] { "TaiKhoanId" });
            DropIndex("dbo.TaiKhoans", new[] { "MaVaiTro" });
            DropIndex("dbo.GioHangs", new[] { "GioHang_GioHangId" });
            DropIndex("dbo.GioHangs", new[] { "TaiKhoanId" });
            DropIndex("dbo.GioHangChiTiets", new[] { "SanPhamId" });
            DropIndex("dbo.GioHangChiTiets", new[] { "GioHangId" });
            DropIndex("dbo.SanPhams", new[] { "LoaiSanPham_MaLoaiSanPham" });
            DropIndex("dbo.SanPhams", new[] { "MaNhaCungCap" });
            DropIndex("dbo.AnhSanPhams", new[] { "SanPhamId" });
            DropTable("dbo.CauHinhs");
            DropTable("dbo.SanPhamChiTiets");
            DropTable("dbo.NhaCungCaps");
            DropTable("dbo.LoaiSanPhams");
            DropTable("dbo.VaiTroes");
            DropTable("dbo.HoaDonChiTiets");
            DropTable("dbo.HoaDons");
            DropTable("dbo.TaiKhoans");
            DropTable("dbo.GioHangs");
            DropTable("dbo.GioHangChiTiets");
            DropTable("dbo.SanPhams");
            DropTable("dbo.AnhSanPhams");
        }
    }
}
