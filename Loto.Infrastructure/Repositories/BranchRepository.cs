using Loto.Domain.Entities.Branchs;
using Loto.Infrastructure.Context;
using Loto.Infrastructure.Core;
using Loto.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;

namespace Loto.Infrastructure.Repositories
{
    public class BranchRepository : BaseRepository<Branch>, IBranchRepository
    {
        private readonly LotoContext context;
        private readonly ILogger<BranchRepository> logger;

        public BranchRepository(LotoContext context,
            ILogger<BranchRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public async override Task Save(Branch entity)
        {
            await base.Save(entity);
            await base.SaveChanges();
        }
        public override async Task Update(Branch entity)
        {
            await base.Update(entity);
            await base.SaveChanges();
        }
        public override async Task Delete(int id)
        {
            await base.Delete(id);
            await base.SaveChanges();
        }
    }
}
