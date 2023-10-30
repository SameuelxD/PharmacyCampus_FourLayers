using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("Bill");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
            .HasColumnType("int(11)");

            builder.Property(p => p.InitialInvoice)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.FinalBill)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.CurrentInvoice)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(p => p.ResolutionNumber)
            .IsRequired()
            .HasMaxLength(10);
            
            // Indica que el indice de NumeroResolucion va a ser unico
            builder.HasIndex(p => p.ResolutionNumber).IsUnique();
        }
    }
}