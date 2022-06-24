using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Application.Interfaces.Repositories;
using Common.Models.RequestModels.Update;

namespace Application.Features.Commands.EmailTail
{
    public class UpdateEmailTailCommandHandler : IRequestHandler<UpdateEmailTailCommand,Guid>
    {
        private readonly IMapper _mapper;
        private readonly IEmailTailRepository _emailTailRepository;

        public UpdateEmailTailCommandHandler(IMapper mapper, IEmailTailRepository emailTailRepository)
        {
            _mapper = mapper;
            _emailTailRepository = emailTailRepository;
        }

        public async Task<Guid> Handle(UpdateEmailTailCommand request, CancellationToken cancellationToken)
        {
            var dbETail = await _emailTailRepository.GetByIdAsync(request.Id);
            _mapper.Map(request, dbETail);
            return dbETail.Id;
        }
    }
}