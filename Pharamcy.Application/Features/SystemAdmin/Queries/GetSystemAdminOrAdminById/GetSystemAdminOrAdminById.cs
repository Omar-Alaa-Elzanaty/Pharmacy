﻿using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Identity;
using Pharamcy.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Application.Features.SystemAdmin.Queries.GetSystemAdminOrAdminById
{
    public class GetSystemAdminOrAdminByIdQuery:IRequest<Response>
    {
        public string Id { get; set; }

        public GetSystemAdminOrAdminByIdQuery(string id)
        {
            Id = id;
        }

       
    }
    public class GetSystemAdminOrAdminByIdHandler : IRequestHandler<GetSystemAdminOrAdminByIdQuery, Response>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IStringLocalizer<GetSystemAdminOrAdminByIdHandler> _localizer;
        private readonly IMapper _mapper;

        public GetSystemAdminOrAdminByIdHandler(IMapper mapper, UserManager<ApplicationUser> userManager, IStringLocalizer<GetSystemAdminOrAdminByIdHandler> localizer)
        {
            _mapper = mapper;
            _userManager = userManager;
            _localizer = localizer;
        }

        public async Task<Response> Handle(GetSystemAdminOrAdminByIdQuery query, CancellationToken cancellationToken)
        {
            
             ApplicationUser? user;  
            
              user=await _userManager.FindByIdAsync(query.Id);
                

            if (user == null)
            {
                return await Response.FailureAsync(_localizer["UserNotExist"].Value);
            }
            var userdto=_mapper.Map<GetSystemAdminOrAdminByIdDto>(user); 
            return await Response.SuccessAsync(userdto, _localizer["Success"].Value);   
        }
    }
}
