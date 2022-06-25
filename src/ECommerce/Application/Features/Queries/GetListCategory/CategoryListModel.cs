using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models.Queries;

namespace Application.Features.Queries.GetListCategory
{
    public class CategoryListModel
    {
        public IList<CategoryDetailViewModel> Items { get; set; }
    }
}
