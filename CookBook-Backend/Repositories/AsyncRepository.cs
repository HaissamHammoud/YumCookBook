
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CookBook.Interface;
using CookBook.Models;

using Microsoft.EntityFrameworkCore;

namespace CookBook.Repositories
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        #region Fields

        private CookBookContext Context ;
        private DbSet<T> Entities;

        #endregion

        public AsyncRepository(CookBookContext context)
        {
            Context = context;
            Entities = Context.Set<T>();
        }

        #region Public Methods

        public async Task<T> GetById(Guid id)
        {
            T a = await Entities.FindAsync(id);
            return a;
        }
        public Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
            => Context.Set<T>().FirstOrDefaultAsync(predicate);

        public async Task Add(T entity)
        {
            // await Context.AddAsync(entity);
            await Context.Set<T>().AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            // In case AsNoTracking is used
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChangesAsync();
        }

        public Task Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
            return Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }

        public Task<int> CountAll() => Context.Set<T>().CountAsync();

        public Task<int> CountWhere(Expression<Func<T, bool>> predicate)
            => Context.Set<T>().CountAsync(predicate);


        #endregion
    }
}