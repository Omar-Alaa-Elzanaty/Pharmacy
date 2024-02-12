using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharamcy.Shared;

namespace Pharamcy.Application.Interfaces.Auth
{
    public interface IAuthServices
    {
        Task<Response> SignUp();
    }
}
