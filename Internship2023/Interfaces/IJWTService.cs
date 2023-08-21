using Internship2023_backend.Models;

namespace Internship2023_backend.Interfaces
{
    public interface IJWTService
    {
        string CreateToken(User user);
    }
}
