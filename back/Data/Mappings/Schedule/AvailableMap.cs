using AgendaApi.Models.Schedule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaApi.Data.Mappings.Schedule;

public class AvailableMap : IEntityTypeConfiguration<Available> {
	public void Configure(EntityTypeBuilder<Available> builder) {
		builder.ToTable("Available");

		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id)
			.HasColumnName("Id")
			.HasColumnType("uniqueidentifier")
			.IsRequired();

		builder.Property(x => x.IdScheduled)
			.HasColumnName("Scheduled")
			.HasColumnType("uniqueidentifier");
		builder.HasOne(x=>x.FromScheduled)
			.WithMany()
			.HasForeignKey(x=>x.IdScheduled)
			.HasConstraintName("FK_Available_Scheduled")
			.OnDelete(DeleteBehavior.ClientSetNull);

		builder.Property(x=> x.IdEmployee)
			.HasColumnName("Employee")
			.HasColumnType("uniqueidentifier")
			.IsRequired();
		builder.HasOne(x=> x.FromEmployee)
			.WithMany()
			.HasForeignKey(x=>x.IdEmployee)
			.HasConstraintName("FK_Available_Employee")
			.OnDelete(DeleteBehavior.NoAction);

		builder.Property(x=> x.InitialTime)
			.HasColumnName("InitialTime")
			.HasColumnType("datetime")
			.IsRequired();
		builder.HasIndex(x=>x.InitialTime)
			.IsUnique();

		builder.Property(x=> x.FinalTime)
			.HasColumnName("FinalTime")
			.HasColumnType("datetime")
			.IsRequired();
		builder.HasIndex(x=>x.FinalTime)
			.IsUnique();

		builder.Property(x=> x.Status)
			.HasColumnName("Status")
			.HasColumnType("bit")
			.HasDefaultValue(1)
			.IsRequired();

		builder.Property(x=> x.CreatedAt)
			.HasColumnName("CreatedAt")
			.HasColumnType("datetime")
			.IsRequired();

		builder.Property(x => x.UpdatedAt)
			.HasColumnName("UpdatedAt")
			.HasColumnType("datetime");
	}
}