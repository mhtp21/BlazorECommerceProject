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
    public class GetListBrandQuery : IRequest<BrandListModel>
    {
        public class GetListBrandQueryHandler : IRequestHandler<GetListBrandQuery, BrandListModel>
        {
            private readonly IMapper _mapper;
            private readonly IBrandRepository _brandRepository;

            public GetListBrandQueryHandler(IMapper mapper, IBrandRepository brandRepository)
            {
                _mapper = mapper;
                _brandRepository = brandRepository;
            }

            public async Task<BrandListModel> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
            {
                var brands = await _brandRepository.GetAll();
                var brandModel = _mapper.Map<BrandListModel>(brands);
                return brandModel;
            }
        }
    }
}