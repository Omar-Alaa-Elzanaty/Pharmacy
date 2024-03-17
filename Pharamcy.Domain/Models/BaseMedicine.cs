﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Domain.Models
{
    public abstract class BaseMedicine:BaseEntity
    {
        public string EnglishName { get; set; }
        public string NormalizedEnglishName => EnglishName.ToUpper();
        public string ArabicName { get; set; }
        public string? Pharmacology { get; set; }
        public string? CompanyName { get; set; }
        public string Type { get; set; }
        public int NationalCode { get; set; }
        public int? ShortCode { get; set; }
        public bool AllowToPrint { get; set; }
        public bool AllowToSale { get; set; }
        public string? Shelf { get; set; }
        public double StorageTemperature { get; set; } = 25;
        public int? MinimumAmount { get; set; }
        public int? MaximumAmount { get; set; }
        public int? BuyDiscount { get; set; }
        public int? Reflux { get; set; }
        public int? OfferCount { get; set; }
        public int? Offer { get; set; }
        public int? DefaultSale { get; set; }
        public string? MessageDuringSale { get; set; }
        public bool IsPartationing { get; set; }
        public int PharmacyId { get; set; }
        public virtual Pharmacy Pharmacy { get; set; }
        public virtual List<MedicalEffectiveMaterial> EffectiveMaterials { get; set; }
    }
}