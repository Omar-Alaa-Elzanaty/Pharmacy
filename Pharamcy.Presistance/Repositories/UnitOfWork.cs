using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Presistance.Context;
using System.Collections;

namespace Pharamcy.Presistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PharmacyDBContext _context;
        private Hashtable repositries;
        public UnitOfWork(PharmacyDBContext context)
        {
            _context = context;
        }

        public IBaseRepository<T> Repository<T>() where T : class
        {
            if (repositries == null)
                repositries = new Hashtable();

            var type = typeof(T).Name;

            if (!repositries.ContainsKey(type))
            {
                var repositoryType = typeof(IBaseRepository<>);

                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);

                repositries.Add(type, repositoryInstance);
            }

            return (IBaseRepository<T>)repositries[type]!;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        
    }
}
