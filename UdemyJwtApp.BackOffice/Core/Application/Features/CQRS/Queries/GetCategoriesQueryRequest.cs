using MediatR;
using UdemyJwtApp.BackOffice.Core.Application.Dto;

namespace UdemyJwtApp.BackOffice.Core.Application.Features.CQRS.Queries
{
    public class GetCategoriesQueryRequest : IRequest<List<CategoryListDto>>
    {
    }
}
