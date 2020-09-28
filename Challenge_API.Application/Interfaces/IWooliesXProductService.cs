using Challenge_API.Application.Interfaces.Request;
using Challenge_API.Application.Interfaces.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_API.Application.Interfaces
{
   public interface IWooliesXProductService
    {
        Task<List<Product>> GetProducts();
        User GetUser();
        Task<List<ShopperHistory>> GetShopperHistory();
        Task<decimal> GetTrolleyTotal(TrolleyDetails trolleyDetails);
    }
}
