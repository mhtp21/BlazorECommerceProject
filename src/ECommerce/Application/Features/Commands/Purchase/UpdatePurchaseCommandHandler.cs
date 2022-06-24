using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Application.Interfaces.Repositories;
using Common.Models.RequestModels.Update;

namespace Application.Features.Commands.Purchase
{
    public class UpdatePurchaseCommandHandler : IRequestHandler<UpdatePurchaseCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IPurchaseRepository _purchaseRepository;

        public UpdatePurchaseCommandHandler(IMapper mapper, IPurchaseRepository purchaseRepository)
        {
            _mapper = mapper;
            _purchaseRepository = purchaseRepository;
        }
        public async Task<Guid> Handle(UpdatePurchaseCommand request, CancellationToken cancellationToken)
        {
            var dbPurchase = await _purchaseRepository.GetByIdAsync(request.Id);
            _mapper.Map(request, dbPurchase);
            return dbPurchase.Id;
        }
    }
}
