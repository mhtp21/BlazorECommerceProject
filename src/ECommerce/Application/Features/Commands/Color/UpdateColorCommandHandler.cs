using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Application.Interfaces.Repositories;
using Common.Models.RequestModels.Update;

namespace Application.Features.Commands.Color
{
    public class UpdateColorCommandHandler : IRequestHandler<UpdateColorCommand,Guid>
    {
        private readonly IMapper _mapper;
        private readonly IColorRepository _colorRepository;

        public UpdateColorCommandHandler(IMapper mapper, IColorRepository colorRepository)
        {
            _mapper = mapper;
            _colorRepository = colorRepository;
        }

        public async Task<Guid> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
        {
            var dbColor = await _colorRepository.GetByIdAsync(request.Id);
            _mapper.Map(request, dbColor);
            return dbColor.Id;
        }
    }
}
