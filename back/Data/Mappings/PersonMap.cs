using AgendaApi.Models.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaApi.Data.Mappings;

public class PersonMap : IEntityTypeConfiguration<Person> {
	public void Configure(EntityTypeBuilder<Person> builder) {
		builder.ToTable("Person");

		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id)
			.HasColumnName("Id")
			.HasColumnType("uniqueidentifier")
			.IsRequired();

		builder.Property(x=>x.FullName)
			.HasColumnName("FullName")
			.HasColumnType("nvarchar")
			.HasMaxLength(100)
			.IsRequired();

		builder.Property(x => x.Status)
			.HasColumnName("Status")
			.HasColumnType("bit")
			.HasDefaultValue(1);

		builder.Property(x=> x.Document)
			.HasColumnName("Document")
			.HasColumnType("nvarchar")
			.HasMaxLength(14)
			.IsRequired();
		builder.HasIndex(x => x.Document)
			.IsUnique();

		builder.Property(x=>x.Type)
			.HasColumnName("Type")
			.HasColumnType("nvarchar")
			.HasMaxLength(1)
			.IsRequired();

		builder.Property(x => x.Email)
			.HasColumnName("Email")
			.HasColumnType("nvarchar")
			.HasMaxLength(100)
			.IsRequired();
		builder.HasIndex(x=> x.Email)
			.IsUnique();

		builder.Property(x=>x.Phone)
			.HasColumnName("Phone")
			.HasColumnType("nvarchar")
			.HasMaxLength(13)
			.IsRequired();

		builder.Property(x=>x.Address)
			.HasColumnName("Address")
			.HasColumnType("nvarchar")
			.HasMaxLength(100)
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