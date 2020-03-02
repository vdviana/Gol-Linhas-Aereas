using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Gol.Domain.Entities;

namespace Gol.Infra.Data.Mapping
{
    public class TravelMap : IEntityTypeConfiguration<Travel>
    {
        public void Configure(EntityTypeBuilder<Travel> builder)
        {
            builder.ToTable("User");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.CreationDate)
                .IsRequired()
                .HasColumnName("CreationDate");

            builder.Property(p => p.Nome).HasColumnName("Nome");
            builder.Property(p => p.DataPartida).HasColumnName("DataPartida");
            builder.Property(p => p.Origem).HasColumnName("Origem");
            builder.Property(p => p.Destino).HasColumnName("Destino");
        }
    }
}
