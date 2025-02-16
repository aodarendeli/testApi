using FreeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FreeApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>()
                .Property(c => c.CreateOn)
                .HasConversion(
                    v => v.ToUniversalTime(), 
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
        }
    }
}