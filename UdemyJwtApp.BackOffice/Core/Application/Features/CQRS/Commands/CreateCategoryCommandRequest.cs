﻿using MediatR;

namespace UdemyJwtApp.BackOffice.Core.Application.Features.CQRS.Commands
{
    public class CreateCategoryCommandRequest : IRequest
    {
        
            public string? Definition { get; set; }
           
       
    }
}
