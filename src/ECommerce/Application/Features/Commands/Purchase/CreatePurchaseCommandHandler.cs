using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Application.Interfaces.Repositories;
using Common.Models.RequestModels;
using MediatR;

namespace Application.Features.Commands.Purchase
{
    public class CreatePurchaseCommandHandler : IRequestHandler<CreatePurchaseCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IPurchaseRepository _purchaseRepository;

        public CreatePurchaseCommandHandler(IMapper mapper, IPurchaseRepository purchaseRepository)
        {
            _mapper = mapper;
            _purchaseRepository = purchaseRepository;
        }
        public async Task<Guid> Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
        {
            var dbPurchase = _mapper.Map<Domain.Entities.Purchase>(request);
            await _purchaseRepository.AddAsync(dbPurchase);
            return dbPurchase.Id;
        }
    }
}