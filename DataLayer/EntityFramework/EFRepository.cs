using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer
{
    public class EFRepository<T> : IRepository<T>
        where T : Entity
    {
        private readonly EFDBContext context;

        public EFRepository(EFDBContext context)
        {
            this.context = context;
        }

        public async Task<int> AddAsync(T entity)
        {
            var e = await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return e.Entity.Id;
        }

        public virtual async Task<List<T>> GetAsync(Func<T, bool> selector)
        {
            return await Task.Run(()=>context.Set<T>().AsQueryable().Where(selector).ToList());
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var item = await GetByIdAsync(id);
            context.Set<T>().Remove(item);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
