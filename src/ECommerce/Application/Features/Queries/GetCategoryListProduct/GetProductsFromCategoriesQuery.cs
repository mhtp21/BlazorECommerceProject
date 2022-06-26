using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models.Page;
using Common.Models.Queries;
using MediatR;

namespace Application.Features.Queries.GetCategoryListProduct
{
    public class GetProductsFromCategoriesQuery : BasePagedQuery, IRequest<PagedViewModel<ProductDetailViewModel>>
    {
        public GetProductsFromCategoriesQuery(Guid categoryId, int page = 1, int pageSize = 10):base(page,pageSize)
        {
            CategoryId = categoryId;
        }

        public Guid CategoryId { get; set; }
    }
}
