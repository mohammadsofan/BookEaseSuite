using BookEaseSuite.Domain.Enums;

namespace BookEaseSuite.Application.Interfaces
{
    public interface ITokenService
    {
        string GetToken(long id, string email, string userName, UserRole role);
    }
}
