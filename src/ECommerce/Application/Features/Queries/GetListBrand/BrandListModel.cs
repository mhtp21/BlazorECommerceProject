using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models.Queries;

namespace Application.Features.Queries.GetListBrand
{
    public class BrandListModel
    {
        public IList<BrandDetailViewModel> Items { get; set; }
    }
}
