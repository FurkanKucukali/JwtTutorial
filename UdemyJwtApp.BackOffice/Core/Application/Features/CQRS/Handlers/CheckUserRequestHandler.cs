﻿using MediatR;
using UdemyJwtApp.BackOffice.Core.Application.Dto;
using UdemyJwtApp.BackOffice.Core.Application.Features.CQRS.Queries;
using UdemyJwtApp.BackOffice.Core.Application.Interfaces;
using UdemyJwtApp.BackOffice.Core.Domain;

namespace UdemyJwtApp.BackOffice.Core.Application.Features.CQRS.Handlers
{
    public class CheckUserRequestHandler : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto>
    {
        private readonly IRepository<AppUser> userRepository;
        private readonly IRepository<AppRole> roleRepository;

        public CheckUserRequestHandler(IRepository<AppUser> userRepository, IRepository<AppRole> roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = new CheckUserResponseDto();
            var user = await this.userRepository.GetByFilterAsync(x => x.Username == request.Username && x.Password == request.Password);

            if (user == null)
            {
                dto.IsExist = false;
            }
            else 
            { 
                dto.Username = user.Username;
                dto.IsExist = true;
                dto.Id = user.Id;
                var role = await this.roleRepository.GetByFilterAsync(x=> x.Id == user.AppRoleID);
                dto.Role = role?.Definition;
            }
            return dto;
           
        }
    }
}
