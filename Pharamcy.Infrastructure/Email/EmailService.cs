using Microsoft.Extensions.Configuration;
using MimeKit;
using Pharamcy.Application.DTOs;
using Pharamcy.Application.Interfaces.Email;
using MailKit.Net.Smtp;

namespace Pharamcy.Infrastructure.Email
{
    public class EmailService : IEmailSerivce
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<bool> SendEmailAsync(EmailRequestDto request)
        {
            var email = new MimeMessage();

            email.From.Add(new MailboxAddress(_configuration["MailSettings:SenderName"], _configuration["MailSettings:SenderEmail"]));

            email.To.Add(new MailboxAddress("Client",request.To));

            email.Subject = request.Subject;

            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = $"<b>{request.Body} </b>"
            };

            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_configuration["MailSettings:Server"], int.Parse(_configuration["MailSettings:Port"]!), false);

                smtp.Authenticate(_configuration["MailSettings:UserName"], _configuration["MailSettings:Password"]);

                smtp.Send(email);
                smtp.Disconnect(true);
            }
            return Task.FromResult(true);   
        }
    }
}
