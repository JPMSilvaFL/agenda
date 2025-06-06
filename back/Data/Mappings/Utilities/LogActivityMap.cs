using AgendaApi.Models.Log;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaApi.Data.Mappings.Utilities;

public class LogActivityMap : IEntityTypeConfiguration<LogActivity> {
	public void Configure(EntityTypeBuilder<LogActivity> builder) {
		builder.ToTable("LogActivity");

		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id)
			.HasColumnName("Id")
			.HasColumnType("int")
			.ValueGeneratedOnAdd();

		builder.Property(x => x.User)
			.HasColumnName("User")
			.HasColumnType("uniqueidentifier")
			.IsRequired();
		builder.HasOne(x=>x.FromUser)
			.WithMany()
			.HasForeignKey(x=>x.User)
			.HasConstraintName("FK_LogActivity_User")
			.OnDelete(DeleteBehavior.Cascade);

		builder.Property(x=>x.Type)
			.HasColumnName("Type")
			.HasColumnType("nvarchar")
			.HasMaxLength(100)
			.IsRequired();

		builder.Property(x=>x.Action)
			.HasColumnName("Action")
			.HasColumnType("nvarchar")
			.HasMaxLength(100)
			.IsRequired();

		builder.Property(x=>x.Code)
			.HasColumnName("Code")
			.HasColumnType("nvarchar")
			.HasMaxLength(100)
			.IsRequired();

		builder.Property(x=>x.Description)
			.HasColumnName("Description")
			.HasColumnType("nvarchar")
			.HasMaxLength(150)
			.IsRequired();

		builder.Property(x=>x.CreatedAt)
			.HasColumnName("CreatedAt")
			.HasColumnType("datetime")
			.IsRequired();

	}
}