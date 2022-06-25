using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Types
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Client> builder)
        {
             builder.ToTable("client");

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
                
            builder.Property(i => i.CPF)
                .HasColumnName("CPF")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80)
                .IsRequired();  
            
            builder.Property(i => i.DateLastPurchase)
                .HasColumnName("dateLastPurchase")
                .HasColumnType("SMALLDATETIME")
                .IsRequired();
        }
    }
}