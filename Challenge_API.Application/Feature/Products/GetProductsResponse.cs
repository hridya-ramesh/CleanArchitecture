using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge_API.Application.Products
{
    public class GetProductsResponse
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public  decimal Quantity { get; set; }
    }
}
