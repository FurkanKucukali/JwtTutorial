using MediatR;
using UdemyJwtApp.BackOffice.Core.Application.Features.CQRS.Commands;
using UdemyJwtApp.BackOffice.Core.Application.Interfaces;
using UdemyJwtApp.BackOffice.Core.Domain;

namespace UdemyJwtApp.BackOffice.Core.Application.Features.CQRS.Handlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest>
    {
        private readonly IRepository<Category> repository;

        public DeleteCategoryCommandHandler(IRepository<Category> repository)
        {
            this.repository = repository;
        }
        public async Task<Unit> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
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
