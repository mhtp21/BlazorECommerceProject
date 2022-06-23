using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Common.Models.RequestModels.Update
{
    public class UpdateCategoryCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
