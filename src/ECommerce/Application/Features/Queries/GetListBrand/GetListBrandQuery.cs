using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Common.Models.Queries;
using Application.Interfaces.Repositories;
using AutoMapper;

namespace Application.Features.Queries.GetListBrand
{
    public class GetListBrandQuery : IRequest<BrandDetailViewModel>
    {
        public class GetListBrandQueryHandler : IRequestHandler<GetListBrandQuery, BrandDetailViewModel>
        {
            private readonly IMapper _mapper;
            private readonly IBrandRepository _brandRepository;

            public GetListBrandQueryHandler(IMapper mapper, IBrandRepository brandRepository)
            {
                _mapper = mapper;
                _brandRepository = brandRepository;
            }

            public async Task<BrandDetailViewModel> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
            {
                var brands = await _brandRepository.GetAll();
                var brandListModel = _mapper.Map<BrandDetailViewModel>(brands);
                return brandListModel;
            }
        }
    }
}
