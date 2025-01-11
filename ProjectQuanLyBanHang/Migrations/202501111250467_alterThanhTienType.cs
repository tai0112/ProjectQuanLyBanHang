namespace ProjectQuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterThanhTienType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GioHangChiTiets", "ThanhTien", c => c.Single(nullable: false));
            AlterColumn("dbo.GioHangs", "ThanhTien", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GioHangs", "ThanhTien", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.GioHangChiTiets", "ThanhTien", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
