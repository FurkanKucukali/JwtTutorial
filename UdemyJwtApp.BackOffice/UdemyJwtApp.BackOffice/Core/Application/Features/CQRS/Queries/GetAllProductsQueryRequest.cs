using MediatR;
using UdemyJwtApp.BackOffice.Core.Application.Dto;

namespace UdemyJwtApp.BackOffice.Core.Application.Features.CQRS.Queries
{
    public class GetAllProductsQueryRequest : IRequest<List<ProductListDto>>
    {
    }
}
