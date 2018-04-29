using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MVCCoreIdentity.Data;
using MVCCoreIdentity.Models;
using System.Threading.Tasks;

namespace MVCCoreIdentity.Infra
{
    public class ApplicationSignInManager<TUser> : SignInManager<TUser> where TUser : ApplicationUser
    {
        private readonly ApplicationDbContext _context;

        public ApplicationSignInManager(
            UserManager<TUser> userManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<TUser> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<TUser>> logger,
            IAuthenticationSchemeProvider schemes,            
            ApplicationDbContext context)
        : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes)
        {
            _context = context;
        }

        public override Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            var user = _context.Users.FirstOrDefaultAsync(users => users.UserName.Equals(userName));

            if (!user.Result.IsValid)
            {
                return Task.Factory.StartNew(() => SignInResult.NotAllowed);
            }

            return base.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);
        }

    }
}
