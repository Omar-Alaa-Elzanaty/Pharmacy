using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharamcy.Application.DTOs;

namespace Pharamcy.Application.Interfaces.Email
{
    public interface IEmailSerivce
    {
        Task<bool> SendEmailAsync(EmailRequestDto request);
    }
}
