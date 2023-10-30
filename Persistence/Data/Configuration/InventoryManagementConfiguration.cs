using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class InventoryManagementConfiguration : IEntityTypeConfiguration<InventoryManagement>
    {
        public void Configure(EntityTypeBuilder<InventoryManagement> builder)
        {
            builder.ToTable("InventoryManagement");

            /*builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
            .IsRequired()
            .HasMaxLength(10);*/

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
            .HasColumnType("int(11)");


            builder.Property(p => p.MovimentDate)
            .IsRequired()
            .HasColumnType("DateTime");

            builder.Property(p => p.ExpirationDate)
            .IsRequired()
            .HasColumnType("DateTime");

            builder.HasOne(p => p.People)
            .WithMany(p => p.InventoriesManagement)
            .HasForeignKey(p => p.SellerCode);

            builder.HasOne(p => p.People)
            .WithMany(p => p.InventoriesManagement)
            .HasForeignKey(p => p.ReceiverCode);

            builder.HasOne(p => p.MovementsTypes)
            .WithMany(p => p.InventoriesManagement)
            .HasForeignKey(p => p.TypeMovimentId);

            builder.HasOne(p => p.PurchaseMethods)
            .WithMany(p => p.InventoriesManagement)
            .HasForeignKey(p => p.PurchaseMethodId);
        }
    }
}