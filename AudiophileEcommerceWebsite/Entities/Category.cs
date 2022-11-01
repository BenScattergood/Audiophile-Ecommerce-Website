﻿namespace AudiophileEcommerceWebsite.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public List<Product>? Products { get; set; }

    }
}
