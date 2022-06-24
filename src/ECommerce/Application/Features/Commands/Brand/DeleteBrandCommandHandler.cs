using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Application.Interfaces.Repositories;
using Common.Models.RequestModels.Delete;

namespace Application.Features.Commands.Brand
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, Guid>
    {
        private readonly IBrandRepository _brandRepository;

        public DeleteBrandCommandHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<Guid> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var dbBrand = await _brandRepository.GetByIdAsync(request.Id);
            await _brandRepository.DeleteAsync(dbBrand);
            return dbBrand.Id;
        }
    }
}
