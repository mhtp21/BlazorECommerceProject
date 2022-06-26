using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Common.Models.Queries;

namespace Application.Features.Queries.GetBrandDetail
{
    public class GetBrandDetailQuery : IRequest<BrandDetailViewModel>
    {
        public GetBrandDetailQuery(Guid brandId, string brandName = null)
        {
            BrandId = brandId;
            BrandName = brandName;
        }

        public Guid BrandId { get; set; }
        public string BrandName { get; set; }


    }
}
