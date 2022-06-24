using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Common.Models.RequestModels.Delete
{
    public class DeleteEmailTailCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public enum Status { Successfull, Unsuccessfull, Process }
        public Status StatusSetting { get; set; }
        public int TryCount { get; set; }
    }
}
