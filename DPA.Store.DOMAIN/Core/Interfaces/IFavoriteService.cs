using DPA.Store.DOMAIN.Core.DTO;

namespace DPA.Store.DOMAIN.Core.Interfaces
{
    public interface IFavoriteService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<FavoriteListDTO>> GetAll(int userId);
        Task<bool> Insert(FavoriteInsertDTO favoriteDTO);
    }
}