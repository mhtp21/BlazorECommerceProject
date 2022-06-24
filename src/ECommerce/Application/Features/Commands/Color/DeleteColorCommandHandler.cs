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
    public class DeleteColorCommandHandler : IRequestHandler<DeleteColorCommand, Guid>
    {
        private readonly IColorRepository _colorRepository;
        public DeleteColorCommandHandler(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public async Task<Guid> Handle(DeleteColorCommand request, CancellationToken cancellationToken)
        {
            var dbColor = await _colorRepository.GetByIdAsync(request.Id);
            await _colorRepository.DeleteAsync(dbColor);
            return dbColor.Id;
        }
    }
}
