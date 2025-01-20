namespace ProjectQuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSoLuongToSanPhamChiTiet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SanPhamChiTiets", "SoLuong", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SanPhamChiTiets", "SoLuong");
        }
    }
}
