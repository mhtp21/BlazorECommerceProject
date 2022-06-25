using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Common.Models.Queries;
using MediatR;
using AutoMapper;

namespace Application.Features.Queries.GetPaymentDetail
{
    public class GetPaymentDetailQueryHandler : IRequestHandler<GetPaymentDetailQuery, PaymentDetailViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;

        public GetPaymentDetailQueryHandler(IMapper mapper, IPaymentRepository paymentRepository)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
        }

        public async Task<PaymentDetailViewModel> Handle(GetPaymentDetailQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Payment dbPayment = null;

            if (request.PaymentId != Guid.Empty)
            {
                dbPayment = await _paymentRepository.GetByIdAsync(request.PaymentId);
            }
            return _mapper.Map<PaymentDetailViewModel>(dbPayment);
        }
    }
}
