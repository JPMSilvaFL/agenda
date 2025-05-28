using AgendaApi.Models.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaApi.Data.Mappings;

public class CustomerMap : IEntityTypeConfiguration<Customer>{
	public void Configure(EntityTypeBuilder<Customer> builder) {
		builder.ToTable("Customer");

		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id)
			.HasColumnName("Id")
			.HasColumnType("uniqueidentifier")
			.IsRequired();

		builder.Property(x => x.IdPerson)
			.HasColumnName("IdPerson")
			.HasColumnType("uniqueidentifier")
			.IsRequired();
		builder.HasIndex(x=> x.IdPerson)
			.IsUnique();
		builder.HasOne(x => x.FromPerson)
			.WithOne()
			.HasForeignKey<Customer>(x => x.IdPerson)
			.HasConstraintName("FK_Customar_Person")
			.OnDelete(DeleteBehavior.Cascade);

		builder.Property(x=> x.CreatedAt)
			.HasColumnName("CreatedAt")
			.HasColumnType("datetime")
			.IsRequired();
	}
}