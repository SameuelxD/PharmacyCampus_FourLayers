using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class AddressPersonConfiguration : IEntityTypeConfiguration<AddressPerson>
    {
        public void Configure(EntityTypeBuilder<AddressPerson> builder)
        {
        
        builder.ToTable("AddressPerson");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
        .HasColumnType("int(11)");

        builder.Property(e => e.RoadType)
        .HasMaxLength(50);

        builder.Property(p => p.FirstNumber)
        .HasColumnType("int");

        builder.Property(e => e.FirstLetter)
        .HasMaxLength(2);

        builder.Property(e => e.Bis)
        .HasMaxLength(10);

        builder.Property(e => e.SecondLetter)
        .HasMaxLength(2);

        builder.Property(e => e.FirstCardinal)
        .HasMaxLength(10);

        builder.Property(p => p.SecondNumber)
        .HasColumnType("int");

        builder.Property(e => e.ThirdLetter)
        .HasMaxLength(2);

        builder.Property(p => p.ThirdNumber)
        .HasColumnType("int");

        builder.Property(e => e.SecondCardinal)
        .HasMaxLength(10);

        builder.Property(e => e.Complement)
        .HasMaxLength(50);

        builder.HasOne(p => p.People)
        .WithMany(p => p.AddressPeople)
        .HasForeignKey(p => p.PersonCode);

        builder.HasOne(p => p.Cities)
        .WithMany(p => p.AddressesPeople)
        .HasForeignKey(p => p.CityId);
        }
    }
}