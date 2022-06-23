using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Common.Models.RequestModels
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public int FailLoginCount { get; set; }
        public CreateUserCommand()
        {

        }

        public CreateUserCommand(string name,string lastname,string email,string password,bool status,int faillcount)
        {
            FirstName = name;
            LastName = lastname;
            Email = email;
            Password = password;
            Status = status;
            FailLoginCount = faillcount;
        }
    }
}
