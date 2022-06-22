using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Offer : BaseEntity
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public decimal OfferPrice { get; set; }
        public enum İsApproved { Waiting, Approved, NotApproved }

        public İsApproved Approved { get; set; }
        public virtual User CreateOffer { get; set; }
    }
}
