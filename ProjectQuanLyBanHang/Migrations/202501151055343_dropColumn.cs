namespace ProjectQuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropColumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GioHangChiTiets", "SanPham_SanPhamId", "dbo.SanPhams");
            DropIndex("dbo.GioHangChiTiets", new[] { "SanPham_SanPhamId" });
            DropColumn("dbo.GioHangChiTiets", "SanPham_SanPhamId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GioHangChiTiets", "SanPham_SanPhamId", c => c.Int());
            CreateIndex("dbo.GioHangChiTiets", "SanPham_SanPhamId");
            AddForeignKey("dbo.GioHangChiTiets", "SanPham_SanPhamId", "dbo.SanPhams", "SanPhamId");
        }
    }
}
