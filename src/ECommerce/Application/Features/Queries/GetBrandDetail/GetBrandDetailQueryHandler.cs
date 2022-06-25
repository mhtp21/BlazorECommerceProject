using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Common.Models.Queries;
using MediatR;
using AutoMapper;

namespace Application.Features.Queries.GetBrandDetail
{
    public class GetBrandDetailQueryHandler : IRequestHandler<GetBrandDetailQuery, BrandDetailViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IBrandRepository _brandRepository;

        public GetBrandDetailQueryHandler(IMapper mapper, IBrandRepository brandRepository)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
        }

        public async Task<BrandDetailViewModel> Handle(GetBrandDetailQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Brand dbBrand = null;

            if(request.BrandId != Guid.Empty)
            {
                dbBrand = await _brandRepository.GetByIdAsync(request.BrandId);
            }
            else if (!string.IsNullOrEmpty(request.BrandName))
            {
                dbBrand = await _brandRepository.GetSingleAsync(i => i.Name == request.BrandName);
            }
            return _mapper.Map<BrandDetailViewModel>(dbBrand);
        }
    }
}
