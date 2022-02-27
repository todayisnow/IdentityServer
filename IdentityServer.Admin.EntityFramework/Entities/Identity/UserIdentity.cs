using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Admin.EntityFramework.Shared.Entities.Identity
{
    public class UserIdentity : IdentityUser
    {
        public bool IsEnabled { get; set; }
        public string EmployeeId { get; set; }
    }
}







