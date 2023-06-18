using Loto.Domain.Entities.Branchs;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loto.Infrastructure.Context
{
    public partial class LotoContext
    {
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Group> Groups { get; set; }    
    }
}
