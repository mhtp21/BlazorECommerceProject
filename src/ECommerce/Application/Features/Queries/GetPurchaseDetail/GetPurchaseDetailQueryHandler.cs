using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Common.Models.Queries;
using MediatR;
using AutoMapper;

namespace Application.Features.Queries.GetPurchaseDetail
{
    public class GetPurchaseDetailQueryHandler : IRequestHandler<GetPurchaseDetailQuery, PurchaseDetailViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IPurchaseRepository _purchaseRepository;

        public GetPurchaseDetailQueryHandler(IMapper mapper, IPurchaseRepository purchaseRepository)
        {
            _mapper = mapper;
            _purchaseRepository = purchaseRepository;
        }

        public async Task<PurchaseDetailViewModel> Handle(GetPurchaseDetailQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Purchase dbPurchase = null;

            if (request.PurchaseId != Guid.Empty)
            {
                dbPurchase = await _purchaseRepository.GetByIdAsync(request.PurchaseId);
            }
            return _mapper.Map<PurchaseDetailViewModel>(dbPurchase);
        }
    }
}
