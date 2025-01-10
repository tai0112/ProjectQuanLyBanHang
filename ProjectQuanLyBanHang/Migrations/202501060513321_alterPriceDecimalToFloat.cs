namespace ProjectQuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterPriceDecimalToFloat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SanPhamChiTiets", "GiaTien", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SanPhamChiTiets", "GiaTien", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
