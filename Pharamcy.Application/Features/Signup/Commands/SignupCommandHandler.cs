using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Pharamcy.Application.Features.Login.Queries;
using Pharamcy.Application.Features.Pharmacy.CreatePharmacyCommand;
using Pharamcy.Application.Interfaces.Auth;
using Pharamcy.Domain.Identity;
using Pharamcy.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Application.Features.Signup.Commands
{
    public record SignupCommand:IRequest<Response>
    {
      public string UserName { get; set; }
        public string Password { get; set; }
        public string Email  { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalId { get; set; }
        public string Role { get; set; }
    };
    public class SignupCommandHandler: IRequestHandler<SignupCommand, Response>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationUser>  _roleManager;
        private readonly IMapper _mapper;
        public SignupCommandHandler(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationUser> roleManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }
        public async Task<Response> Handle(SignupCommand command, CancellationToken cancellationToken) { 
        
          if(await _userManager.FindByEmailAsync(command.Email)!=null)
                return new Response() {  IsSuccess=false, Message="The Email Already Exist"};

            if (await _userManager.FindByNameAsync(command.UserName) != null)
                return new Response { IsSuccess = false, Message = "The Name Already Exist"};

            var user = _mapper.Map<ApplicationUser>(command); 
            
           var result= await _userManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                var errors = string.Empty;
                foreach (var error in result.Errors)
                {
                    errors += error + " , ";
                }
                return new Response() { IsSuccess=false ,Message = errors };
            }
            await _userManager.AddToRoleAsync(user, command.Role);
            return new Response() { IsSuccess = true, Data = user.Id };
        }


    }
}
