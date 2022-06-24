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
    public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand,Guid>
    {
        private readonly IPaymentRepository _paymentRepository;
        public DeletePaymentCommandHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<Guid> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            var dbPayment = await _paymentRepository.GetByIdAsync(request.Id);
            await _paymentRepository.DeleteAsync(dbPayment);
            return dbPayment.Id;
        }
    }
}
