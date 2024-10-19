using DPA.Store.DOMAIN.Core.DTO;
using DPA.Store.DOMAIN.Core.Entities;

namespace DPA.Store.DOMAIN.Core.Interfaces
{
    public interface IUserService
    {
        Task<bool> Insert(User user);
        Task<UserResponseAuthDTO> SignIn(string email, string pwd);
    }
}