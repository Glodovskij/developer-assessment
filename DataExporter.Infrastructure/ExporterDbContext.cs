using DataExporter.Domain.Entities;
using DataExporter.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DataExporter.Infrastructure
{
    public class ExporterDbContext : DbContext
    {
        public ExporterDbContext(DbContextOptions<ExporterDbContext> options) : base(options)
        {
        }

        public DbSet<Policy> Policies { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PolicyConfiguration());

            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Policy>().HasData(new Policy() { Id = 1, PolicyNumber = "HSCX1001", Premium = 200, StartDate = new DateTime(2024, 4, 1) },
                new Policy() { Id = 2, PolicyNumber = "HSCX1002", Premium = 153, StartDate = new DateTime(2024, 4, 5) },
                new Policy() { Id = 3, PolicyNumber = "HSCX1003", Premium = 220, StartDate = new DateTime(2024, 3, 10) },
                new Policy() { Id = 4, PolicyNumber = "HSCX1004", Premium = 200, StartDate = new DateTime(2024, 5, 1) },
                new Policy() { Id = 5, PolicyNumber = "HSCX1005", Premium = 100, StartDate = new DateTime(2024, 4, 1) });

            modelBuilder.Entity<Note>().HasData(new Note() { Id = 1, Text = "21C1CCA8-DFB1-4052-BEC4-EBC3EF7808CD", PolicyId = 1 },
                new Note() { Id = 2, Text = "21C1CCA8-DFB1-4052-BEC4-EBC3EF7808CD", PolicyId = 1 },
                new Note() { Id = 3, Text = "ABE3FD13-C6C0-44C3-898D-DCC3B2AFEB67", PolicyId = 1 },
                new Note() { Id = 4, Text = "EECD4D64-00E4-428F-A05F-90D174397D3D", PolicyId = 2 },
                new Note() { Id = 5, Text = "63081DBE-F370-4FBB-88DB-A9954CAF6B2D", PolicyId = 3 },
                new Note() { Id = 6, Text = "730F5981-99FC-484D-87C9-F41E5C2942BB", PolicyId = 4 },
                new Note() { Id = 7, Text = "95A839BC-A10C-4575-999E-F7B77E8BA68C", PolicyId = 4 },
                new Note() { Id = 8, Text = "B0DC4E45-2F02-4B01-BF67-831DAE6CED8E", PolicyId = 5 });
        }
    }
}
