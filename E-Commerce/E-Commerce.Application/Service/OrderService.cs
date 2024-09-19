using E_Commerce.Application.DTO;
using E_Commerce.Application.IService;
using E_Commerce.Domain.Enums;
using E_Commerce.Domain.Models;
using E_Commerce.Infrastrcture.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Service
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateOrder(string customerId, int storeId, List<OrderItemDto> orderItems)
        {
            if (!ValidateProductsFromSameStore(orderItems))
                throw new InvalidOperationException("All products must be from the same store.");

            if (!ValidateOrderStore(storeId, orderItems))
                throw new InvalidOperationException("Order store does not match product store.");

            var order = new Order
            {
                CustomerId = customerId,
                StoreId = storeId,
                OrderDate = DateTime.Now,
                Status = OrderStatus.Pending,
                OrderItems = orderItems.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity
                }).ToList()
            };

            _context.Orders.Add(order);
            _context.SaveChanges();
        }
        private bool ValidateProductsFromSameStore(List<OrderItemDto> orderItems)
        {
            var storeId = _context.Products
                .Where(p => p.Id == orderItems.First().ProductId)
                .Select(p => p.StoreId)
                .FirstOrDefault();

            foreach (var item in orderItems)
            {
                var productStoreId = _context.Products
                    .Where(p => p.Id == item.ProductId)
                    .Select(p => p.StoreId)
                    .FirstOrDefault();

                if (productStoreId != storeId)
                    return false; 
            }

            return true;
        }

        private bool ValidateOrderStore(int storeId, List<OrderItemDto> orderItems)
        {
            var productStoreId = _context.Products
                .Where(p => p.Id == orderItems.First().ProductId)
                .Select(p => p.StoreId)
                .FirstOrDefault();

            return productStoreId == storeId;
        }
        public void CancelOrder(int orderId)
        {
            var order = _context.Orders.Find(orderId);
            if (order == null) {
                throw new InvalidOperationException("No Order With This Id");

            }
        
                order.Status = OrderStatus.Cancelled;
                _context.SaveChanges();
            
        }
    }
}
