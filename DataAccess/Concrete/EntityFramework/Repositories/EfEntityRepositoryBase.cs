using DataAccess.Abstract;
using Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext
    {
        protected TContext _context;
        protected DbSet<TEntity> _table;

        public EfEntityRepositoryBase(TContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _table.AddAsync(entity);         
        }


        public void Delete(TEntity entity)
        {
            _table.Remove(entity);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
           return await _table.AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public IQueryable<TEntity> GetAllQueryable(Expression<Func<TEntity, bool>> filter=null)
        {
            if(filter == null)
            {
                return _table.AsNoTracking().AsQueryable();
            }
            else
            {
                return _table.Where(filter).AsNoTracking().AsQueryable();
            }
        }

        public void Update(TEntity entity)
        {
            _context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.AddRangeAsync(entities);
        }
    }
}
