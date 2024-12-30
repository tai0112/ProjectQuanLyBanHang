namespace ProjectQuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropCauHinhIdFromSanPhamChiTiet : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SanPhamChiTiets", "CauHinhId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SanPhamChiTiets", "CauHinhId", c => c.Int(nullable: false));
        }
    }
}
