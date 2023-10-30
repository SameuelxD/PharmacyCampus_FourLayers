using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("Inventory");

            /*builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
            .IsRequired()
            .HasMaxLength(10);*/

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
            .HasColumnType("int(11)");

            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.Price)
            .IsRequired()
            .HasColumnType("double(11,2)")
            .HasPrecision(11,2);

            builder.Property(p => p.Stock)
            .HasColumnType("int")
            .IsRequired();

            builder.Property(p => p.MinStock)
            .HasColumnType("int")
            .IsRequired();

            builder.Property(p => p.MaxStock)
            .HasColumnType("int")
            .IsRequired();

            builder.HasOne(p => p.Products)
            .WithMany(p => p.Inventories)
            .HasForeignKey(p => p.ProductCode);

            builder.HasOne(p => p.PresentationsTypes)
            .WithMany(p => p.Inventories)
            .HasForeignKey(p => p.PresentationTypeId);
        }
    }
}