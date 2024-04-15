using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharamcy.Domain.Models;

namespace Pharamcy.Application.Interfaces.Repositories
{
    public interface IPharmacyRepository:IBaseRepository<Pharmacy>
    {
        Task<List<int>> FindByUserId(string userId);
        Task<Pharmacy?> CheckPharmacy(int pharmacyId);
    }
}
