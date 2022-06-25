using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Common.Models.Queries;
using MediatR;
using AutoMapper;

namespace Application.Features.Queries.GetCategoryDetail
{
    public class GetCategoryDetailQueryHandler : IRequestHandler<GetCategoryDetailQuery, CategoryDetailViewModel>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryDetailQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryDetailViewModel> Handle(GetCategoryDetailQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Category dbCategory = null;

            if (request.CategoryId != Guid.Empty)
            {
                dbCategory = await _categoryRepository.GetByIdAsync(request.CategoryId);
            }
            else if (!string.IsNullOrEmpty(request.CategoryName))
            {
                dbCategory = await _categoryRepository.GetSingleAsync(i => i.Name == request.CategoryName);
            }
            return _mapper.Map<CategoryDetailViewModel>(dbCategory);
        }
    }
}
