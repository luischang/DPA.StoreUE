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
    public class OrdersRepository : IOrdersRepository
    {
        private readonly StoreDbContext _dbContext;
        public OrdersRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Insert(Orders orders)
        {
            await _dbContext.Orders.AddAsync(orders);
            await _dbContext.SaveChangesAsync();
            return orders.Id;
        }
        public async Task<IEnumerable<Orders>> GetAllByUserId(int userId)
        {
            return await _dbContext.Orders.Where(x => x.UserId == userId).ToListAsync();
        }
        public async Task<Orders> GetById(int id)
        {
            return await _dbContext
                        .Orders
                        .Where(x => x.Id == id && x.Status.Equals("A"))
                        .Include(u => u.User)
                        .FirstOrDefaultAsync();
        }

        // Delete order by id
        public async Task<bool> Delete(int id)
        {
            var findOrders = await _dbContext.Orders.FindAsync(id);
            if (findOrders == null) return false;

            findOrders.Status = "D";

            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
