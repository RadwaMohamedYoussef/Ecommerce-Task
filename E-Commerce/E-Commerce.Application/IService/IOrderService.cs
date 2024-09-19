using E_Commerce.Application.DTO;
using E_Commerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.IService
{
    public interface IOrderService
    {
        void CreateOrder(string customerId, int storeId, List<OrderItemDto> orderItems);
        void CancelOrder(int orderId);
    }
}
