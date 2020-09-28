using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge_API.Application.Products
{
    public class GetProductsQueryValidator : AbstractValidator<GetProducstQuery>
    {

        public GetProductsQueryValidator()
        {
            RuleFor(o => o.SortOption).NotEmpty();
        }

    }
}
