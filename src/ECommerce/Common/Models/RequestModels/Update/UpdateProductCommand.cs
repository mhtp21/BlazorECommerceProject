using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Common.Models.RequestModels.Update
{
    public class UpdateProductCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
        public Guid ColorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public enum SizeTypes { XXS, XS, S, M, L, XL, XXL, XXXL };
        public SizeTypes SetSize { get; set; }
        public string ImagePath { get; set; }
        public enum UsageStatus { Recent, BarelyUsed, Old }
        public UsageStatus SetUsage { get; set; }
        public decimal Price { get; set; }
        public bool IsOfferable { get; set; }
        public int SoldCount { get; set; }
    }
}
