using Internship2023_backend.Interfaces;
using Internship2023_backend.Models;

namespace Internship2023_backend.Services
{
    public class UsersService: Service<User>, IUsersService
    {
        public UsersService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

    
    }
}
