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
    public class DeletePurchaseCommand : IRequest<DeletePurchaseModel>
    {
        private readonly IMapper _mapper;
        private readonly IPurchaseRepository _purchaseRepository;
        public DeletePurchaseCommand(IPurchaseRepository purchaseRepository, IMapper mapper)
        {
            _purchaseRepository = purchaseRepository;
            _mapper = mapper;
        }
        public async Task<DeletePurchaseModel> Handle(DeletePurchaseCommand request, CancellationToken cancellationToken)
        {
            var purchase = _mapper.Map<Domain.Entities.Purchase>(request);
            var deletePurchase = await _purchaseRepository.DeleteAsync(purchase);
            var result = _mapper.Map<DeletePurchaseModel>(deletePurchase);
            return result;
        }
    }
}