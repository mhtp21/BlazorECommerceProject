using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Application.Interfaces.Repositories;
using Common.Models.RequestModels;
using MediatR;

namespace Application.Features.Commands.EmailTail
{
    public class CreateEmailTailCommandHandler : IRequestHandler<CreateEmailTailCommand,Guid>
    {
        private readonly IMapper _mapper;
        private readonly IEmailTailRepository _emailTailRepository;

        public CreateEmailTailCommandHandler(IMapper mapper, IEmailTailRepository emailTailRepository)
        {
            _mapper = mapper;
            _emailTailRepository = emailTailRepository;
        }

        public async Task<Guid> Handle(CreateEmailTailCommand request, CancellationToken cancellationToken)
        {
            var dbETail = _mapper.Map<Domain.Entities.EmailTail>(request);
            await _emailTailRepository.AddAsync(dbETail);
            return dbETail.Id;
        }
    }
}