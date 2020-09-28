
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge_API.Application.Feature.Trolley
{
    public class GetTrolleyTotalQueryValidator : AbstractValidator<GetTrolleyTotalQuery>
    {
        public GetTrolleyTotalQueryValidator()
        {
            RuleFor(o => o.TrolleyDetails).NotNull().NotEmpty();

            RuleFor(o => o.TrolleyDetails.Products).NotNull().NotEmpty();
            RuleFor(o => o.TrolleyDetails.Quantities).NotNull().NotEmpty();
        }

    }
}
