using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Application.Features.Pharmacy.Queries.GetAll
{
    public class GetAllPharmacyQueryDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string ArabicHeader { get; set; }
        public string EnglishHeader { get; set; }
        public string ArabicFooter { get; set; }
        public string EnglishFooter { get; set; }
        
        public string AdminId { get; set; }

    }
}
