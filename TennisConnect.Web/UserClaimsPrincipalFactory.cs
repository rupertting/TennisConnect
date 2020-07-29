using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TennisConnect.Data;

namespace TennisConnect.Web
{
    public class UserClaimsPrincipalFactory : UserClaimsPrincipalFactory<User>
    {
        public UserClaimsPrincipalFactory(UserManager<User> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
        }

        protected override Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            return base.GenerateClaimsAsync(user);
        }
    }
}
