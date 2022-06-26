using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Common.Models.Queries;

namespace Application.Features.Queries.GetColorDetail
{
    public class GetColorDetailQuery : IRequest<ColorDetailViewModel>
    {
        public GetColorDetailQuery(Guid colorId, string colorName = null)
        {
            ColorId = colorId;
            ColorName = colorName;
        }

        public Guid ColorId { get; set; }
        public string ColorName { get; set; }
    }
}
