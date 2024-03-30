using Microsoft.EntityFrameworkCore;
using Pharamcy.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Application.Interfaces.Repositories
{
    public interface IUnitOfWork:IDisposable
    {
        IBaseRepository<T> Repository<T>()where T : BaseEntity;
        Task<int> SaveAsync();

    }
}
