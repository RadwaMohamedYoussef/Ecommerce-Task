using E_Commerce.Application.DTO;
using E_Commerce.Application.IService;
using E_Commerce.Application.Service;
using E_Commerce.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Authorize(Policy = "StoreOwnerPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("add")]
        public IActionResult AddProduct([FromForm] ProductDto productDto)
        {
            _productService.AddProduct(productDto);
            return Ok("Product added successfully.");
        }

        [HttpPut("edit/{id}")]
        public IActionResult EditProduct(int id, [FromForm] ProductDto productDto)
        {
            _productService.EditProduct(id, productDto);
            return Ok("Product updated successfully.");
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
            return Ok("Product deleted successfully.");
        }
        [HttpPut("{orderId}/status")]
        public IActionResult ChangeOrderStatus(int orderId, [FromForm] OrderStatusDto status)
        {
            _productService.ChangeStatus(orderId, status);
            return Ok("Order status updated successfully.");
        }
    }
}
