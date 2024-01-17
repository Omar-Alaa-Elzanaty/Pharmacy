using Microsoft.Extensions.DependencyInjection;
using Pharamcy.Application.Interfaces.Repositories;

namespace Pharamcy.Presistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        
    }
}
