using DPA.Store.DOMAIN.Core.DTO;
using DPA.Store.DOMAIN.Core.Entities;
using DPA.Store.DOMAIN.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.Store.DOMAIN.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryListDTO>> GetCategories()
        {
            var categories = await _categoryRepository.GetCategories();
            var categoriesDTO = new List<CategoryListDTO>();
            foreach (var category in categories)
            {
                var categoryDTO = new CategoryListDTO();
                categoryDTO.Id = category.Id;
                categoryDTO.Description = category.Description;
                categoriesDTO.Add(categoryDTO);
            }
            return categoriesDTO;
        }

        public async Task<CategoryListDTO> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            var categoryDTO = new CategoryListDTO();

            categoryDTO.Id = category.Id;
            categoryDTO.Description = category.Description;

            return categoryDTO;
        }

        public async Task<int> Insert(CategoryDescriptionDTO categoryDTO)
        {
            var category = new Category();
            category.Description = categoryDTO.Description;
            category.IsActive = true;
            return await _categoryRepository.Insert(category);
        }

        public async Task<bool> Update(CategoryListDTO categoryDTO)
        {
            var category = new Category();
            category.Description = categoryDTO.Description;
            category.Id = categoryDTO.Id;

            return await _categoryRepository.Update(category);

        }
        public async Task<bool> Delete(int id)
        {
            return await _categoryRepository.Delete(id);
        }

        public async Task<CategoryProductsDTO> GetCategoryProductsById(int id)
        {
            var category = await _categoryRepository.GetCategoryProductsById(id);

            var categoryProductsDTO = new CategoryProductsDTO();
            categoryProductsDTO.Id = category.Id;
            categoryProductsDTO.Description = category.Description;

            var products = new List<ProductListDTO>();
            foreach (var cp in category.Product)
            {
                var product = new ProductListDTO();
                product.Id = cp.Id;
                product.Description = cp.Description;
                products.Add(product);
            }
            categoryProductsDTO.Products = products;
            return categoryProductsDTO;
        }

    }
}
