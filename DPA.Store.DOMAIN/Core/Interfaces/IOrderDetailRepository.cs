using DPA.Store.DOMAIN.Core.Entities;

namespace DPA.Store.DOMAIN.Core.Interfaces
{
    public interface IOrderDetailRepository
    {
        Task<bool> Insert(IEnumerable<OrderDetail> orderDetails);
    }
}