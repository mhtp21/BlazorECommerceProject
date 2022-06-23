using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class EmailTailRepository : GenericRepository<EmailTail>, IEmailTailRepository
    {
        public EmailTailRepository(ECommerceContext dbContext) : base(dbContext)
        {
        }
    }
}
