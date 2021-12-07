using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NotificationSchedulingSystem.Core.CompanyAggregate;
using NotificationSchedulingSystem.Infrastructure.EF.Models;
using System;

namespace NotificationSchedulingSystem.Infrastructure.EF.Config
{
    internal sealed class ReadConfiguration : IEntityTypeConfiguration<CompanyReadModel>, IEntityTypeConfiguration<NotificationReadModel>
    {
        public void Configure(EntityTypeBuilder<CompanyReadModel> builder)
        {
            builder.ToTable("Companies");
            builder.HasKey(c => c.CompanyId);

            builder.Property(t => t.Market)
                .HasConversion(new EnumToStringConverter<Market>())
                .HasColumnName("Market");

            builder.Property(t => t.CompanyType)
                   .HasConversion(new EnumToStringConverter<CompanyType>())
                   .HasColumnName("CompanyType");

            builder.HasMany(c => c.Notifications)
                   .WithOne(n => n.Company);
        }

        public void Configure(EntityTypeBuilder<NotificationReadModel> builder)
        {
            builder.ToTable("Notifications");
            builder.Property(x => x.SendDate)
                   .HasColumnType("date")
                   .HasDefaultValueSql("GetDate()");
        }

    }
}
