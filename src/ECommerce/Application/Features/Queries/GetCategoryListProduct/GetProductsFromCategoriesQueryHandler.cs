using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Interfaces.Repositories;
using Common.Infrastructure.Extensions;
using Common.Models.Page;
using Common.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.GetCategoryListProduct
{
    public class GetProductsFromCategoriesQueryHandler : IRequestHandler<GetProductsFromCategoriesQuery, PagedViewModel<ProductDetailViewModel>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsFromCategoriesQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<PagedViewModel<ProductDetailViewModel>> Handle(GetProductsFromCategoriesQuery request, CancellationToken cancellationToken)
        {
            var query = _productRepository.AsQueryable();

            if (request.CategoryId != null)
            {
                query = query.Where(i => i.CategoryId == request.CategoryId);
            }

            query = query.Include(i => i.Category);

            var list = query.Select(i => new ProductDetailViewModel()
            {
                Id = i.Id,
                CreateDate = i.CreateDate,
                UserId = i.UserId,
                CategoryId = i.CategoryId,
                BrandId = i.BrandId,
                ColorId = i.ColorId,
                Name = i.Name,
                Description =i.Description,
                SetSize = (ProductDetailViewModel.SizeTypes)i.SetSize,
                ImagePath = i.ImagePath,
                SetUsage = (ProductDetailViewModel.UsageStatus)i.SetUsage,
                Price = i.Price,
                IsOfferable = i.IsOfferable,
                SoldCount = i.SoldCount,

            });
            var entries = await list.GetPaged(request.Page, request.PageSize);
            return entries;
                
        }
    }
}
