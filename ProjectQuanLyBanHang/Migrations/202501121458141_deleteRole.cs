namespace ProjectQuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteRole : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TaiKhoans", "MaVaiTro", "dbo.VaiTroes");
            DropIndex("dbo.TaiKhoans", new[] { "MaVaiTro" });
            DropColumn("dbo.TaiKhoans", "MaVaiTro");
            DropTable("dbo.VaiTroes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VaiTroes",
                c => new
                    {
                        MaVaiTro = c.String(nullable: false, maxLength: 128),
                        TenVaiTro = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaVaiTro);
            
            AddColumn("dbo.TaiKhoans", "MaVaiTro", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.TaiKhoans", "MaVaiTro");
            AddForeignKey("dbo.TaiKhoans", "MaVaiTro", "dbo.VaiTroes", "MaVaiTro", cascadeDelete: true);
        }
    }
}
