using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);

            builder.Property(x => x.Username).IsRequired().HasMaxLength(50);

            builder.Property(x => x.Password).IsRequired().HasMaxLength(225);

            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);

            builder.HasMany(e => e.Rols).WithMany(c => c.Users).UsingEntity<UserRol>(
                y => y.HasOne(e => e.Rols).WithMany(e => e.UsersRols).HasForeignKey(c => c.RolId),
                y => y.HasOne(e => e.Users).WithMany(e => e.UsersRols).HasForeignKey(c => c.UserId),
                y =>
                {
                    y.ToTable("userrol");
                    y.HasKey(z => new { z.UserId, z.RolId });
                }
            );

            builder.HasMany(x => x.RefreshTokens).WithOne(x => x.Users).HasForeignKey(x => x.UserId);
        }
    }
}