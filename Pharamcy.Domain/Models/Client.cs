using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Domain.Models
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public int Indebtedness { get; set; }
        public int LocalDiscount { get; set; }
        public int CreditLimit { get; set; }
        public bool IsCompany { get; set; }
        public bool OnlyCash { get; set; }
        public int Relay { get; set; }
    }
}
