using DPA.Store.DOMAIN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.Store.DOMAIN.Core.DTO
{
    public class OrdersDTO
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UserId { get; set; }
        public string? Status { get; set; }
        public decimal? TotalAmount { get; set; }
        public virtual User? User { get; set; }
    }

    public class OrdersInsertDTO
    {
        public int? UserId { get; set; }
        public IEnumerable<OrderDetailInsertDTO> OrderDetail { get; set; }
    }

    public class OrdersUserDTO
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? Status { get; set; }
        public decimal? TotalAmount { get; set; }
        public virtual UserByIdResponseDTO? User { get; set; }
    }
}
