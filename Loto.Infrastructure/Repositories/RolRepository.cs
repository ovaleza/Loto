

using Loto.Domain.Entities.Security;
using Loto.Infrastructure.Context;
using Loto.Infrastructure.Core;
using Loto.Infrastructure.Interfaces;

namespace Loto.Infrastructure.Repositories
{
    public class RolRepository : BaseRepository<Rol>, IRolRepository
    {
        public RolRepository(LotoContext context) : base(context)
        {
             
        }
        
    }
}
