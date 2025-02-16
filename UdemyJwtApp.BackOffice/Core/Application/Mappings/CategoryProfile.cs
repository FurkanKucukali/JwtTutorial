using AutoMapper;
using UdemyJwtApp.BackOffice.Core.Application.Dto;
using UdemyJwtApp.BackOffice.Core.Domain;

namespace UdemyJwtApp.BackOffice.Core.Application.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() { 
        
            this.CreateMap< Category,CategoryListDto>().ReverseMap();
        }
    }
}
