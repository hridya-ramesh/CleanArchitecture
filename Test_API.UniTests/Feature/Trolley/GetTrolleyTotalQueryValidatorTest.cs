using Challenge_API.Application.Feature.Trolley;
using Challenge_API.Application.Interfaces.Request;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Challenge_API.Appllication.UnitTests.Feature.Trolley
{
    public class GetTrolleyTotalQueryValidatorTest
    {
        private readonly GetTrolleyTotalQueryValidator _getTrolleyTotalQueryValidatorTest = new GetTrolleyTotalQueryValidator();
        [Theory]
        [InlineData(null)]
    
        public void GetTrolleyTotal_WhenProductIsNullOrEmpty_ReturnsError(List<ProductDetails> productDetails)
        {
            var query = new GetTrolleyTotalQuery
            {
                TrolleyDetails = new TrolleyDetails
                {
                    Products = productDetails,
                    Quantities = new List<QuantityDetail>()
                }
            };

            _getTrolleyTotalQueryValidatorTest.ShouldHaveValidationErrorFor(x => x.TrolleyDetails.Products, query);
        }

        [Theory]
        [InlineData(null)]

        public void GetTrolleyTotal_WhenQuantityIsNullOrEmpty_ReturnsError(List<QuantityDetail> quantitytDetails)
        {
            var query = new GetTrolleyTotalQuery
            {
                TrolleyDetails = new TrolleyDetails
                {
                    Products = new List<ProductDetails>(),
                    Quantities = quantitytDetails
                }
            };

            _getTrolleyTotalQueryValidatorTest.ShouldHaveValidationErrorFor(x => x.TrolleyDetails.Quantities, query);
        }
    }
}
