using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class MovementDetailConfiguration : IEntityTypeConfiguration<MovementDetail>
    {
        public void Configure(EntityTypeBuilder<MovementDetail> builder)
        {
            builder.ToTable("MovementDetail");

            //Clave Compuesta
            //builder.HasKey(e => new {e.IdInventario, e.IdInventarioGestion});
            
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
            .HasColumnType("int(11)");

            builder.Property(p => p.QualityUnits)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.Price)
            .IsRequired()
            .HasColumnType("double(11,2)")
            .HasPrecision(11,2);

            builder.HasOne(p => p.Inventories)
            .WithMany(p => p.MovementsDetails)
            .HasForeignKey(p => p.InventoryId);

            builder.HasOne(p => p.InventoriesManagement)
            .WithMany(p => p.MovementsDetails)
            .HasForeignKey(p => p.InventoryManagementId);
        }
    }
}