using AgendaApi.Models.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaApi.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>{
	public void Configure(EntityTypeBuilder<User> builder) {
		builder.ToTable("User");

		builder.HasKey(x=> x.Id);
		builder.Property(x => x.Id)
			.HasColumnName("Id")
			.HasColumnType("uniqueidentifier")
			.IsRequired();

		builder.Property(x => x.Username)
			.HasColumnName("Username")
			.HasColumnType("nvarchar")
			.HasMaxLength(50)
			.IsRequired();
		builder.HasIndex(x => x.Username)
			.IsUnique();

		builder.Property(x => x.PasswordHash)
			.HasColumnName("PasswordHash")
			.HasColumnType("nvarchar")
			.HasMaxLength(255)
			.IsRequired();

		builder.Property(x=>x.IdPerson)
			.HasColumnName("IdPerson")
			.HasColumnType("uniqueidentifier")
			.IsRequired();
		builder.HasIndex(x => x.IdPerson)
			.IsUnique();
		builder.HasOne(x => x.FromPerson)
			.WithOne()
			.HasForeignKey<User>(x => x.IdPerson)
			.HasConstraintName("FK_User_Person")
			.OnDelete(DeleteBehavior.Cascade);

		builder.Property(x => x.IdAccess)
			.HasColumnName("IdAccess")
			.HasColumnType("uniqueidentifier")
			.IsRequired();
		builder.HasOne(x => x.FromAccess)
			.WithMany()
			.HasForeignKey(x=>x.IdAccess)
			.HasConstraintName("FK_User_Access")
			.OnDelete(DeleteBehavior.Restrict);

		builder.Property(x => x.CreatedAt)
			.HasColumnName("CreatedAt")
			.HasColumnType("datetime")
			.IsRequired();
	}
}