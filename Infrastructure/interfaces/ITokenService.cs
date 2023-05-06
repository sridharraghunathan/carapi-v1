

using Infrastructure.CarModels;

namespace Infrastructure.interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}