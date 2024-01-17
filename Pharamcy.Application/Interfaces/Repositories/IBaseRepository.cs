namespace Pharamcy.Application.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T:class
    {
        //add-delete-update-getbyid

        T GetById(int id);

        void Add(T input);

        void Update(T input);

        void Delete(int id);
    }
}
