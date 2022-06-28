using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Data.Types
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");

            builder.Property(i => i.Id)
            .HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Price)
            .HasColumnName("price")
            .HasColumnType("DECIMAL")
            .IsRequired();
            
            builder.Property(i => i.Name)
            .HasColumnName("name")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80)
            .IsRequired();

            builder.Property(i => i.SoldAmount)
            .HasColumnName("soldAmount")
            .HasColumnType("INT")
            .IsRequired();

            builder.Property(i => i.QuantityKgSold)
            .HasColumnName("quantityKgSold")
            .HasColumnType("DECIMAL")
            .IsRequired();

            builder.HasOne(x => x.Item)
            .WithMany(x => x.Products)
            .HasConstraintName("FK_Products_Item")
            .OnDelete(DeleteBehavior.Restrict);
        }
    
    }

}