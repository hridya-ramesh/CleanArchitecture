using AutoMapper;
using Challenge_API.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge_API.Application.Feature.User
{
    public class GetUserQuery : IRequest<GetUserResponse>
    {
        public int UserId { get; set; }
        public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserResponse>
        {
            private readonly IMapper _mapper;
            private readonly IWooliesXProductService _wooliesXProductService;

            public GetUserQueryHandler(IMapper mapper, IWooliesXProductService wooliesXProductService)
            {
                _mapper = mapper;
                _wooliesXProductService = wooliesXProductService;
            }

            public async Task<GetUserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
            {
                var userResponse = _wooliesXProductService.GetUser();
                var response = _mapper.Map<GetUserResponse>(userResponse);
                return response;


            }
        }
    }
}
