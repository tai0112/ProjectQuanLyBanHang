namespace ProjectQuanLyBanHang.IdentityMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addHoVaTen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "HoVaTen", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "HoVaTen");
        }
    }
}
