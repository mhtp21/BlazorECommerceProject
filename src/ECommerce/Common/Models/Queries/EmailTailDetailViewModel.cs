using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Queries
{
    public class EmailTailDetailViewModel
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Email { get; set; }
        public enum Status { Successfull, Unsuccessfull, Process }
        public Status StatusSetting { get; set; }
        public int TryCount { get; set; }
    }
}
