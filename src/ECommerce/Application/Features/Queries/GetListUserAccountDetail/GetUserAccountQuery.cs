using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Application.Features.Queries.GetListUserAccountDetail.Dtos;

namespace Application.Features.Queries.GetListUserAccountDetail
{
    public class GetUserAccountQuery : IRequest<UserAccountDetail>
    {
        public GetUserAccountQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; set; }
    }
}
