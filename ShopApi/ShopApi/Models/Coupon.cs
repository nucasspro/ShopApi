using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApi.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public int Value { get; set; }
        public bool Multiple { get; set; }
        public DateTime StartDate{ get; set; }
        public DateTime EndDate { get; set; }
        public DateTime InsertedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<SalesOrder> SalesOrders { get; set; }

    }
}
