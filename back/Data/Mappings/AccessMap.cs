using AgendaApi.Models.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaApi.Data.Mappings;

public class AccessMap : IEntityTypeConfiguration<Access> {
	public void Configure(EntityTypeBuilder<Access> builder) {
		builder.ToTable("Access");

		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id)
			.HasColumnName("Id")
			.HasColumnType("uniqueidentifier")
			.IsRequired();

		builder.Property(x => x.Name)
			.HasColumnName("Name")
			.HasColumnType("nvarchar")
			.HasMaxLength(50)
			.IsRequired();
		builder.HasIndex(x => x.Name)
			.IsUnique();

		builder.Property(x => x.CreatedAt)
			.HasColumnName("CreatedAt")
			.HasColumnType("datetime")
			.IsRequired();
	}
}