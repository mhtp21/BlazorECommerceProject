using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Common.Models.RequestModels.Delete
{
    public class DeleteColorModel
    {
        public Guid Id { get; set; }
    }
}
