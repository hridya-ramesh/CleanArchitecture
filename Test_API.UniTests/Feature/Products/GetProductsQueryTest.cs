using AutoMapper;
using Challenge_API.Application.Interfaces;
using Challenge_API.Application.Interfaces.Response;
using Challenge_API.Application.Mappings;
using Challenge_API.Application.Products;
using Moq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static Challenge_API.Application.Feature.User.GetUserQuery;
using static Challenge_API.Application.Products.GetProducstQuery;

namespace Challenge_API.Appllication.UnitTests.Feature.Products
{
    public class GetProductsQueryTest
    {
        private readonly Mock<IWooliesXProductService> _mockWooliesXProductService;
        private readonly IMapper _mockMapper;

        public GetProductsQueryTest()
        {
            _mockWooliesXProductService = new Mock<IWooliesXProductService>();
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            _mockMapper = mockMapper.CreateMapper();
        }

        [Theory]
        [InlineData("Low")]
        [InlineData("High")]
        [InlineData("Ascending")]
        [InlineData("Descending")]
        public async Task Handle_GetProductsQuery_ReturnsProduct(string sortType)
        {
            // arrange
            var productA = new Product
            {
                Name = "Test Product a",
                Price = 199.99M,
                Quantity = 1
            };
            var productB = new Product
            {
                Name = "Test Product B",
                Price = 101.99M,
                Quantity = 2
            };
            var productList = new List<Product>() { productA, productB };
            _mockWooliesXProductService.Setup(x => x.GetProducts()).Returns(Task.FromResult(productList));


            // act
            var result = await new GetProducstQueryHandler(_mockWooliesXProductService.Object, _mockMapper).Handle(
                new GetProducstQuery
                {
                    SortOption = sortType
                }, default);

            // assert
            Assert.NotNull(result);
        }
        [Theory]
        [InlineData("Recommended")]
        public async Task Handle_GetProductsQuery_Recommended_ReturnsProduct(string sortType)
        {
            // arrange
            var productA = new Product
            {
                Name = "Test Product a",
                Price = 99.99M,
                Quantity = 0
            };
            var productB = new Product
            {
                Name = "Test Product B",
                Price = 101.99M,
                Quantity = 0
            };

            var productList = new List<Product>() { productA, productB };

            var shoppingHistory = new List<ShopperHistory>() { new ShopperHistory() { CustomerId = "123", Products = productList } };
            _mockWooliesXProductService.Setup(x => x.GetProducts()).Returns(Task.FromResult(productList));
            _mockWooliesXProductService.Setup(x => x.GetShopperHistory()).Returns(Task.FromResult(shoppingHistory));


            // act
            var result = await new GetProducstQueryHandler(_mockWooliesXProductService.Object, _mockMapper).Handle(
                new GetProducstQuery
                {
                    SortOption = sortType
                }, default);

            // assert
            Assert.NotNull(result);
        }
    }
}
