using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Features.Queries.GetListUserAccountDetail.Dtos
{
    public class UserAccountDetail
    {
        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public virtual ICollection<Purchase>? Purchases { get; set;}
        public virtual ICollection<Offer>? GivenOffer { get; set; }
        public virtual ICollection<Offer>? TakingOffer { get; set; }
    }
}