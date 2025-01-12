namespace ProjectQuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterDisplayName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TaiKhoans", "HoVaTen", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TaiKhoans", "HoVaTen");
        }
    }
}
