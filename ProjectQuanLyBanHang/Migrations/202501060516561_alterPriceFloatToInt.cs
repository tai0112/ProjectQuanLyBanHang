namespace ProjectQuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterPriceFloatToInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SanPhamChiTiets", "GiaTien", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SanPhamChiTiets", "GiaTien", c => c.Single(nullable: false));
        }
    }
}
