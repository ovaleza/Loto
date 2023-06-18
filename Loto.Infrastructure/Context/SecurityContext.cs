
using Microsoft.EntityFrameworkCore;
using Loto.Domain.Entities.Security;

namespace Loto.Infrastructure.Context
{
    public partial class LotoContext
    {
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<RolMenu> RolMenu { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
