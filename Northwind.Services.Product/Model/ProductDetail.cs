using System;

namespace Northwind.Services.Product.Model
{
    public class ProductDetail
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
    }
}