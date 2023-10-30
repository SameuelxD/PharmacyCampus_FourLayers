using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ContactPersonConfiguration : IEntityTypeConfiguration<ContactPerson>
    {
        public void Configure(EntityTypeBuilder<ContactPerson> builder)
        {
            builder.ToTable("ContactPerson");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
            .HasColumnType("int(11)");

            builder.HasOne(p => p.People)
            .WithMany(p => p.ContactPeople)
            .HasForeignKey(p => p.PersonCode);

            builder.HasOne(p => p.TypeContacts)
            .WithMany(p => p.ContactPeople)
            .HasForeignKey(p => p.TypeContactId);   
        }
    }
}