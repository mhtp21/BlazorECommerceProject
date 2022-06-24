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
    public class DeleteOfferCommandHandle : IRequestHandler<DeleteOfferCommand, Guid>
    {
        private readonly IOfferRepository _offerRepository;
        public DeleteOfferCommandHandle(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }
        public async Task<Guid> Handle(DeleteOfferCommand request, CancellationToken cancellationToken)
        {
            var dbOffer = await _offerRepository.GetByIdAsync(request.Id);
            await _offerRepository.DeleteAsync(dbOffer);
            return dbOffer.Id;
        }
    }
}
