namespace ProjectQuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMaLoaiSanPhamToSanPham : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SanPhams", "LoaiSanPham_MaLoaiSanPham", "dbo.LoaiSanPhams");
            DropIndex("dbo.SanPhams", new[] { "LoaiSanPham_MaLoaiSanPham" });
            RenameColumn(table: "dbo.SanPhams", name: "LoaiSanPham_MaLoaiSanPham", newName: "MaLoaiSanPham");
            AlterColumn("dbo.SanPhams", "MaLoaiSanPham", c => c.Int(nullable: false));
            CreateIndex("dbo.SanPhams", "MaLoaiSanPham");
            AddForeignKey("dbo.SanPhams", "MaLoaiSanPham", "dbo.LoaiSanPhams", "MaLoaiSanPham", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanPhams", "MaLoaiSanPham", "dbo.LoaiSanPhams");
            DropIndex("dbo.SanPhams", new[] { "MaLoaiSanPham" });
            AlterColumn("dbo.SanPhams", "MaLoaiSanPham", c => c.Int());
            RenameColumn(table: "dbo.SanPhams", name: "MaLoaiSanPham", newName: "LoaiSanPham_MaLoaiSanPham");
            CreateIndex("dbo.SanPhams", "LoaiSanPham_MaLoaiSanPham");
            AddForeignKey("dbo.SanPhams", "LoaiSanPham_MaLoaiSanPham", "dbo.LoaiSanPhams", "MaLoaiSanPham");
        }
    }
}
