namespace ProjectQuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class altetForeignKeyGioHang : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GioHangs", "GioHang_GioHangId", "dbo.GioHangs");
            DropIndex("dbo.GioHangs", new[] { "GioHang_GioHangId" });
            DropColumn("dbo.GioHangs", "GioHang_GioHangId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GioHangs", "GioHang_GioHangId", c => c.Int());
            CreateIndex("dbo.GioHangs", "GioHang_GioHangId");
            AddForeignKey("dbo.GioHangs", "GioHang_GioHangId", "dbo.GioHangs", "GioHangId");
        }
    }
}
