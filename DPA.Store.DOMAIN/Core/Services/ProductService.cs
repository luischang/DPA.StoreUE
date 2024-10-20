﻿using DPA.Store.DOMAIN.Core.DTO;
using DPA.Store.DOMAIN.Core.Interfaces;

namespace DPA.Store.DOMAIN.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductCategoryDTO>> GetAll()
        {
            var products = await _repository.GetAll();

            var productsDTO = products.Select(p => new ProductCategoryDTO
            {
                Id = p.Id,
                Description = p.Description,
                Discount = p.Discount,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                Stock = p.Stock,
                Category = new CategoryListDTO() { Id = p.Category.Id, Description = p.Category.Description }
            });
            return productsDTO;
        }
    }
}
