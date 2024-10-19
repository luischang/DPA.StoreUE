using DPA.Store.DOMAIN.Core.Entities;

namespace DPA.Store.DOMAIN.Core.Interfaces
{
    public interface IOrdersRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Orders>> GetAllByUserId(int userId);
        Task<Orders> GetById(int id);
        Task<int> Insert(Orders orders);
    }
}