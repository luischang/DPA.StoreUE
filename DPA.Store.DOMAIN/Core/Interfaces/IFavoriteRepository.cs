using DPA.Store.DOMAIN.Core.Entities;

namespace DPA.Store.DOMAIN.Core.Interfaces
{
    public interface IFavoriteRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Favorite>> GetAll(int userId);
        Task<bool> Insert(Favorite favorite);
    }
}