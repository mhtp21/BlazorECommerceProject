using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Application.Interfaces.Repositories;
using Common.Models.RequestModels;
using MediatR;

namespace Application.Features.Commands.Brand
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, Guid>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            this._brandRepository = brandRepository;
            this._mapper = mapper;
        }
        public async Task<Guid> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var dbBrand = _mapper.Map<Domain.Entities.Brand>(request);
            await _brandRepository.AddAsync(dbBrand);
            return dbBrand.Id;
        }
    }
}
