using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Common.Models.Queries;
using Application.Interfaces.Repositories;
using AutoMapper;

namespace Application.Features.Queries.GetListCategory
{
    public class GetListCategoryQuery : IRequest<CategoryDetailViewModel>
    {
        public class GetListCategoryueryHandler : IRequestHandler<GetListCategoryQuery, CategoryDetailViewModel>
        {
            private readonly IMapper _mapper;
            private readonly ICategoryRepository _categoryRepository;

            public GetListCategoryueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
            {
                _mapper = mapper;
                _categoryRepository = categoryRepository;
            }

            public async Task<CategoryDetailViewModel> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
            {
                var categories = await _categoryRepository.GetAll();
                var categoryListModel = _mapper.Map<CategoryDetailViewModel>(categories);
                return categoryListModel;
            }
        }
    }
}
