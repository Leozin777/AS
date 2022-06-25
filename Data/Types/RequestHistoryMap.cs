using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Data.Types
{
    public class RequestHistoryMap : IEntityTypeConfiguration<RequestHistory>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<RequestHistory> builder)
        {
            builder.ToTable("requestHistory");

            builder.Property(i => i.Id)
            .HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Status)
                .HasColumnName("status")
                .HasColumnType("BOOLEAN")
                .IsRequired();
        }
    }

}