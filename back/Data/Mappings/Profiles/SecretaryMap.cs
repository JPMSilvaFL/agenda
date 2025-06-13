using AgendaApi.Models.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaApi.Data.Mappings.Profiles;

public class SecretaryMap : IEntityTypeConfiguration<Secretary> {
	public void Configure(EntityTypeBuilder<Secretary> builder) {
		builder.ToTable("Secretary");

		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id)
			.HasColumnName("Id")
			.HasColumnType("uniqueidentifier")
			.IsRequired();

		builder.Property(x => x.IdEmployee)
			.HasColumnName("Employee")
			.HasColumnType("uniqueidentifier")
			.IsRequired();
		builder.HasOne(x => x.FromEmployee)
			.WithOne()
			.HasForeignKey<Secretary>(x => x.IdEmployee)
			.HasConstraintName("FK_Secretary_Employee")
			.OnDelete(DeleteBehavior.NoAction);

		builder.Property(x => x.CreatedAt)
			.HasColumnName("CreatedAt")
			.HasColumnType("datetime")
			.IsRequired();

		builder.Property(x => x.UpdatedAt)
			.HasColumnName("UpdatedAt")
			.HasColumnType("datetime");
	}
}