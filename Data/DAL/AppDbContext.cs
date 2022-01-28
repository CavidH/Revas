using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DAL
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Portfolio> portfolios { get; set; }
        public DbSet<Setting> settings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Portfolio).Assembly);
            modelBuilder.Entity<Setting>().HasData(
                new Setting
                {
                    Id = 1,
                    Key = "herotitle",
                    Value = "READY TO LAUNCH"
                }, new Setting
                {
                    Id = 2,
                    Key = "heroheadtitle",
                    Value = "LOREM IPSUM DOLOR SIT AMET"
                },
                new Setting
                {
                    Id =3,
                    Key = "heroIcon",
                    Value = "fa fa-bomb fa-5x"
                }, new Setting
                {
                    Id = 4,
                    Key = "portfoliotitle",
                    Value = "OUR PORTFOLIO"

                },
                new Setting
                {
                    Id = 5,
                    Key = "abouttitle",
                    Value = "ABOUT COMPANY"

                });
            modelBuilder.Entity<Portfolio>().HasData(
                new Portfolio { Id = 1, Title = "test title", Image = "1.jpg" },
                new Portfolio { Id = 2, Title = "test title", Image = "1.jpg" },
                new Portfolio { Id = 3, Title = "test title", Image = "1.jpg" },
                new Portfolio { Id = 4, Title = "test title", Image = "1.jpg" },
                new Portfolio { Id = 5, Title = "test title", Image = "1.jpg" },
                new Portfolio { Id = 6, Title = "test title", Image = "1.jpg" });
            base.OnModelCreating(modelBuilder);
        }
    }
}
