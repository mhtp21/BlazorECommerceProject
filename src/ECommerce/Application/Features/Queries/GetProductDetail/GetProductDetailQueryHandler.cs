using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Common.Models.Queries;
using MediatR;
using AutoMapper;

namespace Application.Features.Queries.GetProductDetail
{
    public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductDetailViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetProductDetailQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<ProductDetailViewModel> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product dbProduct = null;

            if (request.ProductId != Guid.Empty)
            {
                dbProduct = await _productRepository.GetByIdAsync(request.ProductId);
            }
            else if (!string.IsNullOrEmpty(request.ProductName))
            {
                dbProduct = await _productRepository.GetSingleAsync(i => i.Name == request.ProductName);
            }
            return _mapper.Map<ProductDetailViewModel>(dbProduct);
        }
    }
}
