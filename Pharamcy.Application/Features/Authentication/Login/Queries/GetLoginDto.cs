using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Application.Features.Authentication.Login.Queries
{
    public class GetLoginDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PharmacyName { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public string? ImageUrl { get; set; }
        public int? PharmacyId { get; set; }

    }
}
