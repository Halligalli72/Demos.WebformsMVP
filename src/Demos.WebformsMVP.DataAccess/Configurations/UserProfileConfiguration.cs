using Demos.WebformsMVP.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Demos.WebformsMVP.DataAccess.Configurations
{
    internal class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable("UserProfile");
            builder.HasKey(p => p.UserProfileId);
            builder.Property(p => p.UserProfileId).ValueGeneratedOnAdd();
            builder.Property(p => p.UserName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Team).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Department).IsRequired().HasMaxLength(50);
            builder.Property(p => p.IsAdmin).IsRequired();
            builder.Property(p => p.IsPublic).IsRequired();
            builder.Property(p => p.Created).IsRequired();
            builder.Property(p => p.Updated).IsRequired();
            //Relationships
            builder.HasMany(p => p.Activity)
                .WithOne(s => s.UserProfile)
                .HasForeignKey(p => p.UserProfileId);
        }
    }
}
