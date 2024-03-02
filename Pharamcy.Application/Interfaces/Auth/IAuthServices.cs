using Pharamcy.Domain.Identity;
using Pharamcy.Shared;

namespace Pharamcy.Application.Interfaces.Auth
{
    public interface IAuthServices
    {
        string GenerateToken(ApplicationUser user, string role, int? pharmacyId = null);
    }
}
