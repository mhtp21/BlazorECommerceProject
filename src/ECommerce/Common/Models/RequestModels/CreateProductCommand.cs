using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Common.Models.RequestModels
{
    public class CreateProductCommand : IRequest<Guid>
    {
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

        public CreateProductCommand()
        {

        }
        public CreateProductCommand(Guid userId,Guid categoryId,Guid brandId,Guid colorId,
                                    string name, string description,SizeTypes sizeTypes,string imagePath,
                                    UsageStatus usageStatus,decimal price,bool isofferable,int soldCount)
        {
            UserId = userId;
            CategoryId = categoryId;
            BrandId = brandId;
            ColorId = colorId;
            Name = name;
            Description = description;
            SetSize = sizeTypes;
            ImagePath = imagePath;
            SetUsage = usageStatus;
            Price = price;
            IsOfferable = isofferable;
            SoldCount = soldCount;

        }
    }
}