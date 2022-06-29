using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Application.Interfaces.Repositories;
using Common.Models.RequestModels.Delete;

namespace Application.Features.Commands.User
{
    public class DeleteUserCommand : IRequest<DeleteUserModel>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public DeleteUserCommand(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<DeleteUserModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Domain.Entities.User>(request);
            var deleteUser = await _userRepository.DeleteAsync(user);
            var result = _mapper.Map<DeleteUserModel>(deleteUser);
            return result;
        }
    }
}