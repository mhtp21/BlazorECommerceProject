using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Common.Models.Queries;
using MediatR;
using AutoMapper;

namespace Application.Features.Queries.GetColorDetail
{
    public class GetColorDetailQueryHandler : IRequestHandler<GetColorDetailQuery,ColorDetailViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IColorRepository _colorRepository;

        public GetColorDetailQueryHandler(IMapper mapper, IColorRepository colorRepository)
        {
            _mapper = mapper;
            _colorRepository = colorRepository;
        }

        public async Task<ColorDetailViewModel> Handle(GetColorDetailQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Color dbColor = null;

            if (request.ColorId != Guid.Empty)
            {
                dbColor = await _colorRepository.GetByIdAsync(request.ColorId);
            }
            else if (!string.IsNullOrEmpty(request.ColorName))
            {
                dbColor = await _colorRepository.GetSingleAsync(i => i.Name == request.ColorName);
            }
            return _mapper.Map<ColorDetailViewModel>(dbColor);
        }
    }
}
