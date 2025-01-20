namespace ProjectQuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropRequireMoTa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SanPhams", "MoTa", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SanPhams", "MoTa", c => c.String(nullable: false));
        }
    }
}
