using Loto.Domain.Entities.Transactions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loto.Infrastructure.Context
{
    public partial class LotoContext
    {
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Recharge> Recharges { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketD> TicketDs { get; set; }

    }
}
