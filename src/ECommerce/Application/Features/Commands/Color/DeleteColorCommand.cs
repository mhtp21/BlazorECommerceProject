using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Application.Interfaces.Repositories;
using Common.Models.RequestModels.Delete;

namespace Application.Features.Commands.Color
{
    public class DeleteColorCommand : IRequest<DeleteColorModel>
    {
        private readonly IMapper _mapper;
        private readonly IColorRepository _colorRepository;
        public DeleteColorCommand(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public async Task<DeleteColorModel> Handle(DeleteColorCommand request, CancellationToken cancellationToken)
        {
            var color = _mapper.Map<Domain.Entities.Color>(request);
            var deleteColor = await _colorRepository.DeleteAsync(color);
            var result = _mapper.Map<DeleteColorModel>(deleteColor);
            return result;
        }
    }
}
