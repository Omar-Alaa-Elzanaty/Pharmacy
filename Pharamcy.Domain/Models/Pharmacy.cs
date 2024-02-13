﻿using Pharamcy.Domain.Identity;

namespace Pharamcy.Domain.Models
{
    public class Pharmacy : BaseEntity
    {
        public string Address { get; set; }
        public string Name { get; set; }
        public string ArabicHeader { get; set; }
        public string EnglishHeader { get; set; }
        public string ArabicFooter { get; set; }
        public string EnglishFooter { get; set; }
        public string AdminId { get; set; }
        public virtual ApplicationUser Admin { get; set; }
        public List<Medicine> Medicines { get; set; } = new();
        public List<PurchaseInvoice> PurchaseInvoices { get; set; } = new();
        public List<SalesInvoice> SalesInvoices { get; set; } = new();
        public List<Client> Clients { get; set; } = new();
        public List<Lost> LostProfits { get; set; } = new();

    }
}
