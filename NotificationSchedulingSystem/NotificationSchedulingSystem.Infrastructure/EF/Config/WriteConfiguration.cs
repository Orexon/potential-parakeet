using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NotificationSchedulingSystem.Core.CompanyAggregate;
using System;

namespace NotificationSchedulingSystem.Infrastructure.EF.Config
{
    internal sealed class WriteConfiguration : IEntityTypeConfiguration<Company>, IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.CompanyId);

            builder.Property(c => c.CompanyId);
            builder.Property(c => c.Name).HasMaxLength(100);
            builder.Property(t => t.CompanyNumber)
                   .HasPrecision(10, 0);
            builder.Property(t => t.Market)
                   .HasConversion(new EnumToStringConverter<Market>())
                   .HasColumnName("Market");

            builder.Property(t => t.CompanyType)
                   .HasConversion(new EnumToStringConverter<CompanyType>())
                   .HasColumnName("CompanyType");

            builder.HasMany(typeof(Notification), "_notifications");
            builder.ToTable("Companies");
        }

        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.Property<Guid>("Id");
            builder.Property(x => x.SendDate)
                   .HasColumnType("date")
                   .HasDefaultValueSql("GetDate()");
            builder.ToTable("Notifications");
        }


    }
}
