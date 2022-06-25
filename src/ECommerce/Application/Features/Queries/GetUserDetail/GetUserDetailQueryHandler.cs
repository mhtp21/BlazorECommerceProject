using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Common.Models.Queries;
using MediatR;
using AutoMapper;

namespace Application.Features.Queries.GetUserDetail
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, UserDetailViewModel>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public GetUserDetailQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<UserDetailViewModel> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.User dbUser = null;

            if (request.UserId != Guid.Empty)
                dbUser = await userRepository.GetByIdAsync(request.UserId);
            else if (!string.IsNullOrEmpty(request.Email))
                dbUser = await userRepository.GetSingleAsync(i => i.FirstName == request.Email);

            return mapper.Map<UserDetailViewModel>(dbUser);
        }
    }
}
