using Demos.WebformsMVP.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Demos.WebformsMVP.DataAccess.Configurations
{
    internal class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.ToTable("Activity");
            builder.HasKey(p => new { p.UserProfileId, p.ActivityTypeId, p.ActivityDate }); //composite key
            builder.Property(p => p.UserProfileId).IsRequired();
            builder.Property(p => p.ActivityTypeId).IsRequired();
            builder.Property(p => p.OtherActivity).IsRequired().HasMaxLength(50);
            builder.Property(p => p.ActivityDate).IsRequired();
            builder.Property(p => p.Duration).IsRequired();
            builder.Property(p => p.Score).IsRequired();
            builder.Property(p => p.Created).IsRequired();
            builder.Property(p => p.Updated).IsRequired();
            //Relationships
            builder.HasOne(p => p.ActivityType);
            builder.HasOne(p => p.UserProfile);
        }
    }
}
