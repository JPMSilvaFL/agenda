using AgendaApi.Models.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaApi.Data.Mappings.Profiles;

public class EmployeeMap : IEntityTypeConfiguration<Employee> {
	public void Configure(EntityTypeBuilder<Employee> builder) {
		builder.ToTable("Employee");

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
			.HasConstraintName("FK_Employee_Role")
			.OnDelete(DeleteBehavior.Restrict);

		builder.Property(x => x.IdUser)
			.HasColumnName("User")
			.HasColumnType("uniqueidentifier")
			.IsRequired();
		builder.HasIndex(x => x.IdUser)
			.IsUnique();
		builder.HasOne(x => x.FromUser)
			.WithOne()
			.HasForeignKey<Employee>(x => x.IdUser)
			.HasConstraintName("FK_Employee_User")
			.OnDelete(DeleteBehavior.Cascade);

		builder.Property(x => x.CreatedAt)
			.HasColumnName("CreatedAt")
			.HasColumnType("datetime")
			.IsRequired();
	}
}