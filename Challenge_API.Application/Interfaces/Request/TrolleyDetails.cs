using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge_API.Application.Interfaces.Request
{
    public class TrolleyDetails
    {
        public List<ProductDetails> Products { get; set; }
        public List<ProductSpecialDetail> Specials { get; set; }
        public List<QuantityDetail>Quantities { get; set; }
    }
}
