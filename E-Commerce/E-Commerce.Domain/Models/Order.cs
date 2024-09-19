using E_Commerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public string CustomerId { get; set; }
        public User Customer { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
    }


}
