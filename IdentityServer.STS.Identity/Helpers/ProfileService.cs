using IdentityServer.Admin.EntityFramework.Shared.Entities.Identity;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
namespace IdentityServer.STS.Identity.Helpers
{
    public class ProfileService : IProfileService
    {
        private readonly IUserClaimsPrincipalFactory<UserIdentity> _claimsFactory;
        private readonly UserManager<UserIdentity> _userManager;

        public ProfileService(UserManager<UserIdentity> userManager, IUserClaimsPrincipalFactory<UserIdentity> claimsFactory)
        {
            _userManager = userManager;
            _claimsFactory = claimsFactory;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(sub);
            var principal = await _claimsFactory.CreateAsync(user);

            var claims = principal.Claims.ToList();
            claims = claims.Where(claim => context.RequestedClaimTypes.Contains(claim.Type)).ToList();

            // Add custom claims in token here based on user properties or any other source
            claims.Add(new Claim("employee_id", user.EmployeeId ?? string.Empty));

            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(sub);
            context.IsActive = user != null;
        }
    }
}
