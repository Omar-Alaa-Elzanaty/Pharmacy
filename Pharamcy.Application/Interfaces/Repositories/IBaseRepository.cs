namespace Pharamcy.Application.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T:class
    {
        //add-delete-update-getbyid

        public  Task<T> GetByIdAsync(int id);
        public  Task<T> GetAsync(Func<T,bool>match);


        public Task AddAsync(T input);

        public Task UpdateAsync(T input);

        public Task DeleteAsync(int id);
    }
}
