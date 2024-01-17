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

        public T GetById(int id)
        {

            return dbContext.Set<T>().Find(id);
        }

        public void Add(T input)
        {
            dbContext.Set<T>().Add(input);
            dbContext.SaveChanges();
        }

        public void Update(T input)
        {
            dbContext.Update(input);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            dbContext.Remove(id);
            dbContext.SaveChanges();
        }


    }
}
