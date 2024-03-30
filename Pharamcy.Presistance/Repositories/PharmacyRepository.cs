using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Identity;
using Pharamcy.Domain.Models;
using Pharamcy.Presistance.Context;
using Pharamcy.Shared;

namespace Pharamcy.Presistance.Repositories
{
    public class PharmacyRepository : BaseRepository<Pharmacy>, IPharmacyRepository
    {
        private readonly PharmacyDBContext _dbContext;
        private readonly IStringLocalizer<PharmacyRepository> _localization;
        private readonly UserManager<ApplicationUser> _userManager;

        public PharmacyRepository(
            PharmacyDBContext dbContext,
            UserManager<ApplicationUser> userManager,
            IStringLocalizer<PharmacyRepository> localization) : base(dbContext)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _localization = localization;
        }

        public async Task<List<int>> FindByUserId(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user is null)
            {
                throw new KeyNotFoundException(_localization["UserNotFound"].Value);
            }

            var role = _userManager.GetRolesAsync(user).Result.First();

            if (role == SystemRoles.Admin)
            {
                return await _dbContext.Pharmacies.Where(x => x.OwnerId == user.Id).Select(x => x.Id).ToListAsync();
            }

            var userClaims = await _userManager.GetClaimsAsync(user);
            var pharmacyId = int.Parse(userClaims.First(x => x.Type == CommonConsts.PharmacyId).Value);

            return [pharmacyId];
        }
    }
}
