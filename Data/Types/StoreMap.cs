using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Types;

public class StoreMap : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.ToTable("store");
        
        builder.Property(i => i.Id)
            .HasColumnName("id");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Name)
            .HasColumnName("name")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80)
            .IsRequired();

        builder.Property(i => i.PhoneNumber)
            .HasColumnName("phoneNumber")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80)
            .IsRequired();

        builder.Property(i => i.Address)
            .HasColumnName("address")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80)
            .IsRequired();
    }
}