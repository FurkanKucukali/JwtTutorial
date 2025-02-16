using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyJwtApp.BackOffice.Core.Application.Features.CQRS.Queries;

namespace UdemyJwtApp.BackOffice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoriesController ( IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var result = await this.mediator.Send(new GetCategoriesQueryRequest());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> get(int id )
        {
            var result = await this.mediator.Send(new GetCategoryQueryRequest(id));
            return result == null ? NotFound() : Ok(result);
        }
    }
}
