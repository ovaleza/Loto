using Loto.Domain.Entities.Lottery;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loto.Infrastructure.Context
{
    public partial class LotoContext
    {
        public DbSet<Lottery> Lotteries { get; set; }
        public DbSet<Mode> Modes { get; set; }    
    }
}
