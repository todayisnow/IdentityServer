using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Admin.EntityFramework.Shared.Entities.Identity
{
    public class UserIdentity : IdentityUser
    {
        [PersonalData]
        public bool IsEnabled { get; set; }
        [PersonalData]
        public string EmployeeId { get; set; }
    }
}







