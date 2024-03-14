using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentEmail.Core;
using Pharamcy.Application.DTOs;
using Pharamcy.Application.Interfaces.Email;

namespace Pharamcy.Infrastructure.Email
{
    public class EmailService : IEmailSerivce
    {
        public Task<bool> SendEmailAsync(EmailRequestDto request)
        {
            //TODO: Hossam implementation
            throw new NotImplementedException();
        }
    }
}
