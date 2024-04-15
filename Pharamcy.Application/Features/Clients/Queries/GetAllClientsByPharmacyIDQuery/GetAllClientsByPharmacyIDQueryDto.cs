using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Application.Features.Clients.Queries.GetAllClientsByPharmacyIDQuery
{
	public class GetAllClientsByPharmacyIDQueryDto
	{
		public string Name { get; set; }
		public string Adress { get; set; }
		public string PhoneNumber { get; set; }
	}
}
