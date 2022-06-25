using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Common.Models.Queries;
using MediatR;
using AutoMapper;

namespace Application.Features.Queries.GetEmailTailDetail
{
    public class GetEmailTailDetailQueryHandler : IRequestHandler<GetEmailTailDetailQuery, EmailTailDetailViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IEmailTailRepository _emailTailRepository;

        public GetEmailTailDetailQueryHandler(IMapper mapper, IEmailTailRepository emailTailRepository)
        {
            _mapper = mapper;
            _emailTailRepository = emailTailRepository;
        }

        public async Task<EmailTailDetailViewModel> Handle(GetEmailTailDetailQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.EmailTail dbEmailTail = null;

            if (request.EmailTailId != Guid.Empty)
            {
                dbEmailTail = await _emailTailRepository.GetByIdAsync(request.EmailTailId);
            }
            else if (!string.IsNullOrEmpty(request.Email))
            {
                dbEmailTail = await _emailTailRepository.GetSingleAsync(i => i.Email == request.Email);
            }
            return _mapper.Map<EmailTailDetailViewModel>(dbEmailTail);
        }
    }
}
