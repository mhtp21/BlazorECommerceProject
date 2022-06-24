using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Application.Interfaces.Repositories;
using Common.Models.RequestModels.Update;

namespace Application.Features.Commands.Offer
{
    public class UpdateOfferCommandHandler : IRequestHandler<UpdateOfferCommand,Guid>
    {
        private readonly IMapper _mapper;
        private readonly IOfferRepository _offerRepository;

        public UpdateOfferCommandHandler(IMapper mapper, IOfferRepository offerRepository)
        {
            _mapper = mapper;
            _offerRepository = offerRepository;
        }

        public async Task<Guid> Handle(UpdateOfferCommand request, CancellationToken cancellationToken)
        {
            var dbOffer = await _offerRepository.GetByIdAsync(request.Id);
            _mapper.Map(request, dbOffer);
            return dbOffer.Id;
        }
    }
}
