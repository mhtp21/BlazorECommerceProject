using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Application.Interfaces.Repositories;
using Common.Models.RequestModels.Delete;

namespace Application.Features.Commands.Product
{
    public class DeleteProductCommand : IRequest<DeleteProductModel>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public DeleteProductCommand(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<DeleteProductModel> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Domain.Entities.Product>(request);
            var deleteProduct = await _productRepository.DeleteAsync(product);
            var result = _mapper.Map<DeleteProductModel>(deleteProduct);
            return result;
        }
    }
}
