using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Application.Interfaces.Repositories;
using Common.Models.RequestModels.Delete;

namespace Application.Features.Commands.Payment
{
    public class DeletePaymentCommand : IRequest<DeletePaymentModel>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;
        public DeletePaymentCommand(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<DeletePaymentModel> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = _mapper.Map<Domain.Entities.Payment>(request);
            var deletePayment = await _paymentRepository.DeleteAsync(payment);
            var result = _mapper.Map<DeletePaymentModel>(deletePayment);
            return result;
        }
    }
}
