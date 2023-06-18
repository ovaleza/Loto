using Loto.Domain.Core;
using Loto.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Loto.Infrastructure.Core
{
    public abstract class BaseRepository<TEntity> : Domain.Repository.IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly LotoContext context;
        private readonly DbSet<TEntity> myDbSet;

        public BaseRepository(LotoContext context)
        {
            this.context = context;
            this.myDbSet = this.context.Set<TEntity>();
        }
        public async virtual Task<TEntity> GetById(int Id)
        {
            return await this.myDbSet.FindAsync(Id);
        }
        public async virtual Task Save(TEntity entity)
        {
            await this.myDbSet.AddAsync(entity);
        }

        public virtual async Task Save(params TEntity[] entities)
        {
            await this.myDbSet.AddRangeAsync(entities);
        }

        public async virtual Task Delete(int id)
        {
            TEntity entity = await this.myDbSet.FindAsync(id);
            entity.IsDeleted = true;
            entity.DateDeleted = DateTime.UtcNow;
            entity.IdUserDeleted = 1;
            this.myDbSet.Update(entity);
        }

        public virtual Task Delete(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public async virtual Task<TEntity> Find(Expression<Func<TEntity, bool>> filter)
        {
            return await this.myDbSet.FindAsync(filter);
        }

        public async Task<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> filter)
        {
            return await this.myDbSet.Where(filter).ToListAsync();
        }

        public async virtual Task<IEnumerable<TEntity>> GetAll()
        {
            return await this.myDbSet.ToListAsync();
        }

        public async virtual Task<TEntity> GetByIdAsync(int id)
        {
            return await this.myDbSet.FindAsync(id);
        }

        public async virtual Task Update(TEntity entity)
        {
             this.myDbSet.Update(entity);
        }

        public async virtual Task Update(params TEntity[] entities)
        {
            this.myDbSet.UpdateRange(entities);
        }

        public async virtual Task<bool> Exists(Expression<Func<TEntity, bool>> filter)
        {
            return await this.myDbSet.AnyAsync(filter);
        }

        public async virtual Task SaveChanges()
        {
            await this.context.SaveChangesAsync();
        }
    }
}
