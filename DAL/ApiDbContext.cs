using System;
using HomeTaskBookCategory.DAL.Configurations;
using HomeTaskBookCategory.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeTaskBookCategory.DAL
{
    public class ApiDbContext:DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext>options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }

    }
}

