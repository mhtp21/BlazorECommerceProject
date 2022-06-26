using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common.Models.Page;
using Common.Models.Queries;
using MediatR;

namespace Application.Features.Queries.GetMainPageProducts
{
    public class GetMainPageProductsQuery : BasePagedQuery, IRequest<PagedViewModel<ProductDetailViewModel>>
    {
        public GetMainPageProductsQuery(Guid? userId, int page, int pageSize) : base(page,pageSize)
        {
            UserId = userId;
        }
        public Guid? UserId { get; set; }
    }
}
