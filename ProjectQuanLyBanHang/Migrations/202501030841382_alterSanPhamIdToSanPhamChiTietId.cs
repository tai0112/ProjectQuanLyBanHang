namespace ProjectQuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterSanPhamIdToSanPhamChiTietId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GioHangChiTiets", "SanPhamId", "dbo.SanPhams");
            DropForeignKey("dbo.HoaDonChiTiets", "SanPhamId", "dbo.SanPhams");
            DropIndex("dbo.GioHangChiTiets", new[] { "SanPhamId" });
            DropIndex("dbo.HoaDonChiTiets", new[] { "SanPhamId" });
            RenameColumn(table: "dbo.GioHangChiTiets", name: "SanPhamId", newName: "SanPham_SanPhamId");
            RenameColumn(table: "dbo.HoaDonChiTiets", name: "SanPhamId", newName: "SanPham_SanPhamId");
            DropPrimaryKey("dbo.GioHangChiTiets");
            DropPrimaryKey("dbo.HoaDonChiTiets");
            AddColumn("dbo.GioHangChiTiets", "SanPhamChiTietId", c => c.Int(nullable: false));
            AddColumn("dbo.HoaDonChiTiets", "SanPhamChiTietId", c => c.Int(nullable: false));
            AlterColumn("dbo.GioHangChiTiets", "SanPham_SanPhamId", c => c.Int());
            AlterColumn("dbo.HoaDonChiTiets", "SanPham_SanPhamId", c => c.Int());
            AddPrimaryKey("dbo.GioHangChiTiets", new[] { "GioHangId", "SanPhamChiTietId" });
            AddPrimaryKey("dbo.HoaDonChiTiets", new[] { "HoaDonId", "SanPhamChiTietId" });
            CreateIndex("dbo.GioHangChiTiets", "SanPhamChiTietId");
            CreateIndex("dbo.GioHangChiTiets", "SanPham_SanPhamId");
            CreateIndex("dbo.HoaDonChiTiets", "SanPhamChiTietId");
            CreateIndex("dbo.HoaDonChiTiets", "SanPham_SanPhamId");
            AddForeignKey("dbo.HoaDonChiTiets", "SanPhamChiTietId", "dbo.SanPhamChiTiets", "SanPhamChiTietId", cascadeDelete: true);
            AddForeignKey("dbo.GioHangChiTiets", "SanPhamChiTietId", "dbo.SanPhamChiTiets", "SanPhamChiTietId", cascadeDelete: true);
            AddForeignKey("dbo.GioHangChiTiets", "SanPham_SanPhamId", "dbo.SanPhams", "SanPhamId");
            AddForeignKey("dbo.HoaDonChiTiets", "SanPham_SanPhamId", "dbo.SanPhams", "SanPhamId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HoaDonChiTiets", "SanPham_SanPhamId", "dbo.SanPhams");
            DropForeignKey("dbo.GioHangChiTiets", "SanPham_SanPhamId", "dbo.SanPhams");
            DropForeignKey("dbo.GioHangChiTiets", "SanPhamChiTietId", "dbo.SanPhamChiTiets");
            DropForeignKey("dbo.HoaDonChiTiets", "SanPhamChiTietId", "dbo.SanPhamChiTiets");
            DropIndex("dbo.HoaDonChiTiets", new[] { "SanPham_SanPhamId" });
            DropIndex("dbo.HoaDonChiTiets", new[] { "SanPhamChiTietId" });
            DropIndex("dbo.GioHangChiTiets", new[] { "SanPham_SanPhamId" });
            DropIndex("dbo.GioHangChiTiets", new[] { "SanPhamChiTietId" });
            DropPrimaryKey("dbo.HoaDonChiTiets");
            DropPrimaryKey("dbo.GioHangChiTiets");
            AlterColumn("dbo.HoaDonChiTiets", "SanPham_SanPhamId", c => c.Int(nullable: false));
            AlterColumn("dbo.GioHangChiTiets", "SanPham_SanPhamId", c => c.Int(nullable: false));
            DropColumn("dbo.HoaDonChiTiets", "SanPhamChiTietId");
            DropColumn("dbo.GioHangChiTiets", "SanPhamChiTietId");
            AddPrimaryKey("dbo.HoaDonChiTiets", new[] { "HoaDonId", "SanPhamId" });
            AddPrimaryKey("dbo.GioHangChiTiets", new[] { "GioHangId", "SanPhamId" });
            RenameColumn(table: "dbo.HoaDonChiTiets", name: "SanPham_SanPhamId", newName: "SanPhamId");
            RenameColumn(table: "dbo.GioHangChiTiets", name: "SanPham_SanPhamId", newName: "SanPhamId");
            CreateIndex("dbo.HoaDonChiTiets", "SanPhamId");
            CreateIndex("dbo.GioHangChiTiets", "SanPhamId");
            AddForeignKey("dbo.HoaDonChiTiets", "SanPhamId", "dbo.SanPhams", "SanPhamId", cascadeDelete: true);
            AddForeignKey("dbo.GioHangChiTiets", "SanPhamId", "dbo.SanPhams", "SanPhamId", cascadeDelete: true);
        }
    }
}
