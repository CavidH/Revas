using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Portfolio> portfolios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Portfolio).Assembly);
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
