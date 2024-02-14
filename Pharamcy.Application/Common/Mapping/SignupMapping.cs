﻿using Mapster;
using Microsoft.AspNetCore.Routing.Constraints;
using Pharamcy.Application.Features.Authentication.Signup.Commands.CreateSystemAdminAndAdmin;
using Pharamcy.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Application.Common.Mapping
{
    public class SignupMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateSystemAdminAndAdminCommand, ApplicationUser>();


        }
    }
}
