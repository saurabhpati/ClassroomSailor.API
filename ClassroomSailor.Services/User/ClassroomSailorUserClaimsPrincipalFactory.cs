using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ClassroomSailor.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace ClassroomSailor.Services.User
{
    public class ClassroomSailorUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ClassroomSailorUserEntity>
    {
        public ClassroomSailorUserClaimsPrincipalFactory(
            UserManager<ClassroomSailorUserEntity> userManager,
            IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
        }

        public override async Task<ClaimsPrincipal> CreateAsync(ClassroomSailorUserEntity user)
        {
            ClaimsPrincipal claimsPrincipal = await base.CreateAsync(user).ConfigureAwait(false);
            ClaimsIdentity claimsIdentity = claimsPrincipal.Identities.First();
            claimsIdentity.AddClaim(new Claim("birthdate", user.FirstName));
            claimsIdentity.AddClaim(new Claim("birthdate", user.MiddleName));
            claimsIdentity.AddClaim(new Claim("birthdate", user.LastName));
            claimsIdentity.AddClaim(new Claim("birthdate", user.BirthDate.ToString("MM/dd/yyy")));
            return claimsPrincipal;
        }
    }
}
