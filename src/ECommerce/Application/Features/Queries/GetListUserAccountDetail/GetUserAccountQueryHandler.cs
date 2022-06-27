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

        public async Task<UserAccountDetail> Handle(GetUserAccountQuery request, CancellationToken cancellationToken)
        {
            var query = _userRepository.AsQueryable();

            UserAccountDetail? userAccountDetail = query.Include(i => i.Purchases)
                            .Include(i => i.Offers).ThenInclude(i => i.Product)
                            .Where(x => x.Id == request.UserId)
                            .Select(z => new UserAccountDetail()
                            {
                                Id = z.Id,
                                CreateDate = z.CreateDate,
                                FirstName = z.FirstName,
                                LastName = z.LastName,
                                Email = z.Email,
                                GivenOffer = z.GivenOffer.OrderByDescending(z => z.CreateDate).Where(z => z.UserId == z.CreateOffer.Id).Take(10).Select(x => new Offer()
                                {
                                    UserId = x.UserId,
                                    ProductId = x.ProductId,
                                    OfferPrice = x.OfferPrice,
                                    Approved = x.Approved,
                                    Offerwithdrawal = x.Offerwithdrawal
                                }).ToList(),
                                TakingOffer = z.TakingOffer.OrderByDescending(z => z.CreateDate).Where(z => z.UserId == z.CreateOffer.Id || z.Product.UserId == z.CreateOffer.Id).Take(10).Select(x => new Offer()
                                {
                                    UserId = x.UserId,
                                    ProductId = x.ProductId,
                                    OfferPrice = x.OfferPrice,
                                    Approved = x.Approved,
                                    Offerwithdrawal = x.Offerwithdrawal
                                }).ToList(),
                            }).FirstOrDefault();

            return userAccountDetail;
        }
    }
}
