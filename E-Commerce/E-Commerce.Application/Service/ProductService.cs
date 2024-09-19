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
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddProduct(ProductDto productDto)
        {
            var store = _context.Stores.Find(productDto.StoreId);
            if (store == null)
            {
                throw new KeyNotFoundException($"Store with Id {productDto.StoreId} does not exist.");
            }
            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                StockQuantity = productDto.StockQuantity,
                StoreId = productDto.StoreId
            };
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void EditProduct(int productId, ProductDto productDto)
        {
            var product = _context.Products.Find(productId);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with Id {productId} does not exist.");

            }
                product.Name = productDto.Name;
                product.Price = productDto.Price;
                product.StockQuantity = productDto.StockQuantity;
                _context.SaveChanges();
            
        }

        public void DeleteProduct(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with Id {productId} does not exist.");

            }

                _context.Products.Remove(product);
                _context.SaveChanges();
            
        }
        public void ChangeStatus(int orderId, OrderStatusDto status)
        {
            var order = _context.Orders.Find(orderId);
            if (order == null)
            {
                throw new InvalidOperationException($"Order with Id {orderId} does not exist.");
            }

            order.Status = status.status;
            _context.SaveChanges();

        }
    }
}
