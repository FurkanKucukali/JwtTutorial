using MediatR;
using UdemyJwtApp.BackOffice.Core.Application.Dto;

namespace UdemyJwtApp.BackOffice.Core.Application.Features.CQRS.Commands
{
    public class DeleteProductCommandRequest:IRequest
    {

        public int Id { get; set; }

        public DeleteProductCommandRequest(int id)
        {
            Id = id;
        }
    }
}
