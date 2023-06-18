using Microsoft.EntityFrameworkCore;
using Loto.Domain.Entities.Lottery;

namespace Loto.Infrastructure.Configurations
{
    public static class LotterynConfigurationEntity
    {
        public static void AddConfigurationLotteryEntity(this ModelBuilder modelBuilder) 
        {

            modelBuilder.Entity<Lottery>(entity =>
            {

              
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Mode>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });
        }
    }
}
