using SimpleShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShop.Core.Interfaces
{
    public interface IOrderDetailRepository
    {
        Task<OrderDetail> GetOrderDetailByIdAsync(int id);
        Task<IEnumerable<OrderDetail>> GetAllOrderDetailsAsync();
        Task AddOrderDetailAsync(OrderDetail orderDetail);
        Task UpdateOrderDetailAsync(OrderDetail orderDetail);
        Task DeleteOrderDetailAsync(int id);
    }
}
