using AutoMapper;
using MediatR;
using UdemyJwtApp.BackOffice.Core.Application.Dto;
using UdemyJwtApp.BackOffice.Core.Application.Features.CQRS.Queries;
using UdemyJwtApp.BackOffice.Core.Application.Interfaces;
using UdemyJwtApp.BackOffice.Core.Domain;

namespace UdemyJwtApp.BackOffice.Core.Application.Features.CQRS.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, List<ProductListDto>>
    {
        private readonly IRepository<Product> repository;
        private readonly IMapper mapper;

        public GetAllProductsQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<ProductListDto>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await this.repository.GetAllAsync() ?? new List<Product>(); // Null kontrolü

            return this.mapper.Map<List<ProductListDto>>(data);
        }
    }
}
