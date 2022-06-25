using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Common.Models.Queries;
using Application.Interfaces.Repositories;
using AutoMapper;

namespace Application.Features.Queries.GetListColor
{
    public class GetListColorQuery : IRequest<ColorListModel>
    {
        public class GetListColorQueryHandler : IRequestHandler<GetListColorQuery, ColorListModel>
        {
            private readonly IMapper _mapper;
            private readonly IColorRepository _colorRepository;

            public GetListColorQueryHandler(IMapper mapper, IColorRepository colorRepository)
            {
                _mapper = mapper;
                _colorRepository = colorRepository;
            }

            public async Task<ColorListModel> Handle(GetListColorQuery request, CancellationToken cancellationToken)
            {
                var colors = await _colorRepository.GetAll();
                var colorModel = _mapper.Map<ColorListModel>(colors);
                return colorModel;
            }
        }
    }
}
