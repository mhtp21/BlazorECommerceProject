using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Common.Models.Queries;
using MediatR;
using AutoMapper;

namespace Application.Features.Queries.GetOfferDetail
{
    public class GetOfferDetailQueryHandler : IRequestHandler<GetOfferDetailQuery, OfferDetailViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IOfferRepository _offerRepository;

        public GetOfferDetailQueryHandler(IMapper mapper, IOfferRepository offerRepository)
        {
            _mapper = mapper;
            _offerRepository = offerRepository;
        }

        public async Task<OfferDetailViewModel> Handle(GetOfferDetailQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Offer dbOffer = null;

            if (request.OfferId != Guid.Empty)
            {
                dbOffer = await _offerRepository.GetByIdAsync(request.OfferId);
            }
            return _mapper.Map<OfferDetailViewModel>(dbOffer);
        }
    }
}
