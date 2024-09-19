namespace E_Commerce.Application.DTO
{
    public class OrderDto
    {
        public List<OrderItemDto> OrderItems { get; set; }
        public string CustomerId { get; set; }
    }
}