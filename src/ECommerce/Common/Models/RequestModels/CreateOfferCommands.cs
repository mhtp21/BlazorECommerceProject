﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Common.Models.RequestModels
{
    public class CreateOfferCommands : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public decimal OfferPrice { get; set; }
        public enum İsApproved { Waiting, Approved, NotApproved }

        public İsApproved Approved { get; set; }

        public CreateOfferCommands()
        {

        }
        public CreateOfferCommands(Guid userId,Guid productId,decimal offerPrice,İsApproved isApproved)
        {
            UserId = userId;
            ProductId = productId;
            OfferPrice = offerPrice;
            Approved = isApproved;
        }
    }
}
