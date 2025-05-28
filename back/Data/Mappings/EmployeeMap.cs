using AgendaApi.Models.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaApi.Data.Mappings;

public class EmployeeMap : IEntityTypeConfiguration<Employee>{
	public void Configure(EntityTypeBuilder<Employee> builder) {
		builder.ToTable("Employee");

		builder.HasKey(x => x.Id);
		builder.Property(x=> x.Id)
			.HasColumnName("Id")
			.HasColumnType("uniqueidentifier")
			.IsRequired();

		builder.Property(x => x.IdRole)
			.HasColumnName("IdRole")
			.HasColumnType("uniqueidentifier")
			.IsRequired();
		builder.HasOne(x=>x.FromRole)
			.WithMany()
			.HasForeignKey(x=>x.IdRole)
			.HasConstraintName("FK_Employee_Role")
			.OnDelete(DeleteBehavior.Restrict);

		builder.Property(x => x.IdPerson)
			.HasColumnName("IdPerson")
			.HasColumnType("uniqueidentifier")
			.IsRequired();
		builder.HasIndex(x=> x.IdPerson)
			.IsUnique();
		builder.HasOne(x => x.FromPerson)
			.WithOne()
			.HasForeignKey<Employee>(x => x.IdPerson)
			.HasConstraintName("FK_Employee_Person")
			.OnDelete(DeleteBehavior.Cascade);

		builder.Property(x=> x.CreatedAt)
			.HasColumnName("CreatedAt")
			.HasColumnType("datetime")
			.IsRequired();
	}
}