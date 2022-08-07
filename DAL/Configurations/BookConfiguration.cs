using System;
using HomeTaskBookCategory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeTaskBookCategory.DAL.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired();
            builder.Property(b => b.Author).HasMaxLength(60).IsRequired();
            builder.Property(b => b.Price).HasMaxLength(2000).IsRequired();
        }
    }
}

