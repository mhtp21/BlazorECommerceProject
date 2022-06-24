using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Application.Interfaces.Repositories;
using Common.Models.RequestModels;
using MediatR;

namespace Application.Features.Commands.Payment
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;

        public CreatePaymentCommandHandler(IMapper mapper, IPaymentRepository paymentRepository)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
        }

        public async Task<Guid> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var dbPayment = _mapper.Map<Domain.Entities.Payment>(request);
            await _paymentRepository.AddAsync(dbPayment);
            return dbPayment.Id;
        }
    }
}
