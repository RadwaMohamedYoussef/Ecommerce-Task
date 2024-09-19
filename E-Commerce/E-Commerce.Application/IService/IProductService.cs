using E_Commerce.Application.DTO;
using E_Commerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.IService
{
    public interface IProductService
    {
        void AddProduct(ProductDto productDto);
        void EditProduct(int productId, ProductDto productDto);
        void DeleteProduct(int productId);
        void ChangeStatus(int orderId , OrderStatusDto status);

    }
}
