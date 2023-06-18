using Microsoft.EntityFrameworkCore;
using Loto.Domain.Entities.Transactions;

namespace Loto.Infrastructure.Configurations
{
    public static class TransactionsConfigurationEntity
    {
        public static void AddConfigurationTransactionsEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.Branch)
                    .HasColumnName("Branch"); ;

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Serial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

            });
            
            modelBuilder.Entity<TicketD>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnName("Amount");

                entity.Property(e => e.Lottery)
                    .HasColumnName("Lottery");

                entity.Property(e => e.Numbers)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Numbers");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Total");

            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.Branch)
                    .HasColumnName("Branch"); ;

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Serial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Recharge>(entity =>
            {
                entity.Property(e => e.Branch)
                    .HasColumnName("Branch"); ;

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Serial)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            });


        }
    }
    
}
