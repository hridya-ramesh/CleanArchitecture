using AutoMapper;
using Challenge_API.Application.Interfaces;
using Challenge_API.Application.Interfaces.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge_API.Application.Feature.Trolley
{
    public class GetTrolleyTotalQuery : IRequest<decimal>
    {
        public TrolleyDetails TrolleyDetails { get; set; }
        public class GetTrolleyTotalQueryHandler : IRequestHandler<GetTrolleyTotalQuery, decimal>
        {

            private readonly IWooliesXProductService _wooliesXProductService;

            public GetTrolleyTotalQueryHandler(IWooliesXProductService wooliesXProductService)
            {
                _wooliesXProductService = wooliesXProductService;
            }

            public async Task<decimal> Handle(GetTrolleyTotalQuery request, CancellationToken cancellationToken)
            {
                var trolleyTotalResponse = await _wooliesXProductService.GetTrolleyTotal(request.TrolleyDetails);
                return trolleyTotalResponse;


            }
        }
    }

}
