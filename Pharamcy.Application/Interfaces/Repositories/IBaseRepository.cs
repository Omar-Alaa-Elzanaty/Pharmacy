using Pharamcy.Domain;

namespace Pharamcy.Application.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T:BaseEntity
    {
        //add-delete-update-getbyid

        public  Task<T> GetByIdAsync(int id);
        public  Task<T> GetItemOnAsync(Func<T,bool>match);
        //public  Task<IEnumerable<T>> GetAllByIdAsync(Func<T,bool>match);
        public  Task<IEnumerable<TResult>> GetOnCriteriaAsync<TResult>(Func<T,bool>match,Func<T,TResult>selector);



        public Task<IEnumerable<T>> GetAllAsync();
        public  Task<IEnumerable<T>> GetAllAsync(Func<T, bool> match);

        public IQueryable<T> Entities();
        public Task AddAsync(T input);

        public Task UpdateAsync(T input);

        public Task DeleteAsync(T input);
    }
}
