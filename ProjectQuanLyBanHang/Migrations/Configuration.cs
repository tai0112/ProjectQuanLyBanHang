namespace ProjectQuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjectQuanLyBanHang.Models.QuanLyBanHangDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProjectQuanLyBanHang.Models.QuanLyBanHangDbContext context)
        {
            
        }
    }
}
