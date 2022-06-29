using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Application.Interfaces.Repositories;
using Common.Models.RequestModels.Delete;

namespace Application.Features.Commands.Brand
{
    public class DeleteBrandCommand : IRequest<DeleteBrandModel>
    {
        private readonly IMapper _mapper;
        private readonly IBrandRepository _brandRepository;

        public DeleteBrandCommand(IBrandRepository brandRepository, IMapper mapper)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
        }
        public async Task<DeleteBrandModel> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = _mapper.Map<Domain.Entities.Brand>(request);
            var deleteBrand = await _brandRepository.DeleteAsync(brand);
            var result = _mapper.Map<DeleteBrandModel>(deleteBrand);
            return result;
        }
    }
}
