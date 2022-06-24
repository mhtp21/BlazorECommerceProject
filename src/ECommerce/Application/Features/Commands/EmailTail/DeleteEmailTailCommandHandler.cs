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
    public class DeleteEmailTailCommandHandler : IRequestHandler<DeleteEmailTailCommand,Guid>
    {
        private readonly IEmailTailRepository _emailTailRepository;
        public DeleteEmailTailCommandHandler(IEmailTailRepository emailTailRepository)
        {
            _emailTailRepository = emailTailRepository;
        }

        public async Task<Guid> Handle(DeleteEmailTailCommand request, CancellationToken cancellationToken)
        {
            var dbETail = await _emailTailRepository.GetByIdAsync(request.Id);
            await _emailTailRepository.DeleteAsync(dbETail);
            return dbETail.Id;
        }
    }
}