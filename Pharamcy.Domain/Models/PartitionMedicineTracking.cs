﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Domain.Models
{
    public class PartitionMedicineTracking:BaseEntity
    {
        public string BarCode { get; set; }
        public int Amount { get; set; }
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }
        public int TapesCount { get; set; }
        public int TabletsCount { get; set; }
        public int TabletsAvailableAmount { get; set; }
        public double TabletSalePrice { get; set; }
        public int PartitionMedicineId { get; set; }
        public virtual PartitionMedicine PartitionMedicine { get; set; }
    }
}
