using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Data.Types
{
    public class RequestMap : IEntityTypeConfiguration<Request>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Request> builder)
        {
            builder.ToTable("request");

            builder.Property(i => i.Id)
            .HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.AmountItems)
                .HasColumnName("amountItems")
                .HasColumnType("DECIMAL")
                .IsRequired();

            builder.Property(i => i.RequestDate)
                .HasColumnName("requestDate")
                .HasColumnType("DATE")
                .IsRequired();

            builder.HasOne(x => x.Client)
                .WithMany(x => x.Requests)
                .HasConstraintName("FK_Requests_Client")
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(x => x.Store)
                .WithMany(x => x.Requests)
                .HasConstraintName("FK_Requests_Store")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Payment)
                .WithMany(x => x.Requests)
                .HasConstraintName("FK_Requests_Payment")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Status)
                .WithMany(x => x.Requests)
                .HasConstraintName("FK_Requests_Status")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

