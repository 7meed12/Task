
using Models.Identity;

namespace Core.InterFaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
