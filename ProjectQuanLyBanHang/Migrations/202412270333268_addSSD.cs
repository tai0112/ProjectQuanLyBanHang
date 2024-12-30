namespace ProjectQuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSSD : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SanPhamChiTiets", "SSD", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SanPhamChiTiets", "SSD");
        }
    }
}
