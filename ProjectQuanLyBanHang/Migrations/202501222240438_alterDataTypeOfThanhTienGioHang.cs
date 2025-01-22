namespace ProjectQuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterDataTypeOfThanhTienGioHang : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GioHangChiTiets", "ThanhTien", c => c.Int(nullable: false));
            AlterColumn("dbo.GioHangs", "ThanhTien", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GioHangs", "ThanhTien", c => c.Single(nullable: false));
            AlterColumn("dbo.GioHangChiTiets", "ThanhTien", c => c.Single(nullable: false));
        }
    }
}
