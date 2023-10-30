using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class PurchaseMethodConfiguration : IEntityTypeConfiguration<PurchaseMethod>
    {
        public void Configure(EntityTypeBuilder<PurchaseMethod> builder)
        {
            builder.ToTable("PurchaseMethod");

            
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
            .HasColumnType("int(11)");

            builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50);

            builder.HasIndex(p => p.Name).IsUnique();
        }
    }
}