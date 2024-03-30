using Microsoft.EntityFrameworkCore;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain;
using Pharamcy.Presistance.Context;

namespace Pharamcy.Presistance.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly PharmacyDBContext _dbContext;

        public BaseRepository(PharmacyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetByIdAsync(int id)
        {

            return _dbContext.Set<T>().Find(id);
        }

        public Task AddAsync(T input)
        {
            _dbContext.Set<T>().Add(input);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task UpdateAsync(T input)
        {
            _dbContext.Update(input);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(T input)
        {
            _dbContext.Remove(input);
            
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task<T> GetItemOnAsync(Func<T, bool> match)
        {
            return _dbContext.Set<T>().FirstOrDefault(match);
        }
        public async Task<IEnumerable<T>> GetAllAsync(Func<T, bool> match)
        {
            return _dbContext.Set<T>().Where(match);
        }

        public async Task<IEnumerable<TResult>> GetOnCriteriaAsync<TResult>(Func<T, bool> match, Func<T, TResult> selector)
        {
          
            return _dbContext.Set<T>().Where(match).Select(selector);
           

        }

        public async Task<IEnumerable<TResult>?> Get<TResult>(Func<T, TResult> selector)
        {

            return _dbContext.Set<T>().Select(selector).ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public IQueryable<T> Entities()
        {
            return _dbContext.Set<T>();
        }
    }
}
