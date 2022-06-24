using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Application.Interfaces.Repositories;
using Common.Models.RequestModels.Delete;

namespace Application.Features.Commands.Purchase
{
    public class DeletePurchaseCommandHandler : IRequestHandler<DeletePurchaseCommand, Guid>
    {
        private readonly IPurchaseRepository _purchaseRepository;
        public DeletePurchaseCommandHandler(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }
        public async Task<Guid> Handle(DeletePurchaseCommand request, CancellationToken cancellationToken)
        {
            var dbPurchase = await _purchaseRepository.GetByIdAsync(request.Id);
            await _purchaseRepository.DeleteAsync(dbPurchase);
            return dbPurchase.Id;
        }
    }
}