using AgendaApi.Models.Schedule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaApi.Data.Mappings.Schedule;

public class ScheduledMap : IEntityTypeConfiguration<Scheduled> {
	public void Configure(EntityTypeBuilder<Scheduled> builder) {
		builder.ToTable("Scheduled");

		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id)
			.HasColumnName("Id")
			.HasColumnType("uniqueidentifier")
			.IsRequired();

		builder.Property(x => x.IdCustomer)
			.HasColumnName("Customer")
			.HasColumnType("uniqueidentifier")
			.IsRequired();
		builder.HasOne(x => x.FromCustomer)
			.WithMany()
			.HasForeignKey(x => x.IdCustomer)
			.HasConstraintName("FK_Scheduled_Customer")
			.OnDelete(DeleteBehavior.Cascade);

		builder.Property(x => x.IdSecretary)
			.HasColumnName("Secretary")
			.HasColumnType("uniqueidentifier")
			.IsRequired();
		builder.HasOne(x => x.FromSecretary)
			.WithMany()
			.HasForeignKey(x => x.IdSecretary)
			.HasConstraintName("FK_Scheduled_Secretary")
			.OnDelete(DeleteBehavior.NoAction);

		builder.Property(x => x.IdPurpose)
			.HasColumnName("Purpose")
			.HasColumnType("uniqueidentifier")
			.IsRequired();
		builder.HasOne(x => x.FromPurpose)
			.WithMany()
			.HasForeignKey(x => x.IdPurpose)
			.HasConstraintName("FK_Scheduled_Purpose")
			.OnDelete(DeleteBehavior.NoAction);

		builder.Property(x => x.Status)
			.HasColumnName("Status")
			.HasColumnType("bit")
			.HasDefaultValue(1)
			.IsRequired();

		builder.Property(x => x.CreatedAt)
			.HasColumnName("CreatedAt")
			.HasColumnType("datetime")
			.IsRequired();

		builder.Property(x => x.UpdatedAt)
			.HasColumnName("UpdatedAt")
			.HasColumnType("datetime");
	}
}