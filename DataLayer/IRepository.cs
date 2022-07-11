using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IRepository<T> where T : Entity
    {
        public Task<List<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task<List<T>> GetAsync(Func<T, bool> selector);
        public Task<int> AddAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task RemoveAsync(int id);

    }
}
