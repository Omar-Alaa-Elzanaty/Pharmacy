using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Domain.Models
{
	public class Offer:BaseEntity
	{
        public int Amount { get; set; }
        public double Discount_percentage { get; set; }
        public virtual Medicine Medicine { get; set; }

	}
}
