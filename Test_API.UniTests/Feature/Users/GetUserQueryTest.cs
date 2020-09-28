using AutoMapper;
using Challenge_API.Application.Feature.User;
using Challenge_API.Application.Interfaces;
using Challenge_API.Application.Interfaces.Response;
using Challenge_API.Application.Mappings;
using Moq;
using System.Threading.Tasks;
using Xunit;
using static Challenge_API.Application.Feature.User.GetUserQuery;

namespace Challenge_API.Appllication.UnitTests.Feature.Users
{
    public class GetUserQueryTest
    {
        private readonly Mock<IWooliesXProductService> _mockWooliesXProductService;
        private readonly IMapper _mockMapper;

        public GetUserQueryTest()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            _mockMapper = mockMapper.CreateMapper();
            _mockWooliesXProductService = new Mock<IWooliesXProductService>();
        }
        [Fact]
        public async Task Handle_GetUserQuery_ReturnsUser()
        {
            // arrange
            var Name = "test";
            var Token = "dummy";
            _mockWooliesXProductService.Setup(x => x.GetUser()).Returns(new User { Name =Name, Token = Token });
         

            // act
            var result = await new GetUserQueryHandler(_mockMapper,_mockWooliesXProductService.Object).Handle(
                new GetUserQuery
                {}, default);

            // assert
            Assert.Equal(result.Name, Name);
            Assert.Equal(result.Token, Token);
        }
    }
}
