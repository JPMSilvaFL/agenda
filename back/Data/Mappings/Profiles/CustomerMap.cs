using AgendaApi.Models.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaApi.Data.Mappings.Profiles;

public class CustomerMap : IEntityTypeConfiguration<Customer> {
	public void Configure(EntityTypeBuilder<Customer> builder) {
		builder.ToTable("Customer");

		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id)
			.HasColumnName("Id")
			.HasColumnType("uniqueidentifier")
			.IsRequired();

		builder.Property(x => x.IdUser)
			.HasColumnName("User")
			.HasColumnType("uniqueidentifier")
			.IsRequired();
		builder.HasIndex(x => x.IdUser)
			.IsUnique();
		builder.HasOne(x => x.FromUser)
			.WithOne()
			.HasForeignKey<Customer>(x => x.IdUser)
			.HasConstraintName("FK_Customar_User")
			.OnDelete(DeleteBehavior.Cascade);

		builder.Property(x => x.CreatedAt)
			.HasColumnName("CreatedAt")
			.HasColumnType("datetime")
			.IsRequired();
	}
}