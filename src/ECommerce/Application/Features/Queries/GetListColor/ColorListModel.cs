using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models.Queries;

namespace Application.Features.Queries.GetListColor
{
    public class ColorListModel
    {
        public IList<ColorDetailViewModel> Items { get; set; }
    }
}
