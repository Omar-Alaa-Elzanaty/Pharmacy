using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Presistance.Context;

namespace Pharamcy.Presistance.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected PharmacyDBContext dbContext;

        public BaseRepository(PharmacyDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<T> GetByIdAsync(int id)
        {

            return dbContext.Set<T>().Find(id);
        }

        public Task AddAsync(T input)
        {
            dbContext.Set<T>().Add(input);
            dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task UpdateAsync(T input)
        {
            dbContext.Update(input);
            dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            dbContext.Remove(id);
            dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task<T> GetAsync(Func<T, bool> match)
        {
            return dbContext.Set<T>().FirstOrDefault(match);
        }
    }
}
