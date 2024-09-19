using E_Commerce.Application.DTO;
using E_Commerce.Application.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Authorize(Policy = "CustomerPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("create")]
        public IActionResult CreateOrder([FromBody] List<OrderItemDto> orderItems, int storeId, string customerId)
        {
            _orderService.CreateOrder(customerId, storeId, orderItems);
            return Ok("Order created successfully.");
        }

        [HttpPut("cancel/{id}")]
        public IActionResult CancelOrder(int id)
        {
            _orderService.CancelOrder(id);
            return Ok("Order cancelled successfully.");
        }
    }

}
