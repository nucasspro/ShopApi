using System;
using System.Collections.Generic;

namespace ShopApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProductStatus ProductStatusId { get; set; }
        public int RegularPrice { get; set; }
        public int DiscountPrice { get; set; }
        public int Quantity { get; set; }
        public bool Texable { get; set; }
        public DateTime InsertedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
        public virtual ICollection<ProductTag> ProductTags { get; set; }
    }
}