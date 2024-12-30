namespace ProjectQuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeRequrieImage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TaiKhoans", "AnhDaiDien", c => c.String());
            AlterColumn("dbo.NhaCungCaps", "AnhNhaCungCap", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NhaCungCaps", "AnhNhaCungCap", c => c.String(nullable: false));
            AlterColumn("dbo.TaiKhoans", "AnhDaiDien", c => c.String(nullable: false));
        }
    }
}
