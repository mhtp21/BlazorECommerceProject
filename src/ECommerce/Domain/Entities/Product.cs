using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public enum UsageStatus { Recent, BarelyUsed, Old }
        public UsageStatus SetUsage { get; set; }
        public decimal Price { get; set; }
        public bool IsOfferable { get; set; }
        public int SoldCount { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
