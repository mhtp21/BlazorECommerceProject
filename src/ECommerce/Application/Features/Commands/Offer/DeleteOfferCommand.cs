using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Application.Interfaces.Repositories;
using Common.Models.RequestModels.Delete;

namespace Application.Features.Commands.Offer
{
    public class DeleteOfferCommand : IRequest<DeleteOfferModel>
    {
        private readonly IMapper _mapper;
        private readonly IOfferRepository _offerRepository;
        public DeleteOfferCommand(IOfferRepository offerRepository, IMapper mapper)
        {
            _offerRepository = offerRepository;
            _mapper = mapper;
        }
        public async Task<DeleteOfferModel> Handle(DeleteOfferCommand request, CancellationToken cancellationToken)
        {
            var offer = _mapper.Map<Domain.Entities.Offer>(request);
            var deleteOffer = await _offerRepository.DeleteAsync(offer);
            var result = _mapper.Map<DeleteOfferModel>(deleteOffer);
            return result;
        }
    }
}
