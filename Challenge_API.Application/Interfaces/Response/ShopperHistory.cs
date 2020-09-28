using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge_API.Application.Interfaces.Response
{
    public class ShopperHistory 
    {
        public string CustomerId { get; set; }
        public List<Product> Products { get; set; }
    }
}
