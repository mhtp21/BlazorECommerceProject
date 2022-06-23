using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Common.Models.RequestModels
{
    public class CreateColorCommand :IRequest<Guid>
    {
        public string Name { get; set; }

        public CreateColorCommand()
        {

        }
        public CreateColorCommand(string name)
        {
            Name = name;
        }
    }
}
