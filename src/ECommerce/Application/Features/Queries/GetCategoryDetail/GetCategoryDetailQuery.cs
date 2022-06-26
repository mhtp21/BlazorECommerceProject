using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Common.Models.Queries;

namespace Application.Features.Queries.GetCategoryDetail
{
    public class GetCategoryDetailQuery : IRequest<CategoryDetailViewModel>
    {
        public GetCategoryDetailQuery(Guid categoryId, string categoryName = null)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}