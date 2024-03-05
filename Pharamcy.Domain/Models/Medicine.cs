﻿using System.Security.Permissions;

namespace Pharamcy.Domain.Models
{
    public class Medicine : BaseEntity
    {
        public int? ShortCode { get; set; }
        public double PurchasePrice { get; set; }
        public bool AllowToPrint { get; set; }
        public bool AllowToSale { get; set; }
        public string StroageRack { get; set; }
        public double StorageTemperature { get; set; } = 25;
        public int MinimumAmount { get; set; }
        public int MaximumAmount { get; set; }
        public double BuyDiscount { get; set; }
        public int Reflux { get; set; }
        public int OfferCount { get; set; }
        public double Offer { get; set; }
        public int DefaultSale { get; set; }
        public string MessageDuringSale { get; set; }
        public int PharmacyId { get; set; }
        public virtual Pharmacy Pharmacy { get; set; }
        public int MedicinDefinitionId { get; set; }
        public virtual MedicineDefinition Information { get; set; } = new();
        public virtual List<MedicineTracking> Tracking { get; set; } = [];
    }
}
