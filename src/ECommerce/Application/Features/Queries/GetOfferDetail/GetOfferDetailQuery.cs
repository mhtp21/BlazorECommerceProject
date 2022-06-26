using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Common.Models.Queries;

namespace Application.Features.Queries.GetOfferDetail
{
    public class GetOfferDetailQuery : IRequest<OfferDetailViewModel>
    {
        public GetOfferDetailQuery(Guid offerId)
        {
            OfferId = offerId;
        }
        public Guid OfferId { get; set; }
    }
}
