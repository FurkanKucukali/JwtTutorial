using MediatR;
using UdemyJwtApp.BackOffice.Core.Application.Dto;

namespace UdemyJwtApp.BackOffice.Core.Application.Features.CQRS.Commands
{
    public class CreateProductCommandRequest : IRequest
    {
        public string? Name { get; set; }
        public int? Stock { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
