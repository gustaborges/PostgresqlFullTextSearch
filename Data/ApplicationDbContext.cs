using System;
using Microsoft.EntityFrameworkCore;
using PostgreFullTextSearch.Data.Mapping;
using PostgreFullTextSearch.Models;

namespace PostgreFullTextSearch.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Document> Documents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=test_application;Username=gustavo;Password=123456")
                    .UseSnakeCaseNamingConvention();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Document>(new DocumentMap());
        }
    }
}