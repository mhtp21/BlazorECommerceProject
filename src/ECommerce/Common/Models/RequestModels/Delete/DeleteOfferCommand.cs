using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Common.Models.RequestModels.Delete
{
    public class DeleteOfferCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public decimal OfferPrice { get; set; }
        public enum İsApproved { Waiting, Approved, NotApproved }

        public İsApproved Approved { get; set; }

        public bool Offerwithdrawal { get; set; }
    }
}
