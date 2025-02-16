using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyJwtApp.BackOffice.Core.Application.Features.CQRS.Commands;
using UdemyJwtApp.BackOffice.Core.Application.Features.CQRS.Queries;

namespace UdemyJwtApp.BackOffice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
           var result = await this.mediator.Send(new GetAllProductsQueryRequest());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var result = await this.mediator.Send(new GetProductQueryRequest(id));
            return result == null ? NotFound() : Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await this.mediator.Send(new DeleteProductCommandRequest(id));
            return NoContent();

        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateProductCommandRequest request)
        {
            await this.mediator.Send(request);
            return Created("", request);

        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommandRequest request)
        {
            await this.mediator.Send(request);
            return NoContent();
        }
    }
}
