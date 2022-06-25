using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Data.Types
{
    public class ItemMap : IEntityTypeConfiguration<Item>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("item");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);
            
            builder.Property(i => i.Amount)
                .HasColumnName("amount")   
                .HasColumnType("INT") 
                .IsRequired();
            
            builder.Property(i => i.Price)
                .HasColumnName("price")   
                .HasColumnType("DOUBLE") 
                .IsRequired();
            
            builder.Property(i => i.Missing)
                .HasColumnName("missing")   
                .HasColumnType("BOOLEAN") 
                .IsRequired();

            builder.HasOne(x => x.Request)
                 .WithMany(x => x.Items)
                 .HasConstraintName("FK_Requests_Client")
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}