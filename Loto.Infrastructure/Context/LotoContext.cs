using Microsoft.EntityFrameworkCore;
using Loto.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loto.Infrastructure.Context
{
    public partial class LotoContext : DbContext
    {
        public LotoContext() {

        }
        public LotoContext(DbContextOptions<LotoContext> options)
            : base(options) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfigurationBranchEntity();

            modelBuilder.AddConfigurationLotteryEntity();

            modelBuilder.AddConfigurationEntity();

            modelBuilder.AddConfigurationTransactionsEntity();

            modelBuilder.AddConfigurationSecurityEntity();

            base.OnModelCreating(modelBuilder);
        }


    }
}
