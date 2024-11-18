using books_api.Models;

namespace books_api.Interfaces
{
    public interface ITokenService
    {
        string CreateToken (User user);
    }
}
