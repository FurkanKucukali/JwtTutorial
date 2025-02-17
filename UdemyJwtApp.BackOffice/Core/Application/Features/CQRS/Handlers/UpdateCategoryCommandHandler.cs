using MediatR;
using UdemyJwtApp.BackOffice.Core.Application.Features.CQRS.Commands;
using UdemyJwtApp.BackOffice.Core.Application.Interfaces;
using UdemyJwtApp.BackOffice.Core.Domain;

namespace UdemyJwtApp.BackOffice.Core.Application.Features.CQRS.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest>
    {
        private readonly IRepository<Category> repository;
        public UpdateCategoryCommandHandler(IRepository<Category> repository)
        {
            this.repository = repository;
        }
        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedProduct = await this.repository.GetByIdAsync(request.Id);
            if (updatedProduct != null)
            {
                updatedProduct.Definition = request.Definition;

                await this.repository.UpdateAsync(updatedProduct);
            }

            return Unit.Value;
        }
    }
}
