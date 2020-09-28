using AutoMapper;
using Challenge_api.Domain.Enums;
using Challenge_API.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge_API.Application.Products
{
    public class GetProducstQuery : IRequest<List<GetProductsResponse>>
    {
        public string SortOption { get; set; }

        public class GetProducstQueryHandler : IRequestHandler<GetProducstQuery, List<GetProductsResponse>>
        {

            private readonly IWooliesXProductService _wooliesXProductService;
            private readonly IMapper _mapper;


            public GetProducstQueryHandler(IWooliesXProductService wooliesXProductService, IMapper mapper)
            {
                _wooliesXProductService = wooliesXProductService;
                _mapper = mapper;
            }

            public async Task<List<GetProductsResponse>> Handle(GetProducstQuery request, CancellationToken cancellationToken)
            {

                var productResponse = await _wooliesXProductService.GetProducts();
                if (productResponse != null && productResponse.Count > 0)
                {
                    var response = _mapper.Map<List<GetProductsResponse>>(productResponse);
                    switch (request.SortOption.ToLower())
                    {
                        case SortType.Low:
                            return response.OrderBy(x => x.Price).ToList();
                        case SortType.High:
                            return response.OrderByDescending(x => x.Price).ToList();
                        case SortType.Ascending:
                            return response.OrderBy(x => x.Name).ToList();
                        case SortType.Descending:
                            return response.OrderByDescending(x => x.Name).ToList();
                        case SortType.Recommended:
                            {
                                var shopperHistoryResponse = await _wooliesXProductService.GetShopperHistory();
                                var groupeList = shopperHistoryResponse.Where(c => c != null && c.Products != null).SelectMany(x => x.Products.Select(y => y.Name)).AsEnumerable().ToList().GroupBy(x => x).Select(g => g.Key).ToList();
                                var recommendedProducts = (from c in response
                                                           join d in groupeList.DefaultIfEmpty() on c.Name equals d
                                                           orderby d
                                                           select c)
                                          .Union(from e in response
                                                 select e);


                                return recommendedProducts.ToList();
                            }

                        default:
                            return response.OrderByDescending(x => x.Price).ToList();

                    }
                }
                return null;
            }
        }

    }
}
