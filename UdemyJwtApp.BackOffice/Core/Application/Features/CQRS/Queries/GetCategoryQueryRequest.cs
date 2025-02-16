using MediatR;
using UdemyJwtApp.BackOffice.Core.Application.Dto;

namespace UdemyJwtApp.BackOffice.Core.Application.Features.CQRS.Queries
{
    public class GetCategoryQueryRequest:IRequest<CategoryListDto?>
    {
        public int Id { get; set; }

        public GetCategoryQueryRequest(int id)
        {
            Id = id;
        }

        public GetCategoryQueryRequest()
        {
        }
    }
}
