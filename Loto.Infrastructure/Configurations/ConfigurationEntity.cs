
using Microsoft.EntityFrameworkCore;
using Loto.Domain.Entities.Configuration;

namespace Loto.Infrastructure.Configurations
{
    public static class ConfigurationEntity
    {
        public static void AddConfigurationEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bussines>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameLogo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Document)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TaxPercent).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Currency)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UrlLogo)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Numeration>(entity =>
            {
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Gestion)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Configuration>(entity =>
            {
                entity.Property(e => e.Property)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Resource)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

        }
    }
}
