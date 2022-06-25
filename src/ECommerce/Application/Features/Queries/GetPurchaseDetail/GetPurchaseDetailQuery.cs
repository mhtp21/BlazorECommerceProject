using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Common.Models.Queries;

namespace Application.Features.Queries.GetPurchaseDetail
{
    public class GetPurchaseDetailQuery : IRequest<PurchaseDetailViewModel>
    {
        public GetPurchaseDetailQuery(Guid purchaseId)
        {
            PurchaseId = purchaseId;
        }

        public Guid PurchaseId { get; set; }
    }
}
