using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Common.Models.Queries;

namespace Application.Features.Queries.GetPaymentDetail
{
    public class GetPaymentDetailQuery : IRequest<PaymentDetailViewModel>
    {
        public GetPaymentDetailQuery(Guid paymentId)
        {
            PaymentId = paymentId;
        }

        public Guid PaymentId { get; set; }
    }
}
