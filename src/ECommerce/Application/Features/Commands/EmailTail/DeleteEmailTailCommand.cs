using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Application.Interfaces.Repositories;
using Common.Models.RequestModels.Delete;

namespace Application.Features.Commands.EmailTail
{
    public class DeleteEmailTailCommand : IRequest<DeleteEmailTailModel>
    {
        private readonly IMapper _mapper;
        private readonly IEmailTailRepository _emailTailRepository;
        public DeleteEmailTailCommand(IEmailTailRepository emailTailRepository, IMapper mapper)
        {
            _emailTailRepository = emailTailRepository;
            _mapper = mapper;
        }

        public async Task<DeleteEmailTailModel> Handle(DeleteEmailTailCommand request, CancellationToken cancellationToken)
        {
            var emailTail = _mapper.Map<Domain.Entities.EmailTail>(request);
            var deleteemailTail = await _emailTailRepository.DeleteAsync(emailTail);
            var result = _mapper.Map<DeleteEmailTailModel>(deleteemailTail);
            return result;
        }
    }
}