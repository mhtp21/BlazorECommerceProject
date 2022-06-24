using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Application.Interfaces.Repositories;
using Common.Models.RequestModels.Update;

namespace Application.Features.Commands.Brand
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IBrandRepository  _brandRepository;

        public UpdateBrandCommandHandler(IMapper mapper, IBrandRepository brandRepository)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
        }

        public async Task<Guid> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var dbBrand = await _brandRepository.GetByIdAsync(request.Id);
            _mapper.Map(request, dbBrand);
            return dbBrand.Id;
        }
    }
}
