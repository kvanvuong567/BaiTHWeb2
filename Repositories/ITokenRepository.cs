using Microsoft.AspNetCore.Identity;

namespace BTH_BUOI1.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
