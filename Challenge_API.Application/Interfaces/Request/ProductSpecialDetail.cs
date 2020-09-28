using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge_API.Application.Interfaces.Request
{
   public  class ProductSpecialDetail
    {
        public List<QuantityDetail> Quantities { get; set; }
        public decimal Total { get; set; }
    }
}
