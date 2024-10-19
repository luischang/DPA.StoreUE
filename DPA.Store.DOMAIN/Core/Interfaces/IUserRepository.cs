using DPA.Store.DOMAIN.Core.Entities;

namespace DPA.Store.DOMAIN.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> Insert(User user);
        Task<User> SignIn(string email, string pwd);
    }
}