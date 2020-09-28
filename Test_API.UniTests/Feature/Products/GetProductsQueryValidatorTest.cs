using Challenge_API.Application.Products;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Challenge_API.Appllication.UnitTests.Feature.Products
{
    public class GetProductsQueryValidatorTest
    {
        private readonly GetProductsQueryValidator _getProductsQueryValidatorTest = new GetProductsQueryValidator();
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void GetProductsQueryValidator_WhenSortOptonIsNullOrEmpty_ReturnsError(string  sortOption)
        {
            var query = new GetProducstQuery
            {
                SortOption=sortOption
            };

            _getProductsQueryValidatorTest.ShouldHaveValidationErrorFor(x => x.SortOption, query);
        }
    }
}
