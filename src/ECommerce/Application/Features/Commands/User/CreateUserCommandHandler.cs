using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Application.Interfaces.Repositories;
using Common.Models.RequestModels;
using MediatR;
using Common.Infrastructure.Exceptions;

namespace Application.Features.Commands.User
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            this._mapper = mapper;
            this._userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existsUser = await _userRepository.GetSingleAsync(i => i.Email == request.Email);

            if (existsUser is not null)
                throw new DatabaseValidationException("User already exists!");

            var dbUser = _mapper.Map<Domain.Entities.User>(request);
            await _userRepository.AddAsync(dbUser);
            return dbUser.Id;
        }
    }
}
