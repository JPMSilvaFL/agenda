﻿using AgendaApi.Models.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaApi.Data.Mappings.Profiles;

public class RoleMap : IEntityTypeConfiguration<Role> {
	public void Configure(EntityTypeBuilder<Role> builder) {
		builder.ToTable("Role");

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

		builder.Property(x => x.Description)
			.HasColumnName("Description")
			.HasColumnType("nvarchar")
			.HasMaxLength(100)
			.IsRequired();

		builder.Property(x => x.CreatedAt)
			.HasColumnName("CreatedAt")
			.HasColumnType("datetime")
			.IsRequired();
	}
}