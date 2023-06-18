
using Microsoft.EntityFrameworkCore;
using Loto.Domain.Entities.Configuration;

namespace Loto.Infrastructure.Context
{
    public partial class LotoContext
    {
        public DbSet<Numeration> NumeroCorrelativo { get; set; }
        public DbSet<Configuration> Configuracion { get; set; }
        public DbSet<Bussines>  Negocio { get; set; }
    }
}
