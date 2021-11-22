using Demos.WebformsMVP.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Demos.WebformsMVP.DataAccess.Configurations
{
    internal class ActivityTypeConfiguration : IEntityTypeConfiguration<ActivityType>
    {
        public void Configure(EntityTypeBuilder<ActivityType> builder)
        {
            builder.ToTable("ActivityType");
            builder.HasKey(p => p.ActivityTypeId);
            builder.Property(p => p.ActivityTypeId).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.StepValue).IsRequired();
            builder.Property(p => p.IsActivated).IsRequired();
            builder.Property(p => p.Created).IsRequired();
            builder.Property(p => p.Updated).IsRequired();
            //Relationships
            builder.HasMany(p => p.Activity)
                .WithOne(s => s.ActivityType)
                .HasForeignKey(p => p.ActivityTypeId);
        }
    }
}
