using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Types;

public class PaymentMap : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("payment");

        builder.Property(i => i.Id)
            .HasColumnName("id");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Description)
            .HasColumnName("description")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80)
            .IsRequired();
    }
}