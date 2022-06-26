using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Common.Models.Queries;

namespace Application.Features.Queries.GetEmailTailDetail
{
    public class GetEmailTailDetailQuery : IRequest<EmailTailDetailViewModel>
    {
        public GetEmailTailDetailQuery(Guid emailTailId, string email = null)
        {
            EmailTailId = emailTailId;
            Email = email;
        }

        public Guid EmailTailId { get; set; }
        public string Email { get; set; }
    }
}
