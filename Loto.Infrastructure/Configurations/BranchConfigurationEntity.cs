using Microsoft.EntityFrameworkCore;
using Loto.Domain.Entities.Branchs;

namespace Loto.Infrastructure.Configurations
{
    public static class BranchConfigurationEntity
    {
        public static void AddConfigurationBranchEntity(this ModelBuilder modelBuilder) 
        {

            modelBuilder.Entity<Branch>(entity =>
            {

                entity.HasKey(x => x.Id);
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Group>(entity =>
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
