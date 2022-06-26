using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Common.Models.Queries;


namespace Application.Features.Queries.GetUserDetail
{
    public class GetUserDetailQuery : IRequest<UserDetailViewModel>
    {
        public Guid UserId { get; set; }

        public string Email { get; set; }

        public GetUserDetailQuery(Guid userId, string email=null)
        {
            UserId = userId;
            Email = email;
        }
    }
}
