using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");

            /*builder.HasKey(e => e.Codigo);
            builder.Property(e => e.Codigo)
            .IsRequired()
            .HasMaxLength(20);*/

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
            .HasColumnType("int(11)");

            builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.RegistrationDate)
            .IsRequired()
            .HasColumnType("DateTime");

            builder.HasOne(p => p.DocumentsType)
            .WithMany(p => p.People)
            .HasForeignKey(p => p.TypePersonId);

            builder.HasOne(p => p.PeopleRole)
            .WithMany(p => p.People)
            .HasForeignKey(p => p.PersonRoleId);

            builder.HasOne(p =>  p.PeopleType)
            .WithMany(p => p.People)
            .HasForeignKey(p => p.TypePersonId);
        }
    }
}