using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Application.Interfaces.Repositories;
using Common.Models.RequestModels.Update;

namespace Application.Features.Commands.Payment
{
    public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand,Guid>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;

        public UpdatePaymentCommandHandler(IMapper mapper, IPaymentRepository paymentRepository)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
        }

        public async Task<Guid> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            var dbPayment = await _paymentRepository.GetByIdAsync(request.Id);
            _mapper.Map(request, dbPayment);
            return dbPayment.Id;
        }
    }
}
