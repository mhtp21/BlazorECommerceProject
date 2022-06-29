using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Application.Interfaces.Repositories;
using Common.Models.RequestModels.Delete;

namespace Application.Features.Commands.Category
{
    public class DeleteCategoryCommand : IRequest<DeleteCategoryModel>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommand(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<DeleteCategoryModel> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Domain.Entities.Category>(request);
            var deleteCategory = await _categoryRepository.DeleteAsync(category);
            var result = _mapper.Map<DeleteCategoryModel>(deleteCategory);
            return result;
        }
    }
}
