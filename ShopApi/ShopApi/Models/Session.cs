using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApi.Models
{
    public class Session
    {
        public string Id { get; set; }
        public string Data { get; set; }
        public DateTime InsertedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<SalesOrder> SalesOrders { get; set; }
    }
}
