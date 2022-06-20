﻿using System;

namespace PharmacyManagementSystem.Dto
{
    public class DrugDto
    {
        public int DrugId { get; set; }
        public string DrugName { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; } = DateTime.Now;
        public decimal? Price { get; set; }
        
        public int? SupplierId { get; set; }
    }
}