namespace ProjectQuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LoaiSanPhams", "AnhLoaiSanPham", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LoaiSanPhams", "AnhLoaiSanPham", c => c.String(nullable: false));
        }
    }
}
