using DPA.Store.DOMAIN.Core.Entities;
using DPA.Store.DOMAIN.Core.Interfaces;
using DPA.Store.DOMAIN.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.Store.DOMAIN.Infrastructure.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly StoreDbContext _dbContext;
        public OrderDetailRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Insert(IEnumerable<OrderDetail> orderDetails)
        {
            await _dbContext.OrderDetail.AddRangeAsync(orderDetails);
            decimal totalAmount = (decimal)orderDetails.Sum(od => od.Quantity * od.Price);
            var order = await _dbContext.Orders.FindAsync(orderDetails.First().OrdersId);
            order.TotalAmount = totalAmount;
            _dbContext.Orders.Update(order);
            int countRows = await _dbContext.SaveChangesAsync();
            return countRows > 0;
        }
    }
}
