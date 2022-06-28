using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Data.Types
{
    public class StatusMap : IEntityTypeConfiguration<Status>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("status");

            builder.Property(i => i.Id)
            .HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name)
                .HasColumnName("name")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80)
                .IsRequired();

        }
    }

}