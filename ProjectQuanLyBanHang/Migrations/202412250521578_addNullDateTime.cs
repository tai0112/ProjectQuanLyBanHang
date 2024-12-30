namespace ProjectQuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNullDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SanPhams", "NgayDuyet", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SanPhams", "NgayDuyet", c => c.DateTime(nullable: false));
        }
    }
}
