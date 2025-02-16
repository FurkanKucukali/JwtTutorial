using AutoMapper;
using MediatR;
using UdemyJwtApp.BackOffice.Core.Application.Dto;
using UdemyJwtApp.BackOffice.Core.Application.Features.CQRS.Commands;
using UdemyJwtApp.BackOffice.Core.Application.Interfaces;
using UdemyJwtApp.BackOffice.Core.Domain;

namespace UdemyJwtApp.BackOffice.Core.Application.Features.CQRS.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Product> repository;

        public DeleteProductCommandHandler(IMapper mapper, IRepository<Product> repository)
        {
            _mapper = mapper;
            this.repository = repository;
        }

        public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity = await repository.GetByIdAsync(request.Id);
            if (deletedEntity != null)
            {
                await repository.RemoveAsync(deletedEntity);
            }
            return Unit.Value;
        }
    }
}
