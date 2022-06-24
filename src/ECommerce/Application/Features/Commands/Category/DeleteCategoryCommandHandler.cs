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
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand,Guid>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Guid> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var dbCategory = await _categoryRepository.GetByIdAsync(request.Id);
            await _categoryRepository.DeleteAsync(dbCategory);
            return dbCategory.Id;
        }
    }
}
