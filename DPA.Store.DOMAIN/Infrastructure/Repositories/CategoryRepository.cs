using DPA.Store.DOMAIN.Core.Entities;
using DPA.Store.DOMAIN.Core.Interfaces;
using DPA.Store.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.Store.DOMAIN.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDbContext _dbContext;

        public CategoryRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Sincrona
        public IEnumerable<Category> GetCategoriesSync()
        {
            var categories = _dbContext.Category.ToList();
            return categories;
        }

        //Asíncrona
        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await _dbContext.Category.ToListAsync();
            return categories;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var category = await _dbContext
                            .Category
                            .Where(c => c.Id == id)
                            .FirstOrDefaultAsync();
            return category;
        }

        public async Task<int> Insert(Category category)
        {
            category.IsActive = true;
            await _dbContext.Category.AddAsync(category);
            //await _dbContext.SaveChangesAsync();
            //return category.Id;
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0 ? category.Id : -1;
        }

        public async Task<bool> Update(Category category)
        {
            _dbContext.Category.Update(category);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Delete(int id)
        {
            var category = await GetCategoryById(id);
            if (category == null) return false;

            //_dbContext.Category.Remove(category);
            //int rows = await _dbContext.SaveChangesAsync();
            category.IsActive = false;
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<Category> GetCategoryProductsById(int id)
        {
            var category = await _dbContext
                            .Category
                            .Where(c => c.Id == id)
                            .Include(p=>p.Product)
                            .FirstOrDefaultAsync();
            return category;
        }

    }
}
