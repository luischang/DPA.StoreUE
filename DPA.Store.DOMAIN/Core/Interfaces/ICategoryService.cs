using DPA.Store.DOMAIN.Core.DTO;

namespace DPA.Store.DOMAIN.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<CategoryListDTO>> GetCategories();
        Task<CategoryListDTO> GetCategoryById(int id);
        Task<int> Insert(CategoryDescriptionDTO categoryDTO);
        Task<bool> Update(CategoryListDTO categoryDTO);
    }
}