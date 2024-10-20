﻿using DPA.Store.DOMAIN.Core.DTO;

namespace DPA.Store.DOMAIN.Core.Interfaces
{
    public interface IOrdersService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<OrdersDTO>> GetAllByUser(int userId);
        Task<OrdersUserDTO?> GetById(int id);
        Task<int> Insert(OrdersInsertDTO ordersDTO);
    }
}