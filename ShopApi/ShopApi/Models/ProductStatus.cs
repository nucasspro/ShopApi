﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApi.Models
{
    public class ProductStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime InsertedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
