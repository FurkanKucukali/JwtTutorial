using AutoMapper;
using UdemyJwtApp.BackOffice.Core.Application.Dto;
using UdemyJwtApp.BackOffice.Core.Domain;

namespace UdemyJwtApp.BackOffice.Core.Application.Mappings
{
    public class ProductProfile : Profile
    {

        public ProductProfile() { 
            this.CreateMap<Product,ProductListDto>().ReverseMap();
        }
    }
}
