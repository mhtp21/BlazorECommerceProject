using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Application.Interfaces.Repositories;
using Common.Models.RequestModels;
using MediatR;

namespace Application.Features.Commands.Offer
{
    public class CreateOfferCommandHandler : IRequestHandler<CreateOfferCommand,Guid>
    {
        private readonly IMapper _mapper;
        private readonly IOfferRepository _offerRepository;

        public CreateOfferCommandHandler(IMapper mapper, IOfferRepository offerRepository)
        {
            _mapper = mapper;
            _offerRepository = offerRepository;
        }

        public async Task<Guid> Handle(CreateOfferCommand request, CancellationToken cancellationToken)
        {
            var dbOffer = _mapper.Map<Domain.Entities.Offer>(request);
            await _offerRepository.AddAsync(dbOffer);
            return dbOffer.Id;
        }
    }
}
