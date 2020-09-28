using Challenge_API.Application.Feature.Trolley;
using Challenge_API.Application.Interfaces;
using Challenge_API.Application.Interfaces.Request;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static Challenge_API.Application.Feature.Trolley.GetTrolleyTotalQuery;

namespace Challenge_API.Appllication.UnitTests.Feature.Trolley
{
   public  class GetTrolleyTotalQueryTest
    {
        private readonly Mock<IWooliesXProductService> _mockWooliesXProductService;

        public GetTrolleyTotalQueryTest()
        {
            _mockWooliesXProductService = new Mock<IWooliesXProductService>();
        }
        [Fact]
        public async Task Handle_GetTrolleyTotalQuery_ReturnsLowestTotal()
        {
            // arrange
            var LowestTotal = 1.0M;
            _mockWooliesXProductService.Setup(x => x.GetTrolleyTotal(It.IsAny<TrolleyDetails>())).Returns(Task.FromResult( 1.0M));


            // act
            var result = await new GetTrolleyTotalQueryHandler(_mockWooliesXProductService.Object).Handle(
                new GetTrolleyTotalQuery
                { TrolleyDetails = new TrolleyDetails { Products = new List<ProductDetails>() { new ProductDetails { Name = "t5", Price = 9 } }, Quantities = new List<QuantityDetail>() { new QuantityDetail { Quantity = 2, Name = "t5" } }, Specials = { } } },default);

            // assert
            Assert.Equal(result, LowestTotal);
        }
    }
}
