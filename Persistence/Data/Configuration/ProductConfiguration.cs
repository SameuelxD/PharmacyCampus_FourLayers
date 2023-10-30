using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
        
        /*builder.HasKey(p => p.Codigo);
        builder.Property(p => p.Codigo)
        .IsRequired()
        .HasMaxLength(10);*/

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
        .HasColumnType("int(11)");

        builder.Property(p => p.Name)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasIndex(p => p.Name)
        .IsUnique();

        builder.HasOne(p => p.ProductBrands)
        .WithMany(p => p.Products)
        .HasForeignKey(p => p.ProductBrandId);
        }
    }
}