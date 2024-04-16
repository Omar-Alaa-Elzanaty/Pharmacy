using Microsoft.AspNetCore.Http;
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
        private readonly IHttpContextAccessor _contextAccessor;

        public PharmacyRepository(
            PharmacyDBContext dbContext,
            UserManager<ApplicationUser> userManager,
            IStringLocalizer<PharmacyRepository> localization,
            IHttpContextAccessor contextAccessor) : base(dbContext)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _localization = localization;
            _contextAccessor = contextAccessor;
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

        public async Task<Pharmacy?> CheckPharmacy(int pharmacyId)
        {
            var user = await _userManager.GetUserAsync(_contextAccessor.HttpContext!.User);

            var pharmacy = await _dbContext.Pharmacies.FindAsync(pharmacyId);

            if (user is null || pharmacy is null)
            {
                return null;
            }

            var role = _userManager.GetRolesAsync(user).Result.First();

            if (role == SystemRoles.Cashier || role == SystemRoles.Moderator)
            {
                pharmacyId = int.Parse(_userManager.GetClaimsAsync(user)
                            .Result.Single(x => x.Type == CommonConsts.PharmacyId).Value);

                if (pharmacyId != pharmacy.Id)
                {
                    return null;
                }
            }
            else if (role == SystemRoles.SystemAdmin && user.Id != pharmacy.OwnerId)
            {
                return null;
            }

            return pharmacy;
        }
    }
}
