using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Application.Features.Medicines.Queries.GetMedicineByName
{
    public class GetMedicineByNameQueryDto
    {
        public int Id { get; set; }
        public string EnglishName { get; set; }
        public string ArabicName { get; set; }
        public string Pharmacology { get; set; }
        public string CompanyName { get; set; }
        public string Type { get; set; }
        public int NationalCode { get; set; }
        public int? ShortCode { get; set; }
        public bool AllowToPrint { get; set; }
        public bool AllowToSale { get; set; }
        public string StorageRack { get; set; }
        public double StorageTemperature { get; set; } = 25;
        public int MinimumAmount { get; set; }
        public int MaximumAmount { get; set; }
        public int BuyDiscount { get; set; }
        public int Reflux { get; set; }
        public int OfferCount { get; set; }
        public double Offer { get; set; }
        public int DefaultSale { get; set; }
        public string MessageDuringSale { get; set; }
    }
}
