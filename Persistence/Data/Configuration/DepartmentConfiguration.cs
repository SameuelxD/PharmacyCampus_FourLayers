using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");
            
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
            .HasColumnType("int(11)");

            builder.Property( p => p.Name)
            .IsRequired()
            .HasMaxLength(50);

            builder.HasOne(p => p.Countries)
            .WithMany(p => p.Departments)
            .HasForeignKey(p => p.CountryId);
        }
    }
}