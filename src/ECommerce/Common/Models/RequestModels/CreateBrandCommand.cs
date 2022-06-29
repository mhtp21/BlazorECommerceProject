using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Common.Models.RequestModels
{
    public class CreateBrandCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
