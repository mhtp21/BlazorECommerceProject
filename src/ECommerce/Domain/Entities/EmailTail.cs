using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EmailTail : BaseEntity
    {
        public string Email { get; set; }
        public enum Status { Successfull, Unsuccessfull, Process }
        public Status StatusSetting { get; set; }
        public int TryCount { get; set; }
    }
}
