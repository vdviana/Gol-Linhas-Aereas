using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gol.Domain.Entities;

namespace Gol.Infra.Data.Mapping
{
    public class AuthUserMap : IEntityTypeConfiguration<AuthUser>
    {
        public void Configure(EntityTypeBuilder<AuthUser> builder)
        {
            builder.ToTable("User");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.CreationDate)
                .IsRequired()
                .HasColumnName("CreationDate");

            builder.Property(p => p.User)
                .IsRequired()
                .HasColumnName("User");

            builder.Property(p => p.Password)
                .IsRequired()
                .HasColumnName("Password");
        }
    }
}
