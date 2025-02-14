using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyJwtApp.BackOffice.Core.Application.Features.CQRS.Queries;

namespace UdemyJwtApp.BackOffice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
           var result = await this._mediator.Send(new GetAllProductsQueryRequest());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var result = await this._mediator.Send(new GetProductQueryRequest(id));
            return result == null ? NotFound() : Ok(result);
        }
    }
}
