namespace Pharamcy.Domain.Models
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public int LocalDiscount { get; set; }
        public int CreditLimit { get; set; }
        public bool IsCompany { get; set; }
        public bool OnlyCash { get; set; }
        public int PointsForCurrency { get; set; }
        public int TotalPoints { get; set; }
        public DateTime LastProcess { get; set; }
    }
}
