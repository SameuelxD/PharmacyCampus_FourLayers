using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
            .HasColumnType("int(11)");

            builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50);

            builder.HasOne(p => p.Departments)
            .WithMany(p =>p.Cities)
            .HasForeignKey(p => p.DepartmentId);
        }
    }
}