using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Application.Interfaces.Repositories;
using Common.Models.RequestModels;
using MediatR;

namespace Application.Features.Commands.Color
{
    public class CreateColorCommandHandler : IRequestHandler<CreateColorCommand,Guid>
    {
        private readonly IMapper _mapper;
        private IColorRepository _colorRepository;

        public CreateColorCommandHandler(IMapper mapper, IColorRepository colorRepository)
        {
            _mapper = mapper;
            _colorRepository = colorRepository;
        }

        public async Task<Guid> Handle(CreateColorCommand request, CancellationToken cancellationToken)
        {
            var dbColor = _mapper.Map<Domain.Entities.Color>(request);
            await _colorRepository.AddAsync(dbColor);
            return dbColor.Id;
        }
    }
}
