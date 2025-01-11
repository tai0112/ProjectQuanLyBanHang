namespace ProjectQuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNullAble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GioHangChiTiets", "SoLuong", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GioHangChiTiets", "SoLuong", c => c.Int(nullable: false));
        }
    }
}
