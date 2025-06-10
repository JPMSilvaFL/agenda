using AgendaApi.Models.Schedule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaApi.Data.Mappings.Schedule;

public class PurposeMap : IEntityTypeConfiguration<Purpose> {
	public void Configure(EntityTypeBuilder<Purpose> builder) {
		builder.ToTable("Purpose");

		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id)
			.HasColumnName("Id")
			.HasColumnType("uniqueidentifier")
			.IsRequired();

		builder.Property(x => x.IdRole)
			.HasColumnName("Role")
			.HasColumnType("uniqueidentifier")
			.IsRequired();
		builder.HasOne(x => x.FromRole)
			.WithMany()
			.HasForeignKey(x => x.IdRole)
			.HasConstraintName("FK_Purpose_FromRole")
			.OnDelete(DeleteBehavior.Cascade);

		builder.Property(x => x.Name)
			.HasColumnName("Name")
			.HasColumnType("nvarchar")
			.HasMaxLength(30)
			.IsRequired();
		builder.HasIndex(x => x.Name)
			.IsUnique();

		builder.Property(x => x.Description)
			.HasColumnName("Description")
			.HasColumnType("nvarchar")
			.HasMaxLength(150)
			.IsRequired();

		builder.Property(x => x.Value)
			.HasColumnName("Value")
			.HasColumnType("float")
			.IsRequired();

		builder.Property(x => x.CreatedAt)
			.HasColumnName("CreatedAt")
			.HasColumnType("datetime")
			.IsRequired();

		builder.Property(x => x.UpdatedAt)
			.HasColumnName("UpdatedAt")
			.HasColumnType("datetime")
			.IsRequired();
	}
}