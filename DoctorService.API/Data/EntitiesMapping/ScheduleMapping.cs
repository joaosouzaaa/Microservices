using DoctorService.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorService.API.Data.EntitiesMapping;
public sealed class ScheduleMapping : IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> builder)
    {
        builder.ToTable("Schedules");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Time)
            .IsRequired(true)
            .HasColumnName("time")
            .HasColumnType("timestamp without time zone");
    }
}
