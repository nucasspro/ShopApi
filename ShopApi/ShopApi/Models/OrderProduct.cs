using System;

namespace ShopApi.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public SalesOrder OrderId { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int SubTotal { get; set; }
        public DateTime InsertedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}