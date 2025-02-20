using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyJwtApp.BackOffice.Core.Application.Features.CQRS.Commands;
using UdemyJwtApp.BackOffice.Core.Application.Features.CQRS.Queries;

namespace UdemyJwtApp.BackOffice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register (RegisterUserCommandRequest request)
        {
           var result =  await mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(CheckUserQueryRequest request)
        {
            var dto = await mediator.Send(request);
            if (dto.IsExist) {
                return Created("", "token oluştur");
            }
            else
            {
                return BadRequest("Kullanıcı adı veya sifre hatalı");
            }
        }
    }
}
