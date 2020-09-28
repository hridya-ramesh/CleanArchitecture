using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenge_API.Application.Feature.Trolley;
using Challenge_API.Application.Feature.User;
using Challenge_API.Application.Interfaces.Request;
using Challenge_API.Application.Products;
using Challenge_API.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Test_API.Controllers
{
    [Route("Products")]
    [ApiController]
    public class ProductsController : APIControllerBase
    {
        private readonly ILogger _logger;
        public ProductsController (ILoggerFactory logFactory)
        {
            _logger = logFactory.CreateLogger<ProductsController>();
        }

        [HttpGet("sort")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GetProductsResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductsAsync(string sortOption="Low")
        {
            _logger.LogInformation("sortType {0}", sortOption);
            var result = await Mediator.Send(new GetProducstQuery { SortOption= sortOption });
            return new JsonResult(result);
        }

        [HttpGet("User")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GetUserResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserAsync()
     {
            var result = await Mediator.Send(new GetUserQuery());
            return new JsonResult(result);
        }


        [HttpPost("trolleyTotal")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(decimal), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLowestTotalAsync(TrolleyDetails trolleyData)
        {
            var result = await Mediator.Send(new GetTrolleyTotalQuery { TrolleyDetails = trolleyData });
            return new JsonResult(result);
        }

    }
}
