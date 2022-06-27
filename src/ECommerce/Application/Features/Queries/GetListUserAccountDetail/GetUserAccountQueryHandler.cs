using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Application.Features.Queries.GetListUserAccountDetail.Dtos;
using Common.Models.Queries;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Application.Features.Queries.GetListUserAccountDetail
{
    public class GetUserAccountQueryHandler : IRequestHandler<GetUserAccountQuery, UserAccountDetail>
    {
        private readonly IUserRepository _userRepository;

        public GetUserAccountQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public  async Task<UserAccountDetail> Handle(GetUserAccountQuery request, CancellationToken cancellationToken)
        {
            var query = _userRepository.AsQueryable();
            query = query.Include(i => i.Purchases)
                .Include(i => i.Offers).ThenInclude(i => i.Product)
                .Where(x => x.Id == request.UserId);

            var list = query.Select(i => new UserAccountDetail()
            {
                Id = i.Id,
                CreateDate = i.CreateDate,
                FirstName = i.FirstName,
                LastName = i.LastName,
                Email = i.Email,
                GivenOffer = i.GivenOffer.OrderByDescending(i =>i.CreateDate).Where(i => i.UserId == i.CreateOffer.Id).Take(10).Select(x=> new Offer
                {
                    UserId = x.UserId,
                    ProductId = x.ProductId,
                    OfferPrice = x.OfferPrice,
                    Approved = x.Approved,
                    Offerwithdrawal = x.Offerwithdrawal
                }).ToList(),
                TakingOffer = i.TakingOffer.OrderByDescending(i => i.CreateDate).Where(i => i.UserId == i.CreateOffer.Id || i.Product.UserId == i.CreateOffer.Id).Take(10).Select(x=> new Offer{
                    UserId = x.UserId,
                    ProductId = x.ProductId,
                    OfferPrice = x.OfferPrice,
                    Approved = x.Approved,
                    Offerwithdrawal = x.Offerwithdrawal
                }).ToList()
            });

            return await list.FirstOrDefaultAsync(cancellationToken: cancellationToken);

        }
    }
}
