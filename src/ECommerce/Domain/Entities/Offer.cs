using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Offer : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public decimal OfferPrice { get; set; }
        public enum İsApproved { Waiting, Approved, NotApproved}
        public İsApproved Approved { get; set; }
        public bool Offerwithdrawal { get; set; }

        public virtual Product Product { get; set; }
        public virtual User CreateOffer { get; set; }
    }
}
