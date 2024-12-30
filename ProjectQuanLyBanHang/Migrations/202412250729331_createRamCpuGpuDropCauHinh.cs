namespace ProjectQuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createRamCpuGpuDropCauHinh : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SanPhamChiTiets", "CauHinhId", "dbo.CauHinhs");
            DropIndex("dbo.SanPhamChiTiets", new[] { "CauHinhId" });
            CreateTable(
                "dbo.CPUs",
                c => new
                    {
                        CpuId = c.Int(nullable: false, identity: true),
                        TenCpu = c.String(),
                        NhaSX = c.String(),
                        MoTa = c.String(),
                    })
                .PrimaryKey(t => t.CpuId);
            
            CreateTable(
                "dbo.GPUs",
                c => new
                    {
                        GpuId = c.Int(nullable: false, identity: true),
                        TenGpu = c.String(),
                        HangSX = c.String(),
                    })
                .PrimaryKey(t => t.GpuId);
            
            CreateTable(
                "dbo.Rams",
                c => new
                    {
                        RamId = c.Int(nullable: false, identity: true),
                        LoaiRam = c.String(),
                        MoTa = c.String(),
                        DungLuongRam = c.Int(nullable: false),
                        NhaSX = c.String(),
                    })
                .PrimaryKey(t => t.RamId);
            
            AddColumn("dbo.SanPhamChiTiets", "RamId", c => c.Int(nullable: false));
            AddColumn("dbo.SanPhamChiTiets", "CpuId", c => c.Int(nullable: false));
            AddColumn("dbo.SanPhamChiTiets", "GpuId", c => c.Int(nullable: false));
            CreateIndex("dbo.SanPhamChiTiets", "RamId");
            CreateIndex("dbo.SanPhamChiTiets", "CpuId");
            CreateIndex("dbo.SanPhamChiTiets", "GpuId");
            AddForeignKey("dbo.SanPhamChiTiets", "CpuId", "dbo.CPUs", "CpuId", cascadeDelete: true);
            AddForeignKey("dbo.SanPhamChiTiets", "GpuId", "dbo.GPUs", "GpuId", cascadeDelete: true);
            AddForeignKey("dbo.SanPhamChiTiets", "RamId", "dbo.Rams", "RamId", cascadeDelete: true);
            DropTable("dbo.CauHinhs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CauHinhs",
                c => new
                    {
                        CauHinhId = c.Int(nullable: false, identity: true),
                        Ram = c.Int(nullable: false),
                        Cpu = c.String(nullable: false),
                        Gpu = c.String(nullable: false),
                        BoNho = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CauHinhId);
            
            DropForeignKey("dbo.SanPhamChiTiets", "RamId", "dbo.Rams");
            DropForeignKey("dbo.SanPhamChiTiets", "GpuId", "dbo.GPUs");
            DropForeignKey("dbo.SanPhamChiTiets", "CpuId", "dbo.CPUs");
            DropIndex("dbo.SanPhamChiTiets", new[] { "GpuId" });
            DropIndex("dbo.SanPhamChiTiets", new[] { "CpuId" });
            DropIndex("dbo.SanPhamChiTiets", new[] { "RamId" });
            DropColumn("dbo.SanPhamChiTiets", "GpuId");
            DropColumn("dbo.SanPhamChiTiets", "CpuId");
            DropColumn("dbo.SanPhamChiTiets", "RamId");
            DropTable("dbo.Rams");
            DropTable("dbo.GPUs");
            DropTable("dbo.CPUs");
            CreateIndex("dbo.SanPhamChiTiets", "CauHinhId");
            AddForeignKey("dbo.SanPhamChiTiets", "CauHinhId", "dbo.CauHinhs", "CauHinhId", cascadeDelete: true);
        }
    }
}
